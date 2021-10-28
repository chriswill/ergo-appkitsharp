using System.Linq;
using AppkitSharp.Models.Keys;
using AppkitSharp.Services.Extensions;
using AppkitSharp.Services.Wallet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppkitSharp.Services.Tests
{
    [TestClass]
    public class KeyServiceTests
    {
        private const string TestMnemonic = "roof tenant top resist there enforce young oil language silent invite crucial flash come window";
        private readonly byte[] testEntropy = new byte[] { 187, 187, 227, 147, 219, 190, 6, 148, 127, 212, 206, 124, 249, 13, 216, 26, 53, 134, 92, 62 };

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
        public void CanGeneratePrivateKey()
        {
            IKeyService keyService = new KeyService();
            Mnemonic mnemonic = keyService.Generate();
            var key = mnemonic.GetRootKey();
        }
    }
}
