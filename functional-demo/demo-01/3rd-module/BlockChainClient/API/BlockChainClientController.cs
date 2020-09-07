using BlockChainClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System.Linq;
using System.Text.Encodings.Web;

namespace BlockChainClient.API
{
    [EnableCors("_allowedSpecificOrigins")]
    [Produces("application/json")]
    [Route("")]
    public class BlockChainClientController : Controller
    {
        //endpoint which creates a new wallet
        [HttpGet("wallet/new")]
        public IActionResult new_wallet()
        {
            var wallet = RSA.RSA.KeyGenerate();
            var rsp = new
            {
                private_key = wallet.PrivateKey,
                public_key = wallet.PublicKey
            };
            
            return Ok(rsp);
        }
        //endpoint where transactions get signed
        [HttpPost("generate/transaction")]
        public IActionResult new_transaction(TransactionClient transaction)
        {
            var sign = RSA.RSA.Sign(transaction.Sender_PrivateKey, transaction.ToString());
            var rsp = new
            {
                transaction = transaction,
                signature = sign
            };

            return Ok(rsp);
        }
    }
}