using System.Collections.Concurrent;
using System.Collections.Generic;

namespace EasyNetwork.Utilities
{
    /// <summary>
    /// Same as a .net dictionary. But just working in both directions.
    /// </summary>
    /// <typeparam name="T">The type of the first dictionary.</typeparam>
    /// <typeparam name="U">The type of the second dictionary.</typeparam>
    internal class BiDictionary<T, U>
    {
        //表示可以由多个线程同时访问的键/值对的线程安全集合。
        private ConcurrentDictionary<T, U> dictOne = new ConcurrentDictionary<T, U>();
        private ConcurrentDictionary<U, T> dictTwo = new ConcurrentDictionary<U, T>();

        /// <summary>
        /// Gets or sets the <see cref="T"/> with the specified u.
        /// </summary>
        /// <param name="u">The u.</param>
        /// <returns>T.</returns>
        public T this[U u]
        {
            get
            {
                if (dictTwo.ContainsKey(u))
                    return dictTwo[u];

                return default(T);
            }
            set
            {
                if (!dictTwo.ContainsKey(u))
                    dictTwo.AddOrUpdate(u, value, (ou, t) => value);
                if (!dictOne.ContainsKey(value))
                    dictOne.AddOrUpdate(value, u, (t, ou) => u);

                dictOne[value] = u;
                dictTwo[u] = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="U"/> with the specified t.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns>U.</returns>
        public U this[T t]
        {
            get
            {
                if (dictOne.ContainsKey(t))
                    return dictOne[t];

                return default(U);
            }
            set
            {
                if (!dictOne.ContainsKey(t))
                    dictOne.AddOrUpdate(t, value, (ot, u) => value);
                if (!dictTwo.ContainsKey(value))
                    dictTwo.AddOrUpdate(value, t, (u, ot) => t);

                dictTwo[value] = t;
                dictOne[t] = value;
            }
        }

        /// <summary>
        /// The keys held in the dictionary.
        /// </summary>
        internal ICollection<T> Keys => dictOne.Keys;

        /// <summary>
        /// The values held in the dictionary.
        /// </summary>
        internal ICollection<U> Values => dictOne.Values;

        public bool ContainsKey(T t) => dictOne.ContainsKey(t);

        public bool ContainsKey(U u) => dictTwo.ContainsKey(u);

        public bool ContainsValue(U u) => dictOne.Values.Contains(u);

        public bool ContainsValue(T t) => dictTwo.Values.Contains(t);
    }
}
