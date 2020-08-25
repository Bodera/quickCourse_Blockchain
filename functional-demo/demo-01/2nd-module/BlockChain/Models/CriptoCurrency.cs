using System.Security.Cryptography;
using Newtonsoft.Json;
using RSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace BlockChain.Models
{
    public class CriptoCurrency
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
        public CriptoCurrency(){
            minerPrivateKey = "Hard-Coded-Key"; //_minersWallet.PrivateKey;
            NodeId = "Hard-Coded-NodeId"; //_minersWallet.PublicKey;

            //string sign = RSA.RSA.Sing(minerPrivateKey, "h");
            //bool bol = RSA.RSA.Verify(NodeId, "h", sign);

            //initial transaction
            var transaction = new Transaction { Sender = "0", Recipient = NodeId, 
                                                Amount = 50, Fees = 0, Signature = "" 
                                                };
            _currentTransactions.Add(transaction);

            CreateNewBlock(proof: 100, previousHash: "1"); //our genesis block
        }

        //Here new miners will add to this criptocurrency network
        private void RegisterNode(string address)
        {
            _nodes.Add(new Node { Address = new Uri(address) });
        }

        private Block CreateNewBlock(int proof, string previousHash = null)
        {
            var block = new Block
            {
                Index = _chain.Count,
                Timestamp = DateTime.UtcNow,
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

            return result.StartsWith("00"); //the difficulty level to find out criptographic hash
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

        //Now we expose our private methods through a Web API 
    }
}