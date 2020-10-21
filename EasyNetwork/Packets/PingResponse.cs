using System;
using System.Collections.Generic;
using System.Text;

using EasyNetwork.Attributes;

namespace EasyNetwork.Packets
{
    /// <summary>
    /// Response packet for the <see cref="PingRequest"/> packet.
    /// </summary>
    [PacketType(1)]
    internal class PingResponse : Packet { }
}
