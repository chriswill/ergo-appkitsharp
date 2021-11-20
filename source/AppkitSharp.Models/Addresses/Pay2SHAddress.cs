using System;
using System.Collections.Generic;
using System.Text;
using AppkitSharp.Common;

namespace AppkitSharp.Models.Addresses
{
    public class Pay2SHAddress : IErgoAddress
    {
        public byte AddressTypePrefix => Constants.PayToScriptHashAddress;

        public byte[] AddressBytes { get; set; }
        public byte NetworkPrefix { get; set; }
    }
}
