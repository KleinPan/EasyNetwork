using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNetwork.Converter
{
    /// <summary>
    /// Enumerates the possible states of a network object before and after deserialisation.
    /// </summary>
    public enum ObjectState : byte
    {
        /// <summary>
        /// The network object is null, so there is nothing to read from the network stream.
        /// </summary>
        Null = 0x00,

      
        /// <summary>
        /// The network object is not null, so there is something to read from the network stream.
        /// </summary>
        NotNull = 0xFF,

     
    }
}
