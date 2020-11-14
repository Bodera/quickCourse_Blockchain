using System.Security.Cryptography;
using Newtonsoft.Json;
using RSA;
using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace BlockchainServiceBob.Models
{
    public class CryptoCurrency
    {
        private List<Transaction> _currentTransactions = new List<Transaction>();
        private List<Block>  _chain = new List<Block>();
        private List<Node> _nodes = new List<Node>();
        private Block _lastBlock => _chain.Last();

        public string NodeId { get; private set; }
        static int blockCount = 0;
        static decimal reward = 50;

        static string minerPrivateKey = "";
        static Wallet _minersWallet = RSA.RSA.KeyGenerate();

        //The class constructor
        public CryptoCurrency(){
            minerPrivateKey = _minersWallet.PrivateKey;
            NodeId = _minersWallet.PublicKey;

            //string sign = RSA.RSA.Sign(minerPrivateKey, "h");
            //bool bol = RSA.RSA.Verify(NodeId, "h", sign);

            //initial transaction
            var transaction = new Transaction { Sender = "0", Recipient = NodeId, 
                                                Amount = 50, Fees = 0, Signature = "" 
                                                };
            _currentTransactions.Add(transaction);

            CreateNewBlock(proof: 100, previousHash: "1"); //our genesis block
        }

        //Here new miners will add to this cryptocurrency network
        private void RegisterNode(string address)
        {
            _nodes.Add(new Node { Address = new Uri(address) });
        }

        private Block CreateNewBlock(int proof, string previousHash = null)
        {
            var block = new Block
            {
                Index = _chain.Count,
                Timestamp = DateTime.Now, //Local time, can use UTC if have justification
                Transactions = _currentTransactions.ToList(),
                Proof = proof,
                PreviousHash = previousHash ?? GetHash(_chain.Last()) //null coalescence operator
            };

            _currentTransactions.Clear();
            _chain.Add(block);

            return block;
        }

        private string GetHash(Block block)
        {
            string blockText = JsonConvert.SerializeObject(block);
            return GetSha256(blockText);
        }

        //function responsable to generate the hashes
        private string GetSha256(string data)
        {
            var sha256 = new SHA256Managed();
            var hashBuilder = new StringBuilder();

            byte[] bytes = Encoding.Unicode.GetBytes(data);
            byte[] hash = sha256.ComputeHash(bytes);

            foreach (byte x in hash)
                hashBuilder.Append($"{x:x2}");
            
            return hashBuilder.ToString();
        }

        //Mine few transaction before add then to a block in blockchain
        private int CreateProofOfWork(string previousHash)
        {
            int proof = 0;
            while (!IsValidProof(_currentTransactions, proof, previousHash))
                proof++;
            
            if (blockCount == 10)
            {
                blockCount = 0;
                reward /= 2; //reward ÷ 2
            }

            //miner receives reward after solving cryptography puzzle
            var transaction = new Transaction { Sender = "0", Recipient = NodeId,
                                                Amount = reward, Fees = 0,
                                                Signature = "" };
            _currentTransactions.Add(transaction);
            //CreateTransaction(sender: "0",recipient: NodeId,amount: reward,signature: "");//reward
            blockCount++;

            return proof;
        }

        private bool IsValidProof(List<Transaction> transactions, int proof, string previousHash)
        {
            var signatures = transactions.Select(x => x.Signature).ToArray();
            string guess = $"{signatures}-{proof}-{previousHash}";
            string result = GetSha256(guess);

            return result.StartsWith("00"); //the difficulty level to find out cryptographic hash
        }

        //Checks if a transaction is valid or not
        public bool Verify_transaction_signature(Transaction transaction, string signedMessage, string publicKey)
        {
            string originalMessage = transaction.ToString();
            bool verified = RSA.RSA.Verify(publicKey, originalMessage, signedMessage);

            return verified;
        }

        //Checks all transactions of particular address
        private List<Transaction> TransactionByAddress(string ownerAddress)
        {
            List<Transaction> trnscts = new List<Transaction>();
            foreach (var block in _chain.OrderByDescending(x => x.Index))
            {
                var ownerTransactions = block.Transactions.
                    Where(x => x.Sender == ownerAddress || x.Recipient == ownerAddress);
                trnscts.AddRange(ownerTransactions);
            }

            return trnscts;
        }

        //Checks user balance
        public bool HasBalance(Transaction transaction)
        {
            var trnscts = TransactionByAddress(transaction.Sender);
            decimal balance = 0;
            foreach (var item in trnscts)
            {
                if (item.Recipient == transaction.Sender)
                    balance += item.Amount;
                else
                    balance -= item.Amount;
            }

            return balance >= (transaction.Amount + transaction.Fees);
        }

        //Adds a transaction to the transactions list
        private void AddTransaction(Transaction transaction)
        {
            _currentTransactions.Add(transaction);

            if (transaction.Sender != NodeId)
                _currentTransactions.Add(new Transaction
                {
                    Sender = transaction.Sender,
                    Recipient = transaction.Recipient,
                    Amount = transaction.Fees,
                    Signature = "",
                    Fees = 0
                });
        }

        //Check if a chain is valid or not. The longest one will always be valid.
        private bool ResolveConflicts()
        {
            List<Block> newChain = null;
            int maxLength = _chain.Count;

            foreach (Node node in _nodes)
            {
                var url = new Uri(node.Address, "/chain");
                var request = (HttpWebRequest)WebRequest.Create(url);
                var response = (HttpWebResponse)request.GetResponse();

                if(response.StatusCode == HttpStatusCode.OK)
                {
                    var model = new
                    {
                        chain = new List<Block>(),
                        length = 0
                    };
                    string json = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    var data = JsonConvert.DeserializeAnonymousType(json, model);

                    if (data.chain.Count > _chain.Count && IsValidChain(data.chain))
                    {
                        maxLength = data.chain.Count;
                        newChain = data.chain;
                    }
                }
            }

            if (newChain != null)
            {
                _chain = newChain;
                return true;
            }

            return false;
        }

        //Verifies if all blocks and transactions on the blockchain are valid
        private bool IsValidChain(List<Block> chain)
        {
            Block block = null;
            Block lastBlock = chain.First();
            int currentIndex = 1;
            while (currentIndex < chain.Count)
            {
                block = chain.ElementAt(currentIndex);

                //Check if the hash of the block is correct
                if (block.PreviousHash != GetHash(lastBlock))
                    return false;
                
                //Check if the Proof of Work is correct
                if (!IsValidProof(block.Transactions, block.Proof, lastBlock.PreviousHash))
                    return false;
                
                lastBlock = block;
                currentIndex++;
            }

            return true;
        }

        /*--- Web API calls below ---*/

        //Where mining operation will be executed
        internal Block Mine()
        {
            int proof = CreateProofOfWork(_lastBlock.PreviousHash);

            Block block = CreateNewBlock(proof /*, _lastBlock.PreviousHash */);

            return block;
        }

        //returns whole chain of the blockchain
        internal string GetFullChain()
        {
            var response = new
            {
                chain = _chain.ToArray(),
                length = _chain.Count()
            };

            return JsonConvert.SerializeObject(response);
        }

        //responsable to add new miners to the network
        internal string RegisterNodes(string[] nodes)
        {
            var builder = new StringBuilder();
            foreach (string node in nodes)
            {
                string url = node; //$"http://{node}";
                RegisterNode(url);
                builder.Append($"{url}, ");
            }

            builder.Insert(0, $"{nodes.Count()} new nodes have been added: ");
            string result = builder.ToString();
            return result.Substring(0, result.Length - 2);
        }

        //Calls ResolveConflict method
        internal object Consensus()
        {
            bool replaced = ResolveConflicts();
            string message = replaced ? "was replaced" : "is reliable";

            var response = new
            {
                Message = $"Our chain {message}",
                Chain = _chain
            };

            return response; //JsonConvert.SerializeObject(response);
        }

        //Adds a transaction to a block
        internal object CreateTransaction(Transaction transaction)
        {
            var rsp = new object();
            
            //initializes verification process
            var verified = Verify_transaction_signature(transaction, transaction.Signature, transaction.Sender);
            
            if (verified == false || transaction.Sender == transaction.Recipient)
            {
                rsp = new { message = $"Invalid Transaction!" };
                return rsp;
            }
            if (HasBalance(transaction) == false)
            {
                rsp = new { message = $"Insufficiente Balance!" };
                return rsp;
            }

            AddTransaction(transaction);

            var blockIndex = _lastBlock != null ? _lastBlock.Index + 1 : 0;

            rsp = new { message = $"Transactions will be added to the Block {blockIndex}" };
            return rsp;
        }
        
        //Auxiliar functions to return blockchain values
        internal List<Transaction> GetTransactions()
        {
            return _currentTransactions; //exposes all transactions
        }
        internal List<Block> GetBlocks()
        {
            return _chain; //entire blockchain
        }
        internal List<Node> GetNodes()
        {
            return _nodes; //all nodes linked to the network
        }
        internal Wallet GetMinersWallet()
        {
            return _minersWallet; //miners public and private keys
        }
    }
}