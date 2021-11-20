using AppkitSharp.Common;

namespace AppkitSharp.Models.Addresses
{
    public class P2PKAddress : IErgoAddress
    {
        public byte AddressTypePrefix => Constants.PayToPublicKeyAddress;
        public byte[] AddressBytes { get; set; }
        public byte NetworkPrefix { get; set; }
    }
}
