using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncrypterTests
{

    class TDESTests
    {
        public static byte[] HexaToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        [Test]
        public void testEncryption()
        {

            TDESEncrypter.TDES tdes = new TDESEncrypter.TDES();


            string key = "153b07d1c925edca7f8d8431c9d32bd05ed22ed83be3aadb";
            string iv = "c4cb5939841c4352";


            var keys = HexaToByteArray(key);
            var key1 = keys.Take(8).ToArray();
            var key2 = keys.Skip(8).Take(8).ToArray();
            var key3 = keys.Skip(16).Take(8).ToArray();


            tdes.setKeys(key1, key2, key3);
            tdes.setInitializationVector(HexaToByteArray(iv));

            var en = tdes.Encrypt("hola");
            var textHex = BitConverter.ToString(en).Replace("-", "");

            Console.WriteLine(textHex);

        }

        [Test]
        public void testDecript()
        {

            TDESEncrypter.TDES tdes = new TDESEncrypter.TDES();


            string key = "153b07d1c925edca7f8d8431c9d32bd05ed22ed83be3aadb";
            string iv = "c4cb5939841c4352";


            var keys = HexaToByteArray(key);
            var key1 = keys.Take(8).ToArray();
            var key2 = keys.Skip(8).Take(8).ToArray();
            var key3 = keys.Skip(16).Take(8).ToArray();


            tdes.setKeys(key1, key2, key3);
            tdes.setInitializationVector(HexaToByteArray(iv));


            var bytes = HexaToByteArray("052fc885070145fd");
            Console.WriteLine(bytes.ToString());
            var de = tdes.Decrypt(bytes);

            var textHex = System.Text.Encoding.UTF8.GetString(de);

            Console.WriteLine(textHex);


        }


        [Test]

        public void tdes2()
        {
            TDESEncrypter.TdesV2 tdes2 = new TDESEncrypter.TdesV2();

            tdes2.generateIV();
            tdes2.generateKey();

            string en = tdes2.encrypt("hola");

            Console.WriteLine(en);

            string de = tdes2.decrypt(en);

            
            Console.WriteLine(de);

            Console.WriteLine("[{0}]", string.Join(", ", tdes2.SplitKey(16)));
        }
    }
}

