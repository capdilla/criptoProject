using DataHandlers;
using RSAEncrypter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDESEncrypter;

namespace BusinessProcess
{

    public class SlaveWorkFlow
    {
        private RSA RSAEnrcypter;
        private TDES TDESEncrypter;
        private XMLHandler fileHandler;
        private string rsaPublicKey;
        private string encryptedMessage;
        private TdesV2 tdes2;
        public SlaveWorkFlow()
        {
            this.RSAEnrcypter = new RSA();
            this.TDESEncrypter = new TDES();
            this.fileHandler = new XMLHandler();
            this.tdes2 = new TdesV2();
        }

        public string[] generateRSAKeys()
        {
            string[] keys = new string[2];
            this.rsaPublicKey = this.RSAEnrcypter.getPublicKey();
            keys[0] = this.RSAEnrcypter.getPrivateKey();
            keys[1] = this.rsaPublicKey;
            return keys;
        }
        public void exportRsaPublicKey(string route)
        {
            string pk = this.RSAEnrcypter.getPublicKey();
            Console.WriteLine("The key is: " + pk);
            if (pk != this.rsaPublicKey)
            {
                Console.WriteLine("Cagadinha");
            }
            this.fileHandler.exportRsaPublicKey(route, this.rsaPublicKey);
        }

        public string[] importTdesKeys(string route)
        {
            string[] encryptedTdesKeys = this.fileHandler.readTdesKeys(route);
            byte[][] decrytpedTdesKeys = new byte[3][];
            byte[] encrytpedKeyAsByteArray = new byte[8];
            string[] keysDecripted = new string[3];

            for (int i = 0; i < encryptedTdesKeys.Length; i++)
            {
                encrytpedKeyAsByteArray = HexaToByteArray(encryptedTdesKeys[i]);
                keysDecripted[i] = System.Text.Encoding.UTF8.GetString(this.RSAEnrcypter.Decrypt(encrytpedKeyAsByteArray));
                Console.WriteLine(keysDecripted[i]);
            }


            this.tdes2.key = string.Join("", keysDecripted);
           // this.TDESEncrypter.setKeys(decrytpedTdesKeys[0], decrytpedTdesKeys[1], decrytpedTdesKeys[2]);
            return encryptedTdesKeys;
        }
        public void importInitializationVector(string route)
        {
            string initializationVector = this.fileHandler.readInitializationVector(route);
            byte[] initializationVectorAsByteArray = HexaToByteArray(initializationVector);
            byte[] initializationVectorDecrypted = this.RSAEnrcypter.Decrypt(initializationVectorAsByteArray);


            this.tdes2.iv = System.Text.Encoding.UTF8.GetString(initializationVectorDecrypted);

            //this.TDESEncrypter.setInitializationVector(initializationVectorDecrypted);
        }


        public string decryptTdesKey()
        {
            //   return ByteArrayToHexa(this.TDESEncrypter.getKey());

            return this.tdes2.key;
        }

        public string encryptMessage(string text)
        {
            /*
            byte[] encrytpedText = this.TDESEncrypter.Encrypt(text);
            this.encryptedMessage = ByteArrayToHexa(encrytpedText);
            return this.encryptedMessage;
            */
            this.encryptedMessage = this.tdes2.encrypt(text);
            return this.encryptedMessage;
        }

        public void exportEncryptedMessage(string route)
        {
            this.fileHandler.exportEncrytpedText(route, this.encryptedMessage);
        }
        public string ByteArrayToHexa(byte[] data)
        {
            return BitConverter.ToString(data).Replace("-", "");
        }

        public byte[] HexaToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

    }
}
