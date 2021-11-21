using Blake2Fast;

namespace AppkitSharp.Common.Encoding
{
    public static class HashUtility
    {
        public static byte[] Blake2b244(byte[] data)
        {
            return Blake2b.ComputeHash(28, data);
        }

        public static byte[] Blake2b256(byte[] data)
        {
            return Blake2b.ComputeHash(32, data);
        }
    }
}
