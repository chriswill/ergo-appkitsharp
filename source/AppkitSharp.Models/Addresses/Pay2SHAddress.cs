using AppkitSharp.Common.Extensions;

namespace AppkitSharp.Models.Addresses
{
    public class Pay2SHAddress : AddressBase
    {


        public Pay2SHAddress(string address) : base(address)
        {
        }

        public override AddressType AddressType => AddressType.PayToScriptHash;

        public override string ErgoTree => AddressBytes.SubArray(1, AddressBytes.Length - 4).ToStringHex();
    }
}
