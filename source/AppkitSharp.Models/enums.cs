namespace AppkitSharp.Models
{
    public enum CoinType
    {
        /// <summary>
        /// Represents the 'Ergo' coin type.
        /// </summary>
        Ergo = 429
    }

    public enum DerivationType
    {
        HARD,
        SOFT
    }

    public enum PurposeType
    {
        /// <summary>
        /// Pre-EIP3 implementation
        /// </summary>
        Original = 1,
        /// <summary>
        /// Represents a constant from the BIP43 recommendation.
        /// </summary>
        Default = 44
    }

    public enum NetworkType: byte
    {
        Mainnet = 0x00,
        Testnet = 0x10
    }

    public enum RoleType
    {
        /// <summary>
        /// Same as defined in <see href="https://github.com/bitcoin/bips/blob/master/bip-0044.mediawiki">BIP44</see>
        /// </summary>
        ExternalChain = 0,
        /// <summary>
        /// Same as defined in <see href="https://github.com/bitcoin/bips/blob/master/bip-0044.mediawiki">BIP44</see>
        /// </summary>
        InternalChain = 1
    }

    public enum AddressType: byte
    {
        PayToPublicKey = 0x01,
        PayToScriptHash = 0x02,
        PayToScript = 0x03
    }

    public enum WordList
    {
        English,
        ChineseSimplified,
        ChineseTraditional,
        French,
        Italian,
        Japanese,
        Korean,
        Spanish
    }
}
