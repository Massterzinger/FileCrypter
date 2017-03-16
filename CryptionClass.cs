using System;
using System.Collections.Generic;

namespace FileCrypter
{
    class CryptionClass : IEnDecrypter
    {
        public delegate void ProgressChangedEventHandler(object sender, EventArgs e);
        public delegate void ProgressStartedEventHandler(object sender, EventArgs e);
        public delegate void ProgressEndedEventHandler(object sender, EventArgs e);

        public event ProgressChangedEventHandler ProgressChanged;
        public event ProgressStartedEventHandler ProgressStarted;
        public event ProgressEndedEventHandler ProgressEnded;


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
            for (int i = 0; i < length; i++)
            {
                yield return (byte)(Key[i % Key.Length] ^ (byte)(240-(i % 128)));
            }
        }
        
        public void PerformMutation(ref byte[] fileData, byte[] key)
        {
            OnProgressStarted();
            var A = MutKeyString(key, fileData.Length);
            int ChunkSize = fileData.Length / 100;
            for (int i = 0; i < fileData.Length; i++, A.MoveNext())
            {
                fileData[i] ^= A.Current;
                if( i % ChunkSize == 0)
                {
                    //Call Event
                    OnProgressChanged();
                }
            }
            OnProgressEnded();
        }
        protected virtual void OnProgressChanged()
        {
            ProgressChanged?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnProgressStarted()
        {
            ProgressStarted?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnProgressEnded()
        {
            ProgressEnded?.Invoke(this, EventArgs.Empty);
        }
    }
}
