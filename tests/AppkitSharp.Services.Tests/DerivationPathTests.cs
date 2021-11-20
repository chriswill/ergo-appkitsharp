using System;
using AppkitSharp.Models.Wallet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppkitSharp.Services.Tests
{
    [TestClass]
    public class DerivationPathTests
    {
        [TestMethod]
        public void IsEip3ShouldBeCorrect()
        {
            Assert.IsTrue(DerivationPath.FromPath("m/44'/429'/0'/0/0").IsEip3());
            Assert.IsTrue(DerivationPath.FromPath("m/44'/429'/0'/0/0").ToPublicBranch().IsEip3());
            Assert.IsTrue(DerivationPath.FromPath("m/44'/429'/0'/0/1").IsEip3());
            //Assert.IsTrue(DerivationPath.FromPath("M/44'/429'/0'/0/1").IsEip3());
            //Assert.IsTrue(DerivationPath.FromPath("M/44'/429'/0'/0/1").IsPublicBranch);
            Assert.IsTrue(DerivationPath.FromPath("m/44'/429'/0'/1/1").IsEip3());
            //Assert.ThrowsException<InvalidOperationException>(() => DerivationPath.FromPath("m/1"));
            Assert.IsFalse(DerivationPath.FromPath("m/44'/429'/1'/0/1").IsEip3());
            Assert.IsTrue(DerivationPath.FromPath("m/44'/429'/0'/0/1").Index == 1);
        }
    }
}
