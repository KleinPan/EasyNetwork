﻿using System;
using System.Threading;
using System.Threading.Tasks;

using EasyNetwork.Connections;
using EasyNetwork.Converter;
using EasyNetwork.Extensions;
using EasyNetwork.Packets;

namespace EasyNetwork.Async
{
    /// <summary>
    /// Chicken chicken chicken, chicken chicken chicken chicken chicken chicken, <see cref="ChickenReceiver"/> chicken
    /// chicken chicken chicken.
    /// </summary>
    /// <remarks>
    /// Provides methods for the asynchronous sending and receiving of <see cref="Packet"/> objects across the network.
    /// </remarks>
    internal class ChickenReceiver : IDisposable
    {
        #region Variables

        /// <summary>
        /// A <see cref="ManualResetEvent"/> that allows for the instance to wait until the <see cref="ResponsePacket"/> for a sent packet is received.
        /// </summary>
        private readonly ManualResetEvent packetReceivedEvent = new ManualResetEvent(false);

        #endregion Variables

        #region Methods

        #region Implementation of IDisposable

        /// <inheritdoc />
        public void Dispose()
        {
            packetReceivedEvent.Dispose();
        }

        #endregion Implementation of IDisposable

        /// <summary>
        /// Sends the given <see cref="Packet"/> to the network, via the given <see cref="Connection"/> and waits
        /// asynchronously for the response, returning it.
        /// </summary>
        /// <typeparam name="R">The type of the <see cref="ResponsePacket"/> to wait for.</typeparam>
        /// <param name="packet">The <see cref="Packet"/> to send to the network.</param>
        /// <param name="connection">
        /// The <see cref="Connection"/> that should send the given packet and wait for the response.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the asynchronous operation, that promises a <see cref="ResponsePacket"/> of
        /// the given type upon completion.
        /// </returns>
        public async Task<R> Send<R>(Packet packet, Connection connection) where R : ResponsePacket
        {
            Packet receivedAsyncPacket = null;
            object tempObject = new object();

            //Register the packet we would like to receive.
            connection.RegisterPacketHandler<R>(((packetAnswer, c) =>
            {
                receivedAsyncPacket = packetAnswer;
                c.UnRegisterPacketHandler<R>(tempObject);
                packetReceivedEvent.Set();
            }), tempObject);

            //Send the packet normally.
            connection.Send(packet, tempObject);

            //Wait for an answer or till we reach the timeout.
            try
            {
                if (receivedAsyncPacket == null)
                {
                    await packetReceivedEvent.AsTask(
                        TimeSpan.FromMilliseconds(connection.TIMEOUT));
                }
            }
            catch (OverflowException overflowException)
            {
                connection.Logger.Log($"Exception while waiting for async packet occured. Request packet {packet.GetType().Name}",
                    overflowException, GlobalData.Enums.LogLevel.Error);
            }

            //No answer from the endPoint
            if (receivedAsyncPacket == null)
            {
                R emptyPacket = PacketConverterHelper.InstantiateGenericPacket<R>();
                emptyPacket.State = GlobalData.Enums.PacketState.Timeout;
                return emptyPacket;
            }

            return (R)receivedAsyncPacket;
        }

        #endregion Methods
    }
}
