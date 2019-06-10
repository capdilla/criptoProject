using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace TDESEncrypter
{
    public class TDES
    {
        private byte[] key;        
        private byte[] initializationVector;
        private TripleDESCryptoServiceProvider ecrypterServiceProvider;
        private Random rnd;
        
        public TDES()
        {
            this.rnd = new Random();
            this.key = new byte[24];
            this.initializationVector = new byte[8];
            this.ecrypterServiceProvider = new TripleDESCryptoServiceProvider();
        }
        public byte[] generateKey()
        {
            for (int i = 0; i < this.key.Length; i++)
            {
                this.key[i] = (byte)rnd.Next(128);
            }
            return this.key;
        }
        public byte [] getKey()
        {
            return this.key;
        }
        public byte[] setKeys(byte[] key1, byte[] key2, byte[] key3)
        {
            //First, lets zero extend the Kee, just in case the 
            //sum of the keys lenght gives less than 24
            zeroExtend(this.key);
            key1.CopyTo(this.key, 0);
            key2.CopyTo(this.key, key1.Length);
            key3.CopyTo(this.key, (key1.Length + key2.Length));
            return this.key;
        }

        public byte[][] getKeys()
        {
            byte[][] keys = new byte[3][];
            keys[0] = this.key.Take(8).ToArray();
            keys[1] = this.key.Skip(8).Take(8).ToArray();
            keys[2] = this.key.Skip(16).Take(8).ToArray();
            
            return keys;
        }

        public byte[] generateInitializationVector()
        {
            for (int i = 0; i < this.initializationVector.Length; i++)
            {
                this.initializationVector[i] = (byte)rnd.Next(128);
            }
            return this.initializationVector;
        }

        public byte[] getInitializationVector()
        {
            return this.initializationVector;
        }

        public void setInitializationVector(byte [] iv)
        {
            this.initializationVector = iv;
        }

        public byte[] Encrypt(string Data)
        {
            try
            {
                // Create a MemoryStream.
                MemoryStream memoryStream = new MemoryStream();
                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream criptoStream = new CryptoStream(memoryStream, this.ecrypterServiceProvider.CreateEncryptor(this.key, this.initializationVector),
                    CryptoStreamMode.Write);

                // Convert the passed string to a byte array.
                byte[] stringAsByteArray = new ASCIIEncoding().GetBytes(Data);

                // Write the byte array to the crypto stream and flush it.
                criptoStream.Write(stringAsByteArray, 0, stringAsByteArray.Length);
                criptoStream.FlushFinalBlock();

                // Get an array of bytes from the 
                // MemoryStream that holds the 
                // encrypted data.
                byte[] dataEncrypted = memoryStream.ToArray();

                // Close the streams.
                criptoStream.Close();
                criptoStream.Close();

                // Return the encrypted buffer.
                return dataEncrypted;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }

        public byte[] Decrypt(byte[] Data)
        {            
            try
            {
                // Create a new MemoryStream using the passed 
                // array of encrypted data.
                MemoryStream memoryStream = new MemoryStream(Data);
                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                    this.ecrypterServiceProvider.CreateDecryptor(this.key, this.initializationVector), CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data.
                byte[] decryptedData = new byte[Data.Length];

                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                cryptoStream.Read(decryptedData, 0, decryptedData.Length);
                return decryptedData;                
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }

        public void zeroExtend(byte [] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = 0;
            }
        }
    }
}
