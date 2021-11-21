using System;
using System.Linq;

namespace AppkitSharp.Common.Extensions
{
    public static class ArrayExtensions
    {
        public static byte[] ToByteArray(this sbyte[] source)
        {
            byte[] unsigned = new byte[source.Length];
            Buffer.BlockCopy(source, 0, unsigned, 0, source.Length);
            return unsigned;
        }

        public static sbyte[] ToSignedByteArray(this byte[] source)
        {
            sbyte[] signed = new sbyte[source.Length];
            Buffer.BlockCopy(source, 0, signed, 0, source.Length);
            return signed;
        }

        public static string ToStringHex(this byte[] source)
        {
            return BitConverter
                .ToString(source)
                .Replace("-", "")
                .ToLower();
        }

        public static byte[] FromStringHex(this string source)
        {
            int numberChars = source.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(source.Substring(i, 2), 16);
            return bytes;
        }
    }
}
