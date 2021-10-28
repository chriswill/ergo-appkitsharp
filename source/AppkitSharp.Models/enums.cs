using System;
using System.Collections.Generic;
using System.Text;

namespace AppkitSharp.Models
{

    public enum NetworkType
    {
        Testnet,
        Mainnet
    }

    public enum AddressType
    {
        PayToPublicKey,
        PayToScriptHash,
        PayToScript
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
