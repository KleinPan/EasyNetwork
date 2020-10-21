using System;
using System.Collections.Generic;
using System.Text;

using EasyNetwork.Attributes;

namespace EasyNetwork.Packets
{
    /// <summary>
    /// Used to perform ping checks between <see cref="Connection"/>s.
    /// </summary>
    [PacketType(0)]
    internal class PingRequest : Packet { }
}
