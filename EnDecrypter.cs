using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCrypter
{
    interface EnDecrypter
    {
        void PerformMutaion(ref byte[] fileData, byte[] key);
        byte[] GenerateByteKey(int length);
        char[] GenerateCharKey(int length);
    }
}
