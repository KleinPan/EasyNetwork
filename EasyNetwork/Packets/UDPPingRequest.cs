using System;
using System.Collections.Generic;
using System.Text;

using EasyNetwork.Attributes;

namespace EasyNetwork.Packets
{
    /// <summary>
    /// A ping testing packet that functions over UDP.
    /// </summary>
    [PacketType(8)]
    internal class UDPPingRequest : RequestPacket
    {
    }
}
