using AppkitSharp.Common;
using AppkitSharp.Common.Extensions;

namespace AppkitSharp.Models.Addresses
{
    public class Pay2SAddress : AddressBase
    {


        public Pay2SAddress(string address) : base(address)
        {
        }

        public override AddressType AddressType => AddressType.PayToScript;

        public override string ErgoTree => AddressBytes.SubArray(1, AddressBytes.Length - 4).ToStringHex();
    }
}
