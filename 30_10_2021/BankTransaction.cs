using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30_10_2021
{
    class BankTransaction
    {
        private readonly decimal amount;
        private readonly DateTime when;
        public decimal Amount()
        {
            return amount;

        }
        public DateTime When()
        {
            return when;

        }
        public BankTransaction(decimal tranAmount)
        {
            amount = tranAmount;
            when = DateTime.Now;
        }
        
    }
}
