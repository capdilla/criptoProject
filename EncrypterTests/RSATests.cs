using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSAEncrypter;


namespace EncrypterTests
{
    public class RSATests
    {
        [Test]
        public void getPublicKeyTest()
        {
            RSA client = new RSA();
            String publicKey = client.getPublicKey();
            Boolean hasReturnedSomething = false;
            if (publicKey.Length > 0)
            {
                hasReturnedSomething = true;
                Console.WriteLine("The public Key is " + publicKey);
            }
            Assert.AreEqual(true, hasReturnedSomething);
        }

        public static byte[] HexaToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }


        [Test]
        public void decript()
        {
            RSA client = new RSA();

            string pub = @"-----BEGIN PUBLIC KEY-----
MFwwDQYJKoZIhvcNAQEBBQADSwAwSAJBAKLL1U7AQdefJTr+fAFzC8IRoTqTasPY
RdDPZfGncEGyNXYdEwnXXDlWRldxCRY9d/tfTCqxzWo2BrIdq2gxmSMCAwEAAQ==
-----END PUBLIC KEY-----";

            string priv = @"-----BEGIN RSA PRIVATE KEY-----
MIIBPQIBAAJBAPB5AN8Qlhi/WqVX08TR/k06C5eoBGo6SuDdG1UxhhIiyZ6g5a5G
PpXH5cB587ZDNiMh+AX++9iQ5TvCmHJwfzkCAwEAAQJBAKyt559G1NG+j0QOFmbO
eLNSDEMCBvGVHHHutJLvthvMdOwYUtZ1qEKf1en3wcEybQ1ONmsvWSGWVHVk4zAp
q/UCIQD2OcXLcsoot5iKq02KY8o9MWMDZlLIkbeWTXB971RqAwIhAPoExE4KrTU3
NLjOIdUmK5XRNvwwMRSsTvx0eVIr34sTAiEAnVpKVzwiiWbbKzNSOHCRXA3lstR/
bwIAiyMuEq0SCzUCIQDAII2h0z6LWGMhaPZCz9RKir2QSpBM7KS+B9t7M8/TFQIh
AK5WOa2Ejo/nKGY+DGcmfT78NmFdtGNZpR7lauiqT258
-----END RSA PRIVATE KEY-----";

            string textToDecript = @"7cdc07ed48b36b2ba7006672c82d1f8ad6c680b1c128f172cc17005aeb9b3d97972ead7e8020a0674052dadf239e47dbbd9cf0c5fd28023959c21981a306cefa";

            client.setPrivateKey(priv);
            client.setPublicKey(pub);
            //System.Security.Cryptography.RSACryptoServiceProvider privateKey = RSAPemParser.ImportPrivateKey(priv);

            var bytesPlainTextData = client.Decrypt(HexaToByteArray(textToDecript));
            var plainTextData = System.Text.Encoding.UTF8.GetString(bytesPlainTextData);

            Console.WriteLine(plainTextData);



        }

        [Test]
        public void encript()
        {
            RSA client = new RSA();


            string pub = @"-----BEGIN PUBLIC KEY-----
MFwwDQYJKoZIhvcNAQEBBQADSwAwSAJBAPB5AN8Qlhi/WqVX08TR/k06C5eoBGo6
SuDdG1UxhhIiyZ6g5a5GPpXH5cB587ZDNiMh+AX++9iQ5TvCmHJwfzkCAwEAAQ==
-----END PUBLIC KEY-----";
            string priv = @"-----BEGIN RSA PRIVATE KEY-----
MIIBPQIBAAJBAPB5AN8Qlhi/WqVX08TR/k06C5eoBGo6SuDdG1UxhhIiyZ6g5a5G
PpXH5cB587ZDNiMh+AX++9iQ5TvCmHJwfzkCAwEAAQJBAKyt559G1NG+j0QOFmbO
eLNSDEMCBvGVHHHutJLvthvMdOwYUtZ1qEKf1en3wcEybQ1ONmsvWSGWVHVk4zAp
q/UCIQD2OcXLcsoot5iKq02KY8o9MWMDZlLIkbeWTXB971RqAwIhAPoExE4KrTU3
NLjOIdUmK5XRNvwwMRSsTvx0eVIr34sTAiEAnVpKVzwiiWbbKzNSOHCRXA3lstR/
bwIAiyMuEq0SCzUCIQDAII2h0z6LWGMhaPZCz9RKir2QSpBM7KS+B9t7M8/TFQIh
AK5WOa2Ejo/nKGY+DGcmfT78NmFdtGNZpR7lauiqT258
-----END RSA PRIVATE KEY-----";


            client.setPrivateKey(priv);
            client.setPublicKey(pub);
            //System.Security.Cryptography.RSACryptoServiceProvider privateKey = RSAPemParser.ImportPrivateKey(priv);

            var text = System.Text.Encoding.UTF8.GetBytes("holaaaaa");

            var bytesPlainTextData = client.Encrypt(text);

            var cypherText = BitConverter.ToString(bytesPlainTextData).Replace("-", "");

            Console.WriteLine(cypherText);



        }
    }
}
