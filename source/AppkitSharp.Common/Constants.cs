namespace AppkitSharp.Common
{
    public static class Constants
    {
        public static byte MainnetNetworkPrefix = 0x00;
        public static byte NetworkPrefix = 0x10;
        public static byte PayToPublicKeyAddress = 0x01;
        public static byte PayToScriptHashAddress = 0x02;
        public static byte PayToScriptAddress = 0x03;
        public static byte[] BitcoinSeed = System.Text.Encoding.UTF8.GetBytes("Bitcoin seed");
        public static int SecretKeyLength = 32;
    }
}