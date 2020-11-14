using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockchainServiceAlice.Models
{
    public class Transaction
    {
        public decimal Amount {get; set;}
        public string Recipient_Address {get; set;}
        public string Sender_Address {get; set;}
        public string Signature {get; set;}
        public decimal Fees {get; set;}

        public override string ToString()
        {
            return Amount.ToString("0.00000000") + Recipient_Address + Sender_Address;
        }
    }
}