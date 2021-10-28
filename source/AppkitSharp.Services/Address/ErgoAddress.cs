using System;
using System.Collections.Generic;
using System.Text;

namespace AppkitSharp.Services.Address
{
    public abstract class ErgoAddress
    {
        public abstract byte AddressTypePrefix { get; }

        public abstract byte[] ContentBytes { get; }


    }
}
