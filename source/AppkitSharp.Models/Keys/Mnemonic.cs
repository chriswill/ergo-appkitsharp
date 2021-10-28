namespace AppkitSharp.Models.Keys
{
    public class Mnemonic
    {
        public string Words { get; }
        public byte[] Entropy { get; }

        

        public Mnemonic(string words, byte[] entropy)
        {
            Words = words;
            Entropy = entropy;
        }

        public string ToSeed(string password, string options)
        {
            var Pbkdf2Algorithm = "PBKDF2WithHmacSHA512";
            var Pbkdf2Iterations = 2048; // number of iteration specified in BIP39 standard.
            var Pbkdf2KeyLength = 512;
        }
    }
}
