using System;
using System.Collections.Generic;
using System.IO;
using AppkitSharp.Common;
using AppkitSharp.Common.Encoding.Base58;

namespace AppkitSharp.Models.Addresses
{
    public class Address : IEqualityComparer<Address>, IEquatable<Address>, IEquatable<string>, IEquatable<byte[]>
    {
        private readonly byte[] bytes;
        private readonly string address;

        private byte headerByte => bytes[0];

        public AddressType AddressType { get; private set; }

        public NetworkType NetworkType { get; private set; }

        public Address(){}

        public Address(string prefix, byte[] address)
        {
            bytes = address;
            //address = Bech32.Encode(address, prefix);
        }

        public Address(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentNullException(nameof(address));

            byte[] val = Base58Encoding.DecodeWithCheckSum(address);
            if (val.Length == 0) throw new InvalidDataException("Could not decode address");
            bytes = val;

            //if (!bech32.HasValidChars(address))
            //{
            //    throw new ArgumentException("Invalid characters", nameof(address));
            //}

            //address = address;
            //bytes = Bech32.Decode(_address, out byte witVer, out string prefix);

            //Prefix = prefix;
            //WitnessVersion = witVer;
            AddressType = GetAddressType();
            NetworkType = GetNetworkType();
        }

        /// <summary>
        /// Returns <see cref="AddressType"/> as defined in https://github.com/cardano-foundation/CIPs/blob/master/CIP-0019/CIP-0019.md
        /// </summary>
        /// <returns>
        ///     <para><see cref="AddressType.Base"/> if AddressType header is 0x01</para>
        ///     <para><see cref="AddressType.Enterprise"/> if AddressType header is 0x06</para>
        ///     <para>otherwise <see cref="AddressType.Base"/></para>
        /// </returns>
        /// <returns></returns>
        private AddressType GetAddressType()
        {
            //return (bytes[0] >> 4) switch
            //{
            //    0x01 => AddressType.Base, //@TODO: derive all AddressTypes
            //    0x06 => AddressType.Enterprise,
            //    //0x07 => AddressType.SmartContract,
            //    _ => AddressType.Base,
            //};
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns <see cref="NetworkType"/> as defined in https://github.com/cardano-foundation/CIPs/blob/master/CIP-0019/CIP-0019.md
        /// </summary>
        /// <returns>
        ///     <para><see cref="NetworkType.Testnet"/> if Metwork header is 0x00</para>
        ///     <para><see cref="NetworkType.Mainnet"/> if Network header is 0x01</para>
        /// </returns>
        /// <exception cref="InvalidOperationException">If LSB is </exception>"
        private NetworkType GetNetworkType()
        {
            return headerByte < Constants.NetworkPrefix ? NetworkType.Mainnet : NetworkType.Testnet;
        }

        public string Prefix { get; set; }
        public byte WitnessVersion { get; set; }

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
