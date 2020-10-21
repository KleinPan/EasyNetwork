using System.Threading;

using EasyNetwork.Connections;

namespace EasyNetwork.Extensions
{
    /// <summary> Provides additional functionality to the <see cref="Connection"/> class. </summary>
    internal static class ConnectionExtensions
    {
        #region Variables

        /// <summary> A private thread-safe counter for generating unique hash codes. </summary>
        /// <remarks>
        /// Increments are guaranteed to be atomic on all 32-bit and higher systems, as any single-cpu-instruction operation on a variable is by definition atomic. Since an <see cref="int"/> is 32 bits long, it can be loaded with 1 instruction into a register on a 32-bit or higher system. Likewise, addition is also atomic. This guarantees atomic behaviour for increments on an <see cref="int"/>.
        /// <para> </para>
        /// 保证增量在所有32位及更高版本的系统上都是原子的，就像任何单CPU指令一样根据定义，对变量的操作是原子的。由于 <see cref="int"/> 的长度为32位， 因此可以加载它在32位或更高系统上的寄存器中添加1条指令。同样，加法也是原子的。这个保证原子行为在 <see cref="int"/> 上递增。
        /// </remarks>
        private static int counter;

        #endregion Variables

        #region Methods

        /// <summary> Generates a new unique hash code for the <see cref="Connection"/> via a thread-safe increment operation. </summary>
        /// <param name="connection"> The <see cref="Connection"/> instance this extension method affects. </param>
        /// <returns> A new, unique hash code. </returns>
        /// <remarks> This method is thread safe, see <see cref="counter"/> for more info. </remarks>
        internal static int GenerateUniqueHashCode(this Connection connection)
        {
            return Interlocked.Increment(ref counter);
        }

        #endregion Methods
    }
}