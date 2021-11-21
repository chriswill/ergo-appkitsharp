using AppkitSharp.Common;
using AppkitSharp.Common.Extensions;

namespace AppkitSharp.Models.Addresses
{
    public class P2PKAddress : AddressBase
    {
        public P2PKAddress(string address): base(address){}

        public override AddressType AddressType => AddressType.PayToPublicKey;

        public override string ErgoTree
        {
            get
            {
                byte[] header = new byte[] { 0x00, 0x08, 0xcd };
                byte[] full = header.ConcatFast(PublicKey);
                return full.ToStringHex();
            }
        }
    }
}
