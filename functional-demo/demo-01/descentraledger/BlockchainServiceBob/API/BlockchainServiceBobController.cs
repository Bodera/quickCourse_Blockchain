using BlockchainServiceBob.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System.Linq;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Http;

namespace BlockchainServiceBob.API
{
    [EnableCors("_allowedSpecificOrigins")]
    [Produces("application/json")]
    [ApiController]
    [Route("")]
    public class BlockchainServiceBobController : Controller
    {
        public static CryptoCurrency blockchain = new CryptoCurrency();

        //endpoint which creates a new transaction
        [HttpPost("transactions/new")]
        public IActionResult new_transaction([FromBody]Transaction transaction)
        {
            var rsp = blockchain.CreateTransaction(transaction);
            return Ok(rsp);
        }
        //endpoint which retrieves all transactions
        [HttpGet("transactions/get")]
        public IActionResult get_transactions()
        {
            var rsp = new { transactions = blockchain.GetTransactions() };
            return Ok(rsp);
        }
        //endpoint which retrieves all blocks on the chain
        [HttpGet("chain")]
        public IActionResult full_chain()
        {
            var blocks = blockchain.GetBlocks();
            var rsp = new { chain = blocks, length = blocks.Count };
            return Ok(rsp);
        }
        //endpoint where happens transaction mining and block aggregation to the network
        [HttpGet("mine")]
        public IActionResult mine()
        {
            var block = blockchain.Mine();
            var rsp = new
            {
                message = "New Block Forged",
                block_number = block.Index,
                transactions = block.Transactions.ToArray(),
                nonce = block.Proof,
                previous_hash = block.PreviousHash
            };

            return Ok(rsp);
        }
        //endpoint which adds miners to the network
        [HttpPost("nodes/register")]
        public IActionResult register_nodes(string[] nodes) //{"Urls": ["localhost:54321", "localhost:12321"]}
        {
            blockchain.RegisterNodes(nodes);
            var rsp = new
            {
                message = "New nodes have been added",
                total_nodes = nodes.Count() //'total_nodes': [node for node in blockchain.nodes]
            };

            return Created("", rsp);
        }
        //endpoint which resolves conflicts on the blockchain
        [HttpGet("nodes/resolve")]
        public IActionResult consensus()
        {
            return Ok(blockchain.Consensus());
        }
        //endpoint which retrieves all connected nodes on the network
        [HttpGet("nodes/get")]
        public IActionResult get_nodes()
        {
            return Ok(new { nodes = blockchain.GetNodes() });
        }
        //endpoint which retrieves the miners keys (private and public)
        [HttpGet("wallet/miner")]
        public IActionResult get_miners_wallet()
        {
            return Ok(blockchain.GetMinersWallet());
        }
    }
}