namespace AppkitSharp.Models.Configuration
{
    public class ErgoNodeConfig
    {
        public ApiConfig ApiConfig { get; set; }

        public WalletConfig WalletConfig { get; set; }

        public NetworkType NetworkType { get; set; }
    }

    public class ApiConfig
    {
        public string ApiUrl { get; set; }

        public string ApiKey { get; set; }
    }

    public class WalletConfig
    {
        public string Mnemonic { get; set; }

        public string Password { get; set; }

        public string MnemonicPassword { get; set; }
    }
}
