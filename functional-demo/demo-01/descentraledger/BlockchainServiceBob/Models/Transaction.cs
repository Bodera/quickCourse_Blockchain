using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockchainServiceBob.Models
{
    public class Transaction
    {
        public string Sender {get; set;}
        public string Recipient {get; set;}
        public decimal Amount {get; set;}
        public decimal Fees {get; set;}
        public string Signature {get; set;}

        public override string ToString()
        {
            return Amount.ToString("0.00000000") + Recipient + Sender;
        }
    }
}