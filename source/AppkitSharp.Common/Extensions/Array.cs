using System;

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
    }
}
