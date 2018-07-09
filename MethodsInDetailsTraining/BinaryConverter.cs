using System.Runtime.InteropServices;

namespace MethodsInDetailsTraining
{
    /// <summary>
    /// Converts value of <see cref="System.Double"/> type to the binary string
    /// </summary>
    public static class BinaryConverter
    {
        #region Private Fields
        private static readonly int MAXBITS = 64;
        #endregion

        #region Public Methods
        /// <summary>
        /// Converts value to the binary string representation
        /// </summary>
        /// <param name="number"> The <see cref="System.Double"/> type's value to be converted </param>
        /// <returns> The string representing converted value </returns>
        public static string ToBinaryString(this double number)
        {
            var doubleStruct = new DoubleToLongStruct(number);
            long temp = doubleStruct.LongContainer;

            long pointer = 1;
            char[] array = new char[MAXBITS];

            for (int i = array.Length - 1; i >= 0; i--)
            {
                array[i] = (temp & pointer) == 0 ? '0' : '1';
                pointer <<= 1;
            }

            return new string(array);
        }
        #endregion

        #region Nested Types
        /// <summary>
        /// Allows to read as <see cref="System.Int64"> value initialized firstly as <see cref="System.Double">
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLongStruct
        {
            [FieldOffset(0)]
            private readonly long longContainer;

            [FieldOffset(0)]
            private double doubleContainer;

            /// <summary>
            /// Initializes a new instance of the <see cref="BinaryConverter.DoubleToLongStruct" /> structure
            /// </summary>
            /// <param name="number"></param>
            public DoubleToLongStruct(double number)
            {
                longContainer = default(long);
                doubleContainer = number;
            }

            /// <summary>
            /// Gets a value of <see cref="System.Int64"> type field containing bits 
            /// initially stored in <see cref="System.Double"> type field
            /// </summary>
            public long LongContainer
            {
                get
                {
                    return longContainer;
                }
            }
        }
        #endregion
    }
}