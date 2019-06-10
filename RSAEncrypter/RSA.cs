using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RSAEncrypter
{

    public class RSA
    {
        private RSACryptoServiceProvider CrytpServiceProvider;
        private RSACryptoServiceProvider PrivateKey;
        private RSACryptoServiceProvider PublicKey;
        public RSA()
        {
            this.CrytpServiceProvider = new RSACryptoServiceProvider(512);

            //PrivateKey = RSAPemParser.ImportPrivateKey(this.getPrivateKey());
            //PublicKey = RSAPemParser.ImportPrivateKey(this.getPublicKey());
            this.setPrivateKey(RSAPemParser.ExportPrivateKey(this.CrytpServiceProvider));
        }

        public byte[] Encrypt(byte[] DataToEncrypt)
        {
            return this.PublicKey.Encrypt(DataToEncrypt, false);
        }

        public byte[] Decrypt(byte[] DataToDecrypt)
        {

            //var privateKey = RSAPemParser.ImportPrivateKey(this.getPrivateKey());

            //Console.WriteLine(this.getPrivateKey());

            return this.PrivateKey.Decrypt(DataToDecrypt, false);
            //return this.CrytpServiceProvider.Decrypt(DataToDecrypt, true);
        }

        public string getPublicKey()
        {

            return RSAPemParser.ExportPublicKey(this.CrytpServiceProvider);
            //return this.CrytpServiceProvider.ToXmlString(false);            
        }
        public string getPrivateKey()
        {

            return RSAPemParser.ExportPrivateKey(this.CrytpServiceProvider);
            //return this.CrytpServiceProvider.ToXmlString(true);
        }

        public void setPublicKey(string publicKey)
        {

            string pub = @"-----BEGIN PUBLIC KEY-----
MFwwDQYJKoZIhvcNAQEBBQADSwAwSAJBAKxtGGN7xyVbla0mT1FLwzEK0naW1lfD
B/VtArLtq5/pVQU5+0Ku8gE2hwsiCodOcVfdw+Vg0axkcVT9bovnTIECAwEAAQ==
-----END PUBLIC KEY-----";
            this.PublicKey = RSAPemParser.ImportPublicKey(publicKey);
            // this.CrytpServiceProvider.FromXmlString(publicKey);
        }

        public void setPrivateKey(String privateKey)
        {
            this.PrivateKey = RSAPemParser.ImportPrivateKey(privateKey);
            // this.CrytpServiceProvider.FromXmlString(publicKey);
        }
    }
}
