using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSAEncrypter;
using TDESEncrypter;
using DataHandlers;
namespace BusinessProcess
{
    public class MasterWorkFlow
    {
        private RSA RSAEnrcypter;
        private TDES TDESEncrypter;
        private XMLHandler fileHandler;
        private TdesV2 tdes2;

        private string[] TdesKeys;
        private byte[] TdesIV;
        private string message;
        public MasterWorkFlow()
        {
            this.RSAEnrcypter = new RSA();
            this.TDESEncrypter = new TDES();
            this.fileHandler = new XMLHandler();
            this.TdesKeys = new string[3];
            this.TdesIV = new byte[8];
            this.tdes2 = new TdesV2();
        }
        public string[] generateRSAKeys()
        {
            string[] keys = new string[2];
            keys[0] = this.RSAEnrcypter.getPrivateKey();
            keys[1] = this.RSAEnrcypter.getPublicKey();
            return keys;
        }


        public string importRsaPublicKey(string route)
        {
            string publicKey = fileHandler.readRsaPublicKey(route);
            //After reading, lets set the key to the rsa
            this.RSAEnrcypter.setPublicKey(publicKey);
            return publicKey;
        }

        public string generateTdesKeys()
        {
            /*
            byte[] TdesKey = this.TDESEncrypter.generateKey();
            this.TDESEncrypter.generateInitializationVector();
            return ByteArrayToHexa(TdesKey);
            */

            return this.tdes2.key;
        }

        public string getTdesKey()
        {
            byte[] TdesKey = this.TDESEncrypter.getKey();
            return ByteArrayToHexa(TdesKey);
        }

        public string[] encryptTdesKeys()
        {
            byte[][] keysAsByteArray = this.TDESEncrypter.getKeys();
            byte[] encryptedKey;

            string[] keys = this.tdes2.SplitKey(16);

            string[] keyss = { "78415115453E5B29", "7777140F2273501B", "13072F6D1B475F2A" };

            for (int i = 0; i < keys.Length; i++)
            {



                var text = System.Text.Encoding.UTF8.GetBytes(keys[i]);


                //   Console.WriteLine(ByteArrayToHexa(keysAsByteArray[i]).ToString());

                //                encryptedKey = this.RSAEnrcypter.Encrypt(keysAsByteArray[i]);
                var bytesPlainTextData = this.RSAEnrcypter.Encrypt(text);


                var cypherText = BitConverter.ToString(bytesPlainTextData).Replace("-", "");

                //this.TdesKeys[i] = ByteArrayToHexa(encryptedKey);
                this.TdesKeys[i] = cypherText;
            }
            return this.TdesKeys;
        }

        public void exportTdesKeysToXml(string route)
        {
            var text = System.Text.Encoding.UTF8.GetBytes(this.tdes2.iv);
            byte[] IVEncrypted = this.RSAEnrcypter.Encrypt(text);
            String IVasHexa = ByteArrayToHexa(IVEncrypted);
            
            this.fileHandler.exportTdesKeys(route, this.TdesKeys, IVasHexa);
        }

        public string importEncryptedMessage(string route)
        {
            this.message = this.fileHandler.readEncryptedText(route);
            return this.message;
        }

        public string decryptMessage()
        {
            /*
            byte[] encryptedMessageAsByteArray = HexaToByteArray(this.message);
            byte[] decryptedMessageAsByteArray = this.TDESEncrypter.Decrypt(encryptedMessageAsByteArray);
            return new ASCIIEncoding().GetString(decryptedMessageAsByteArray);
            */

            return this.tdes2.decrypt(this.message);
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
