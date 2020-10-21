using System;
using System.Collections.Generic;
using System.Text;

using EasyNetwork.Attributes;

namespace EasyNetwork.Packets
{
    /// <summary>
    /// Acknowledgement packet for the <see cref="EstablishUdpResponse"/> packet.
    /// </summary>
    [PacketType(5)]
    internal class EstablishUdpResponseACK : Packet { }
}
