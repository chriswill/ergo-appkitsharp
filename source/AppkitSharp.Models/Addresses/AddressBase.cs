using System;
using System.Collections.Generic;
using AppkitSharp.Common.Encoding.Base58;

namespace AppkitSharp.Models.Addresses
{
    public abstract class AddressBase : IErgoAddress, IEqualityComparer<Address>, IEquatable<Address>,
        IEquatable<string>, IEquatable<byte[]>
    {
        protected AddressBase(string address)
        {

        }

        public byte[] AddressBytes { get; }
        public AddressType AddressType { get; }
        public NetworkType Network { get; }
        public string ErgoTree { get; }

        public string Address => throw new NotImplementedException();

        public byte[] PublicKey => throw new NotImplementedException();

        public bool Equals(Address x, Address y)
        {
            throw new NotImplementedException();
        }

        public bool Equals(string other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(byte[] other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Address other)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode(Address obj)
        {
            throw new NotImplementedException();
        }

        public IErgoAddress FromBase58(string address)
        {
            byte[] bytes = Base58Encoding.Decode(address);
            byte header = bytes[0];


            if (!addr.IsValid())
            {
                throw new Error(`Invalid Ergo address ${ address }`);
            }
            return addr;
        }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
