using AppkitSharp.Models.Keys;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace AppkitSharp.Services.Extensions
{
    public static class MnemonicExtensions
    {
        public static PrivateKey GetRootKey(this Mnemonic mnemonic, string password = "")
        {
            byte[] rootKey = KeyDerivation.Pbkdf2(password, mnemonic.Entropy, KeyDerivationPrf.HMACSHA512, 2048, 512);
            //rootKey[0] &= 248;
            //rootKey[31] &= 31;
            //rootKey[31] |= 64;

            return new PrivateKey(rootKey.Slice(0, 64), rootKey.Slice(64));
        }
        //public static MasterNodeDerivation GetMasterNode(this Mnemonic mnemonic, string password = "")
        //{
        //    return new MasterNodeDerivation(mnemonic.GetRootKey(password));
        //}
    }
}
