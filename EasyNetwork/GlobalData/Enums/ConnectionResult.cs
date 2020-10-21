using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNetwork.GlobalData.Enums
{
    /// <summary>
    /// The possible results of a connection attempt.
    /// </summary>
    public enum ConnectionResult
    {
        /// <summary>
        /// A connection was established successfully.
        /// </summary>
        Connected,
        /// <summary>
        /// A connection couldn't be established. The IP, port and firewall might have to be checked.
        /// </summary>
        Timeout,
        /// <summary>
        /// Could not establish a UDP connection as the parent TCP connection is not alive.
        /// </summary>
        TCPConnectionNotAlive
    }
}
