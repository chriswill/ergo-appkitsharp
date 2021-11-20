using AppkitSharp.Common;

namespace AppkitSharp.Models.Addresses
{
    public class Pay2SAddress : IErgoAddress
    {
        public byte AddressTypePrefix => Constants.PayToScriptAddress;
        public byte[] AddressBytes { get; set; }
        public byte NetworkPrefix { get; set; }
    }
}
