using AppkitSharp.Models.Addresses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppkitSharp.Models.Tests
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        public void CanParseMainnetAddress()
        {
            IErgoAddress address = new P2PKAddress("9fRusAarL1KkrWQVsxSRVYnvWxaAT2A96cKtNn9tvPh5XUyCisr");
            Assert.AreEqual("9fRusAarL1KkrWQVsxSRVYnvWxaAT2A96cKtNn9tvPh5XUyCisr", address.Address);
            Assert.AreEqual("0008cd0278011ec0cf5feb92d61adb51dcb75876627ace6fd9446ab4cabc5313ab7b39a7", address.ErgoTree);
            Assert.AreEqual("1, 2, 120, 1, 30, 192, 207, 95, 235, 146, 214, 26, 219, 81, 220, 183, 88, 118, 98, 122, 206, 111, 217, 68, 106, 180, 202, 188, 83, 19, 171, 123, 57, 167, 48, 4, 126, 225", string.Join(", ", address.AddressBytes));
            Assert.AreEqual("2, 120, 1, 30, 192, 207, 95, 235, 146, 214, 26, 219, 81, 220, 183, 88, 118, 98, 122, 206, 111, 217, 68, 106, 180, 202, 188, 83, 19, 171, 123, 57, 167", string.Join(", ", address.PublicKey));
            Assert.AreEqual(NetworkType.Mainnet, address.Network);
            Assert.AreEqual(AddressType.PayToPublicKey, address.AddressType);
            Assert.IsTrue(address.IsValid());
            Assert.IsInstanceOfType(address, typeof(P2PKAddress));
        }

        [TestMethod]
        public void CanParseTestnetAddress()
        {
            IErgoAddress address = new P2PKAddress("3WvsT2Gm4EpsM9Pg18PdY6XyhNNMqXDsvJTbbf6ihLvAmSb7u5RN");
            //Assert.AreEqual("9fRusAarL1KkrWQVsxSRVYnvWxaAT2A96cKtNn9tvPh5XUyCisr", address.Address);
            //Assert.AreEqual("0008cd0278011ec0cf5feb92d61adb51dcb75876627ace6fd9446ab4cabc5313ab7b39a7", address.ErgoTree);
            //Assert.AreEqual("1, 2, 120, 1, 30, 192, 207, 95, 235, 146, 214, 26, 219, 81, 220, 183, 88, 118, 98, 122, 206, 111, 217, 68, 106, 180, 202, 188, 83, 19, 171, 123, 57, 167, 48, 4, 126, 225", string.Join(", ", address.AddressBytes));
            //Assert.AreEqual("2, 120, 1, 30, 192, 207, 95, 235, 146, 214, 26, 219, 81, 220, 183, 88, 118, 98, 122, 206, 111, 217, 68, 106, 180, 202, 188, 83, 19, 171, 123, 57, 167", string.Join(", ", address.PublicKey));
            Assert.AreEqual(NetworkType.Testnet, address.Network);
            Assert.AreEqual(AddressType.PayToPublicKey, address.AddressType);
            Assert.IsTrue(address.IsValid());
            Assert.IsInstanceOfType(address, typeof(P2PKAddress));
        }

        [TestMethod]
        public void CanParseMainnetP2ShAddress()
        {
            IErgoAddress address = new P2PKAddress("8UApt8czfFVuTgQmMwtsRBZ4nfWquNiSwCWUjMg");
            //Assert.AreEqual("9fRusAarL1KkrWQVsxSRVYnvWxaAT2A96cKtNn9tvPh5XUyCisr", address.Address);
            //Assert.AreEqual("0008cd0278011ec0cf5feb92d61adb51dcb75876627ace6fd9446ab4cabc5313ab7b39a7", address.ErgoTree);
            //Assert.AreEqual("1, 2, 120, 1, 30, 192, 207, 95, 235, 146, 214, 26, 219, 81, 220, 183, 88, 118, 98, 122, 206, 111, 217, 68, 106, 180, 202, 188, 83, 19, 171, 123, 57, 167, 48, 4, 126, 225", string.Join(", ", address.AddressBytes));
            //Assert.AreEqual("2, 120, 1, 30, 192, 207, 95, 235, 146, 214, 26, 219, 81, 220, 183, 88, 118, 98, 122, 206, 111, 217, 68, 106, 180, 202, 188, 83, 19, 171, 123, 57, 167", string.Join(", ", address.PublicKey));
            Assert.AreEqual(NetworkType.Mainnet, address.Network);
            Assert.AreEqual(AddressType.PayToScriptHash, address.AddressType);
            Assert.IsTrue(address.IsValid());
            Assert.IsInstanceOfType(address, typeof(P2PKAddress));
        }

        [TestMethod]
        public void CanParseTestnetP2ShAddress()
        {
            IErgoAddress address = new P2PKAddress("rbcrmKEYduUvADj9Ts3dSVSG27h54pgrq5fPuwB");
            //Assert.AreEqual("9fRusAarL1KkrWQVsxSRVYnvWxaAT2A96cKtNn9tvPh5XUyCisr", address.Address);
            //Assert.AreEqual("0008cd0278011ec0cf5feb92d61adb51dcb75876627ace6fd9446ab4cabc5313ab7b39a7", address.ErgoTree);
            //Assert.AreEqual("1, 2, 120, 1, 30, 192, 207, 95, 235, 146, 214, 26, 219, 81, 220, 183, 88, 118, 98, 122, 206, 111, 217, 68, 106, 180, 202, 188, 83, 19, 171, 123, 57, 167, 48, 4, 126, 225", string.Join(", ", address.AddressBytes));
            //Assert.AreEqual("2, 120, 1, 30, 192, 207, 95, 235, 146, 214, 26, 219, 81, 220, 183, 88, 118, 98, 122, 206, 111, 217, 68, 106, 180, 202, 188, 83, 19, 171, 123, 57, 167", string.Join(", ", address.PublicKey));
            Assert.AreEqual(NetworkType.Testnet, address.Network);
            Assert.AreEqual(AddressType.PayToScriptHash, address.AddressType);
            Assert.IsTrue(address.IsValid());
            Assert.IsInstanceOfType(address, typeof(P2PKAddress));
        }

        [TestMethod]
        public void CanParseMainnetP2SAddress()
        {
            IErgoAddress address = new P2PKAddress("4MQyML64GnzMxZgm, BxKBaHkvrTvLZrDcZjcsxsF7aSsrN73ijeFZXtbj4CXZHHcvBtqSxQ");
            //Assert.AreEqual("9fRusAarL1KkrWQVsxSRVYnvWxaAT2A96cKtNn9tvPh5XUyCisr", address.Address);
            //Assert.AreEqual("0008cd0278011ec0cf5feb92d61adb51dcb75876627ace6fd9446ab4cabc5313ab7b39a7", address.ErgoTree);
            //Assert.AreEqual("1, 2, 120, 1, 30, 192, 207, 95, 235, 146, 214, 26, 219, 81, 220, 183, 88, 118, 98, 122, 206, 111, 217, 68, 106, 180, 202, 188, 83, 19, 171, 123, 57, 167, 48, 4, 126, 225", string.Join(", ", address.AddressBytes));
            //Assert.AreEqual("2, 120, 1, 30, 192, 207, 95, 235, 146, 214, 26, 219, 81, 220, 183, 88, 118, 98, 122, 206, 111, 217, 68, 106, 180, 202, 188, 83, 19, 171, 123, 57, 167", string.Join(", ", address.PublicKey));
            Assert.AreEqual(NetworkType.Mainnet, address.Network);
            Assert.AreEqual(AddressType.PayToScript, address.AddressType);
            Assert.IsTrue(address.IsValid());
            Assert.IsInstanceOfType(address, typeof(P2PKAddress));
        }

        [TestMethod]
        public void CanParseTestnetP2SAddress()
        {
            IErgoAddress address = new P2PKAddress("Ms7smJwLGbUAjuWQ");
            //Assert.AreEqual("9fRusAarL1KkrWQVsxSRVYnvWxaAT2A96cKtNn9tvPh5XUyCisr", address.Address);
            //Assert.AreEqual("0008cd0278011ec0cf5feb92d61adb51dcb75876627ace6fd9446ab4cabc5313ab7b39a7", address.ErgoTree);
            //Assert.AreEqual("1, 2, 120, 1, 30, 192, 207, 95, 235, 146, 214, 26, 219, 81, 220, 183, 88, 118, 98, 122, 206, 111, 217, 68, 106, 180, 202, 188, 83, 19, 171, 123, 57, 167, 48, 4, 126, 225", string.Join(", ", address.AddressBytes));
            //Assert.AreEqual("2, 120, 1, 30, 192, 207, 95, 235, 146, 214, 26, 219, 81, 220, 183, 88, 118, 98, 122, 206, 111, 217, 68, 106, 180, 202, 188, 83, 19, 171, 123, 57, 167", string.Join(", ", address.PublicKey));
            Assert.AreEqual(NetworkType.Testnet, address.Network);
            Assert.AreEqual(AddressType.PayToScript, address.AddressType);
            Assert.IsTrue(address.IsValid());
            Assert.IsInstanceOfType(address, typeof(P2PKAddress));
        }

        [TestMethod]
        public void CanCreateAddressFromBase58()
        {
            IErgoAddress address = ErgoAddress.FromBase58("9fRusAarL1KkrWQVsxSRVYnvWxaAT2A96cKtNn9tvPh5XUyCisr");
            Assert.AreEqual("9fRusAarL1KkrWQVsxSRVYnvWxaAT2A96cKtNn9tvPh5XUyCisr", address.Address);
            Assert.AreEqual("0008cd0278011ec0cf5feb92d61adb51dcb75876627ace6fd9446ab4cabc5313ab7b39a7", address.ErgoTree);
            Assert.AreEqual("1, 2, 120, 1, 30, 192, 207, 95, 235, 146, 214, 26, 219, 81, 220, 183, 88, 118, 98, 122, 206, 111, 217, 68, 106, 180, 202, 188, 83, 19, 171, 123, 57, 167, 48, 4, 126, 225", string.Join(", ", address.AddressBytes));
            Assert.AreEqual("2, 120, 1, 30, 192, 207, 95, 235, 146, 214, 26, 219, 81, 220, 183, 88, 118, 98, 122, 206, 111, 217, 68, 106, 180, 202, 188, 83, 19, 171, 123, 57, 167", string.Join(", ", address.PublicKey));
            Assert.AreEqual(NetworkType.Mainnet, address.Network);
            Assert.AreEqual(AddressType.PayToPublicKey, address.AddressType);
            Assert.IsTrue(address.IsValid());
            Assert.IsInstanceOfType(address, typeof(P2PKAddress));
        }

        [TestMethod]
        public void CanCreateAddressFromErgoTree()
        {
            IErgoAddress address =
                ErgoAddress.FromErgoTree("0008cd0278011ec0cf5feb92d61adb51dcb75876627ace6fd9446ab4cabc5313ab7b39a7");
            Assert.AreEqual("9fRusAarL1KkrWQVsxSRVYnvWxaAT2A96cKtNn9tvPh5XUyCisr", address.Address);
            Assert.AreEqual("0008cd0278011ec0cf5feb92d61adb51dcb75876627ace6fd9446ab4cabc5313ab7b39a7", address.ErgoTree);
            Assert.AreEqual("1, 2, 120, 1, 30, 192, 207, 95, 235, 146, 214, 26, 219, 81, 220, 183, 88, 118, 98, 122, 206, 111, 217, 68, 106, 180, 202, 188, 83, 19, 171, 123, 57, 167, 48, 4, 126, 225", string.Join(", ", address.AddressBytes));
            Assert.AreEqual("2, 120, 1, 30, 192, 207, 95, 235, 146, 214, 26, 219, 81, 220, 183, 88, 118, 98, 122, 206, 111, 217, 68, 106, 180, 202, 188, 83, 19, 171, 123, 57, 167", string.Join(", ", address.PublicKey));
            Assert.AreEqual(NetworkType.Mainnet, address.Network);
            Assert.AreEqual(AddressType.PayToPublicKey, address.AddressType);
            Assert.IsTrue(address.IsValid());
            Assert.IsInstanceOfType(address, typeof(P2PKAddress));
        }

    }
}
