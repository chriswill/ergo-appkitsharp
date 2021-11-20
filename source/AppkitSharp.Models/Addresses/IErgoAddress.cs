namespace AppkitSharp.Models.Addresses
{
    public interface IErgoAddress
    {
        string Address { get; }

        byte[] AddressBytes { get;  }

        byte[] PublicKey { get; }

        public AddressType AddressType { get; }

        public NetworkType Network { get; }

        string ErgoTree { get; }

        bool IsValid();
    }
}
