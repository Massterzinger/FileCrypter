using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCrypter
{
    class CryptionClass : EnDecrypter
    {
        Random r;
        public CryptionClass()
        {
            r = new Random();
        }
        public byte[] GenerateByteKey(int length)
        {
            
            byte[] Key = new byte[length];
            for (int i = 0; i < Key.Length; i++)
            {
                Key[i] = (byte)r.Next(50, 250);
            }
            //r.NextBytes(Key);
            return Key;
        }

        public IEnumerator<byte> MutKeyString(byte[] Key, int length)
        {
            int j = 0;
            for (int i = 0; i < length; i++)
            {
                if (j == Key.Length) j = 0;
                yield return Key[j];
            }
            
        }
        
        public void PerformMutation(ref byte[] fileData, byte[] key)
        {
            var A = MutKeyString(key, fileData.Length);
            for (int i = 0; i < fileData.Length; i++)
            {
                fileData[i] ^= A.Current;
                A.MoveNext();
            }
        }
    }
}
