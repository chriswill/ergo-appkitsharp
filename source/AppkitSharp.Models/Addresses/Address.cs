using System;
using System.Collections.Generic;
using AppkitSharp.Models.Configuration;

namespace AppkitSharp.Models.Addresses
{
    public class Address : IEqualityComparer<Address>, IEquatable<Address>, IEquatable<string>, IEquatable<byte[]>
    {
        private byte[] bytes;
        private string address;

        public AddressType AddressType { get; private set; }

        public NetworkType NetworkType { get; private set; }

        public Address(){}

        public bool Equals(string other)
        {
            return address.Equals(other);
        }

        public bool Equals(byte[] other)
        {
            return bytes.Equals(other);
        }

        public bool Equals(Address other)
        {
            if (other == null) return false;
            return bytes.Equals(other.GetBytes());
        }

        public byte[] GetBytes()
        {
            return bytes;
        }

        public override string ToString()
        {
            return address;
        }

        public string ToStringHex()
        {
            var hex = BitConverter
                .ToString(bytes)
                .Replace("-", "")
                .ToLower();

            return hex;
        }

        public bool Equals(Address x, Address y)
        {
            if (x == null && y == null) return true;

            return x != null && x.Equals(y);
        }

        public int GetHashCode(Address obj)
        {
            return obj.GetBytes().GetHashCode();
        }
    }
}
