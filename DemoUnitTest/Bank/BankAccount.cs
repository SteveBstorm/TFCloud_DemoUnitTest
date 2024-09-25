using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUnitTest.Bank
{
    public class BankAccount
    {
        private string _customerName;
        private decimal _balance;

        public BankAccount(string name, decimal balance)
        {
           _customerName = name;
            _balance = balance;
        }

        public BankAccount(IBankService service, string customerName)
        {
            _customerName=customerName;
            _balance = service.GetBalance(customerName);
        }

        public decimal Balance { get { return _balance; } }

        public void Debit(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException();

            if (amount <= _balance)
                _balance -= amount;
        }

        public void Credit(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException();

            _balance += amount;
        }
    }
}
