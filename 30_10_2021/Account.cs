using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
namespace _30_10_2021
{
    public enum TypeOfBankAccount
    {
        corrent,
        saving
    }
    public sealed class Account:IDisposable
    {
        static int counter = 1;

        int _number;

        private Queue tranQueue = new Queue();




        decimal _balance;



        TypeOfBankAccount _typeAccount;
       
        public Account()
        {
            _number = Increase();
        }

        public Account(decimal balance)
        {
            _balance = balance;
            _number = Increase();

        }
        public Account(TypeOfBankAccount typeAccount)
        {
            _typeAccount = typeAccount;
            _number = Increase();

        }
        public Queue Transactions()
        {
            return tranQueue;

        }

        public Account(decimal balance, TypeOfBankAccount typeAccount)
        {
            _balance = balance;
            _typeAccount = typeAccount;
            _number = Increase();

        }
        public void Write(Account ac)
        {
            Console.WriteLine("Account number is {0}", ac._number);

            Console.WriteLine("Account balance is {0}", ac._balance);



            Console.WriteLine("Transactions:");

            foreach (BankTransaction tran in ac.Transactions())
            {
                Console.WriteLine("DateTime: {0}\tAmount: {1}", tran.When(), tran.Amount());

            }
            Console.WriteLine();

        }
        int Increase()
        {
            return counter++;
        }

        public void FullInfo()
        {
            Console.WriteLine($"Тип счёта: {_typeAccount}, Номер счёта: {_number}, Баланс: {_balance}");
        }

        public void DepositMoney(decimal amount)
        {


            _balance = _balance + amount;
            BankTransaction tran = new BankTransaction(amount);

            tranQueue.Enqueue(tran);
            Console.WriteLine($"Счёт пополнен на: {amount}");



        }


        public void WithdrawMoney(decimal amount)
        {

            if (_balance >= amount)
            {
                _balance = _balance - amount;
                BankTransaction tran = new BankTransaction(-amount);

                tranQueue.Enqueue(tran);
                Console.WriteLine($"Со счёта снята на: {amount}");
            }
            else
                Console.WriteLine($"На счету недостаточно средств. Баланс: {_balance}; Сумма для снятия: {amount};");


        }
        public void MoneytransferSave(Account acc, decimal transfer)
        {
            if (transfer <= _balance)
            {
                _balance = _balance - transfer;
                acc._balance = +transfer;
                BankTransaction tran = new BankTransaction(transfer);

                tranQueue.Enqueue(tran);
            }
            else
            {
                Console.WriteLine("insufficient funds");
            }

        }
        public void MoneytransferCorrent(Account acc, decimal transfer)
        {
            if (transfer <= _balance)
            {
                _balance = _balance - transfer;
                acc._balance = +transfer;
                BankTransaction tran = new BankTransaction(transfer);

                tranQueue.Enqueue(tran);
            }
            else
            {
                Console.WriteLine("insufficient funds");
            }
        }
        bool disposed = false;
        public void Dispose()
        {
            if (disposed == false)
            {
                StreamWriter swFile = File.AppendText("Transactions.txt");
                swFile.WriteLine("Account number is {0}", _number);

                swFile.WriteLine("Account balance is {0}", _balance);

                swFile.WriteLine("Account type is {0}", _typeAccount);
                swFile.WriteLine("Transactions:");

                foreach (BankTransaction tran in tranQueue)
                {
                    swFile.WriteLine("Date/Time: {0}\tAmount:{1}", tran.When(), tran.Amount());

                }
                swFile.Close();

                disposed = true;

                GC.SuppressFinalize(this);
            }
        }
            ~Account()
    {
               Dispose();
                Console.WriteLine("Disposed");
            }
        }
    }

