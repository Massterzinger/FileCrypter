using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCrypter
{
    class CryptionClass : EnDecrypter
    {
        public byte[] GenerateByteKey(int length)
        {
            throw new NotImplementedException();
        }

        public char[] GenerateCharKey(int length)
        {
            throw new NotImplementedException();
        }

        public void PerformMutaion(ref byte[] fileData, byte[] key)
        {
            throw new NotImplementedException();
        }
    }
}
