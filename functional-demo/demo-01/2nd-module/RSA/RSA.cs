using NBitcoin;
using System;

namespace RSA
{
    public static class RSA
    {
        //Using Bitcoin network, the function below generates public and private keys
        public static Wallet KeyGenerate()
        {
            Key privateKey = new Key();

            var value = privateKey.PubKey.GetAddress(ScriptPubKeyType.Legacy, Network.Main);
            var address = BitcoinAddress.Create(value.ToString(), Network.Main);

            return new Wallet { PublicKey = value.ToString(), 
                                PrivateKey = privateKey.GetBitcoinSecret(Network.Main).ToString()
                            };
        }

        //Method responsable to sign
        public static string Sing(string privKey, string msgToSign)
        {
            //var address = BitcoinAddress.Create(pubKey, Network.Main);
            //var pkh = (address as IPubkeyHashUsable); //pay to pubkey hash

            var secret = Network.Main.CreateBitcoinSecret(privKey);
            var signature = secret.PrivateKey.SignMessage(msgToSign);
            //var bol = pkh.VerifyMessage(msgToSign, signature);
            var value = secret.PubKey.VerifyMessage(msgToSign, signature);
            return signature;
        }

        //Function whichs verify the signature
        public static bool Verify(string pbKey, string originalMessage, string signedMessage)
        {
            var address = BitcoinAddress.Create(pbKey, Network.Main);
            var phk = (address as IPubkeyHashUsable); //pay to pubkey has

            var bol = phk.VerifyMessage(originalMessage, signedMessage);

            return bol;
        }

    }
}
