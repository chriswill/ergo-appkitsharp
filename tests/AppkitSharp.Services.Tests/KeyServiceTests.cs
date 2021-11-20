using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using AppkitSharp.Models.Keys;
using AppkitSharp.Services.Extensions;
using AppkitSharp.Services.Wallet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppkitSharp.Common.Extensions;
using AppkitSharp.Models.Wallet;

namespace AppkitSharp.Services.Tests
{
    [TestClass]
    public class KeyServiceTests
    {
        private const string TestMnemonic = "slow silly start wash bundle suffer bulb ancient height spin express remind today effort helmet";
        private readonly byte[] testEntropy = new byte[] { 204, 57, 23, 82, 251, 177, 229, 177, 71, 120, 68, 106, 186, 61, 67, 90, 238, 52, 141, 90 };
        private string mainNetAddress = "3WzR39tWQ5cxxWWX6ys7wNdJKLijPeyaKgx72uqg9FJRBCdZPovL";
        private string testNetAddress = "9iKta87bcxmNEJEFmYqCb7WLPWJ2xdwicz25eJAHbF2fuRcPsss";
        private sbyte[] testSeed = new sbyte[] {
            -31, -40, -4, 104, 78, 89, 63, 101, -40, 102, 123, -102, -66, 102, 107, 116, 72, 77, 83, -54, 84, -59, -74, -
                102, 20, 43, -76, -67, -117, -19, -35, 100, 114, -32, 17, 113, 46, 71, 2, 62, -113, 109, -89, -13, -13, -
                35, -44, -28, -97, -98, 89, -13, -36, -90, -74, -75, 43, -3, 97, 74, -76, 70, 81, 78
        };

   //     /** Mainnet address generated from `mnemonic` and corresponding to first EIP-3 address..
   //      * (i.e. `m/44'/429'/0'/0/0` derivation path).
   //      */
   //     val firstEip3AddrStr = "9eatpGQdYNjTi5ZZLK7Bo7C3ms6oECPnxbQTRn6sDcBNLMYSCa8"

   //     /** Mainnet address generated from `mnemonic` and corresponding to second EIP-3 address..
   //* (i.e. `m/44'/429'/0'/0/1` derivation path).
   //*/
   //     val secondEip3AddrStr = "9iBhwkjzUAVBkdxWvKmk7ab7nFgZRFbGpXA9gP6TAoakFnLNomk"



        [TestMethod]
        public void CanCreateMnemonic()
        {
            IKeyService keyService = new KeyService();
            Mnemonic mnemonic = keyService.Generate(15, testEntropy);
            Assert.IsNotNull(mnemonic);
            Assert.AreEqual(TestMnemonic, mnemonic.Words);
        }

        [TestMethod]
        public void CanRestoreMnemonic()
        {
            IKeyService keyService = new KeyService();
            Mnemonic mnemonic = keyService.Restore(TestMnemonic);
            Assert.AreEqual(testEntropy.Length, mnemonic.Entropy.Length);
            Assert.IsTrue(testEntropy.SequenceEqual(mnemonic.Entropy));
        }

        [TestMethod]
        public void CanGenerateSeed()
        {
            IKeyService keyService = new KeyService();
            Mnemonic mnemonic = keyService.Restore(TestMnemonic);
            byte[] seed = mnemonic.GetSeed();
            Assert.IsTrue(testSeed.ToByteArray().SequenceEqual(seed));
        }

        [TestMethod]
        public void CanGenerateExtendedSecretKey()
        {
            sbyte[] masterKey = new sbyte[]
            {
                24, 37, -114, -104, -22, -121, 37, 104, 6, 39, 91, 113, -53, 32, 61, -62, 52, 117, 36, -120, -32, 25,
                -123, -44, 5, 66, 110, 92, 111, 78, -95, -47
            };

            sbyte[] chainCode = new sbyte[]
            {
                -17, -23, 46, 90, -33, -54, -90, -10, 17, 115, 16, -125, 5, -9, -29, -70, 78, -55, 100, 58, -127, -33,
                -6, 52, 120, 121, -49, 77, 88, -46, -95, 0
            };

            IKeyService keyService = new KeyService();
            Mnemonic mnemonic = keyService.Restore(TestMnemonic);
            byte[] seed = mnemonic.GetSeed();

            byte[] bitcoinSeed = Encoding.UTF8.GetBytes("Bitcoin seed");
            PrivateKey key;
            using (var hmac = new HMACSHA512(bitcoinSeed))
            {
                byte[] hashValue = hmac.ComputeHash(seed);
                key = new PrivateKey(hashValue[Range.EndAt(32)], hashValue[Range.StartAt(32)], DerivationPath.MasterPath);
            }

            Assert.IsNotNull(key);
        }
    }
}
