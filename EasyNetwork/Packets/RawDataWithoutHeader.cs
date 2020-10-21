using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNetwork.Packets
{
   

    public class RawDataWithoutHeader : Packet
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RawData"/> class.
        /// </summary>
        /// <param name="key">The key that <see cref="RawData"/> packet handlers are registered with.</param>
        /// <param name="data">The serialised primitive value.</param>
        internal RawDataWithoutHeader(  byte[] data)
        {
            Key = "RawDataWithoutHeader";
            Data = data;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The key both connections are able to register <see cref="RawData"/> packet handlers to.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The serialised primitive value.
        /// <para>序列化的原始值。</para>
        /// </summary>
        public byte[] Data { get; set; }

        #endregion Properties
    }
}
