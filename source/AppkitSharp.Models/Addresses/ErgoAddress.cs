using AppkitSharp.Common;
using AppkitSharp.Common.Encoding.Base58;

namespace AppkitSharp.Models.Addresses
{
    public static class ErgoAddress
    {
        public static IErgoAddress FromBase58(string address)
        {
            byte[] bytes = Base58Encoding.Decode(address);
            byte header = bytes[0];

            var addressType = header & 0xF;

            AddressType aType = (AddressType) addressType;

            var networkType = header & 0xF0;

            NetworkType nType = networkType < Constants.NetworkPrefix ? 
                NetworkType.Mainnet : 
                NetworkType.Testnet;

            //AddressType address = (bytes[0] >> 4) switch
            //{
            //    0x01 => AddressType.PayToPublicKey, //@TODO: derive all AddressTypes
            //    0x02 => AddressType.Enterprise,
            //    //0x07 => AddressType.SmartContract,
            //    _ => AddressType.Base,
            //};

            //if (!addr.IsValid())
            //{
            //    throw new Error(`Invalid Ergo address ${ address }`);
            //}

            return new P2PkAddress(address);
        }
    }
}
