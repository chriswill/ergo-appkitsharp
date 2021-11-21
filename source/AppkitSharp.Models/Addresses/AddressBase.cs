using System;
using System.Collections.Generic;
using AppkitSharp.Common;
using AppkitSharp.Common.Encoding;
using AppkitSharp.Common.Encoding.Base58;
using AppkitSharp.Common.Extensions;

namespace AppkitSharp.Models.Addresses
{
    //https://ergoplatform.org/en/blog/2019_07_24_ergo_address/

    public abstract class AddressBase : IErgoAddress, IEqualityComparer<AddressBase>, IEquatable<AddressBase>,
        IEquatable<string>, IEquatable<byte[]>
    {
        protected AddressBase(string address)
        {
            Address = address;
            AddressBytes = Base58Encoding.Decode(address);
            byte header = AddressBytes[0];

            int aType = header >> 4;

            AddressType addressType = (AddressType) aType;

            int netType = header & 0xF0;

            Network = netType < Constants.NetworkPrefix ?
                NetworkType.Mainnet :
                NetworkType.Testnet;

        }

        public byte[] AddressBytes { get; }
        
        public abstract AddressType AddressType { get;  }
        
        public NetworkType Network { get; }
        
        public abstract string ErgoTree { get; }

        public string Address { get; }

        public byte[] PublicKey => AddressBytes.SubArray(1, 33);

        public bool Equals(string other)
        {
            return Address.Equals(other);
        }

        public bool Equals(byte[] other)
        {
            return AddressBytes.Equals(other);
        }

        public bool Equals(AddressBase other)
        {
            if (other == null) return false;
            return other.Equals(other.AddressBytes);
        }

        public bool Equals(AddressBase x, AddressBase y)
        {
            if (x == null && y == null) return true;

            return x != null && x.Equals(y);
        }

        public int GetHashCode(AddressBase obj)
        {
            return obj.AddressBytes.GetHashCode();
        }

        public bool IsValid()
        {
            int size = AddressBytes.Length;
            byte[] script = AddressBytes.SubArray(0, size - 4);
            var checksum = AddressBytes.SubArray(size - 4, 4);
            var calculatedChecksum = HashUtility.Blake2b256(script).SubArray(0, 4);
            return calculatedChecksum.ToStringHex() == checksum.ToStringHex();
        }
    }
}
