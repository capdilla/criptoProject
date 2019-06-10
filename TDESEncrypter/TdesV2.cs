using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;

namespace TDESEncrypter
{
    public class TdesV2
    {

        public string key { get; set; }
        public string iv { get; set; }

        public TdesV2()
        {
            this.generateKey();
            this.generateIV();
        }

        public string generateKey()
        {
            Random rnd = new Random();
            byte[] _key = new byte[24];

            for (int i = 0; i < _key.Length; i++)
            {
                _key[i] = (byte)rnd.Next(128);
            }

            this.key = ByteArrayToString(_key);

            return this.key;
        }


        public string generateIV()
        {
            Random rnd = new Random();
            byte[] _iv = new byte[8];

            for (int i = 0; i < _iv.Length; i++)
            {
                _iv[i] = (byte)rnd.Next(128);
            }

            this.iv = ByteArrayToString(_iv);

            return this.iv;
        }

        public string[] SplitKey(int chunkSize)
        {
            return Enumerable.Range(0, key.Length / chunkSize)
                .Select(i => key.Substring(i * chunkSize, chunkSize)).ToArray<string>();
        }

        public string encrypt(string text)
        {
            Console.WriteLine(this.key);
            return crypto(text, this.key, this.iv, "encrypt");
        }

        public string decrypt(string text)
        {
            return crypto(text, this.key, this.iv, "decrypt");
        }

        public string crypto(string text, string key, string iv, string type)
        {

            Console.WriteLine(iv);
            byte[] results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            MD5CryptoServiceProvider hashProvider = new MD5CryptoServiceProvider();
            TripleDESCryptoServiceProvider tripDES = new TripleDESCryptoServiceProvider();

            // MD5 the key
            //byte[] tdeskey = hashProvider.ComputeHash(UTF8Encoding.UTF8.GetBytes(key)); //hashProvider.ComputeHash(UTF8.GetBytes(key));

            // Set Key
            tripDES.Key = Enumerable.Range(0, key.Length)
                    .Where(x => x % 2 == 0)
                    .Select(x => Convert.ToByte(key.Substring(x, 2), 16)).ToArray();

            // Set IV
            tripDES.IV = Enumerable.Range(0, iv.Length)
                    .Where(x => x % 2 == 0)
                    .Select(x => Convert.ToByte(iv.Substring(x, 2), 16)).ToArray();

            // Use ECB for mode
            tripDES.Mode = CipherMode.ECB;

            // Zero Padding
            tripDES.Padding = PaddingMode.Zeros;

            byte[] data = null;
            ICryptoTransform enc = null;

            switch (type)
            {
                case "encrypt":
                    enc = tripDES.CreateEncryptor();

                    data = Encoding.ASCII.GetBytes(text);
                    break;

                case "decrypt":
                    enc = tripDES.CreateDecryptor();
                    data = Enumerable.Range(0, text.Length)
                    .Where(x => x % 2 == 0)
                    .Select(x => Convert.ToByte(text.Substring(x, 2), 16)).ToArray();
                    break;
            }

            try
            {
                results = enc.TransformFinalBlock(data, 0, data.Length);
            }
            finally
            {
                tripDES.Clear();
                hashProvider.Clear();
            }

            if (type == "decrypt")
                return Encoding.UTF8.GetString(results).TrimEnd('\0');//Encoding.ASCII.GetString(results);
            else
            {
                return BitConverter.ToString(results).Replace("-", "");
                //return ByteArrayToString(results);
            }

        }

        public string ByteArrayToString(byte[] byteArray)
        {
            var hex = new StringBuilder(byteArray.Length * 2);
            foreach (var b in byteArray)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }

}

