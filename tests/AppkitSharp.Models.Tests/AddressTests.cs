using AppkitSharp.Models.Addresses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppkitSharp.Services.Tests
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        public void CanCreateAddress()
        {
            IErgoAddress address = ErgoAddress.FromBase58("9fRusAarL1KkrWQVsxSRVYnvWxaAT2A96cKtNn9tvPh5XUyCisr");
            address = ErgoAddress.FromBase58("3WxxVQqxoVSWEKG5B73eNttBX51ZZ6WXLW7fiVDgCFhzRK8R4gmk");
        }

    }
}
