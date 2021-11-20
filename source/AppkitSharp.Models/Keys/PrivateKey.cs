using System;
using System.Security.Cryptography;
using System.Text;
using AppkitSharp.Models.Wallet;

namespace AppkitSharp.Models.Keys
{
    public class PrivateKey
    {
        public byte[] KeyBytes { get; private set; }

        public byte[] ChainCode { get; private set; }

        public DerivationPath Path { get; private set; }

        public PrivateKey(byte[] keyBytes, byte[] chainCode, DerivationPath path)
        {
            KeyBytes = keyBytes;
            ChainCode = chainCode;
            Path = path;
        }
        
        public static PrivateKey DeriveMasterKey(byte[] seed)
        {
            byte[] bitcoinSeed = Encoding.UTF8.GetBytes("Bitcoin seed");
            PrivateKey key;
            using (var hmac = new HMACSHA512(bitcoinSeed))
            {
                byte[] hashValue = hmac.ComputeHash(seed);
                key = new PrivateKey(hashValue[Range.EndAt(32)], hashValue[Range.StartAt(32)], DerivationPath.MasterPath);
            }

            return key;
        }

    }
}
