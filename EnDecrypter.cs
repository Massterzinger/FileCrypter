using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCrypter
{
    interface EnDecrypter
    {
        void PerformMutation(ref byte[] fileData, byte[] key);
        byte[] GenerateByteKey(int length);
        IEnumerator<byte> MutKeyString(byte[] Key, int length);
    }
}
