using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNetwork.GlobalData.Enums
{
    /// <summary>
    /// Enumerates the possible types of <see cref="Connection"/>.
    /// </summary>
    public enum ConnectionType
    {
        /// <summary>
        /// The <see cref="Connection"/> should use TCP to communicate across the network.
        /// </summary>
        TCP,

        /// <summary>
        /// The <see cref="Connection"/> should use UDP to communicate across the network.
        /// </summary>
        UDP,

        /// <summary>
        /// The <see cref="Connection"/> should use Bluetooth to communicate across the network.
        /// </summary>
        Bluetooth
    }
}
