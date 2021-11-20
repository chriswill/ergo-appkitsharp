using System;
using System.Text;
using AppkitSharp.Models.Keys;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;

namespace AppkitSharp.Services.Extensions
{
    public static class MnemonicExtensions
    {
        public static PrivateKey GetRootKey(this Mnemonic mnemonic, string password = "")
        {
            byte[] rootKey = GetSeed(mnemonic, password);

            return new PrivateKey(rootKey, rootKey);
        }

        public static byte[] GetSeed(this Mnemonic mnemonic, string password = "")
        {
            Pkcs5S2ParametersGenerator gen = new Pkcs5S2ParametersGenerator(new Sha512Digest());
            gen.Init(Encoding.UTF8.GetBytes(mnemonic.Words), Encoding.UTF8.GetBytes($"mnemonic{password}"), 2048);

            KeyParameter dk = gen.GenerateDerivedMacParameters(512) as KeyParameter;
            if (dk is null) throw new InvalidOperationException();
            return dk.GetKey();
        }

        //public static MasterNodeDerivation GetMasterNode(this Mnemonic mnemonic, string password = "")
        //{
        //    return new MasterNodeDerivation(mnemonic.GetRootKey(password));
        //}
    }
}
