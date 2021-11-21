using System;
using AppkitSharp.Common;
using AppkitSharp.Common.Encoding;
using AppkitSharp.Common.Encoding.Base58;
using AppkitSharp.Common.Extensions;

namespace AppkitSharp.Models.Addresses
{
    public static class ErgoAddress
    {
        public static IErgoAddress FromBase58(string address)
        {
            byte[] bytes = Base58Encoding.Decode(address);
            byte header = bytes[0];

            int aType = header >> 4;

            AddressType addressType = (AddressType) aType;

            switch (addressType)
            {
                case AddressType.PayToPublicKey:
                    return new P2PKAddress(address);
                case AddressType.PayToScript:
                    return new Pay2SAddress(address);
                case AddressType.PayToScriptHash:
                    return new Pay2SHAddress(address);
                default:
                    throw new Exception("Address type cannot be determined");
            }
        }

        public static IErgoAddress FromBytes(byte[] bytes)
        {
            string address = Base58Encoding.Encode(bytes);
            byte header = bytes[0];

            int aType = header >> 4;

            AddressType addressType = (AddressType)aType;

            switch (addressType)
            {
                case AddressType.PayToPublicKey:
                    return new P2PKAddress(address);
                case AddressType.PayToScript:
                    return new Pay2SAddress(address);
                case AddressType.PayToScriptHash:
                    return new Pay2SHAddress(address);
                default:
                    throw new Exception("Address type cannot be determined");
            }
        }

        public static IErgoAddress FromErgoTree(string ergoTree, NetworkType networkType = NetworkType.Mainnet)
        {
            if (ergoTree.StartsWith("0008cd"))
            {
                byte prefixByte = (byte)(Convert.ToByte(networkType) + Constants.PayToPublicKeyAddress);
                string pk = ergoTree.Substring(6);
                byte[] contentBytes = pk.FromStringHex();
                byte[] headerBytes = new byte[] { prefixByte };
                byte[] allBytes = headerBytes.ConcatFast(contentBytes);
                string checksum = HashUtility.Blake2b256(allBytes).ToStringHex();
            }
            else
            {

            }

            return new P2PKAddress("");
        }

    }
}
