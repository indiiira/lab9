using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30_10_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 8.1");
            Account account1 = new Account(1000,TypeOfBankAccount.saving);
            Account account2 = new Account(0, TypeOfBankAccount.corrent);

            account1.FullInfo();
            account2.FullInfo();
            bool flag = true;


            while (flag)
            {
                Console.WriteLine("Введите команды:заполнить сберегательный, заполнить текущий , вывести сберегательный,вывести текущий, снять со счета, положить на счет, выход, перевести");

                string act = Console.ReadLine().ToLower();
                if (act.Equals("выход"))
                {
                    flag = false;
                }
                else if (act.Equals("заполнить сберегательный"))
                {
                    int n = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите сумму");
                    decimal money;
                    while (!decimal.TryParse(Console.ReadLine(), out money) || money < 0)
                    {
                        Console.WriteLine("Введите целое число ");
                    }
                    account1.DepositMoney(money);

                }
                else if (act.Equals("заполнить текущий"))
                {
                    Console.WriteLine("Введите сумму");
                    decimal money;
                    while (!decimal.TryParse(Console.ReadLine(), out money) || money < 0)
                    {
                        Console.WriteLine("Введите целое число ");
                    }
                    account2.DepositMoney(money);
                }
                else if (act.Equals("вывести сберегательный"))
                {
                    account1.FullInfo();
                }
                else if (act.Equals("вывести текущий"))
                {
                    account2.FullInfo();
                }

                else if (act.Equals("снять со счета"))
                {
   
                    Console.Write("Choose the type of account : saving or corrent\t\t");
                    string type0 = Console.ReadLine().ToLower();
                    if (type0.Equals("saving"))
                    {
                        Console.Write("введите сумму");
                        decimal money;
                        while (!decimal.TryParse(Console.ReadLine(), out money) || money < 0)
                        {
                            Console.WriteLine("Incorrect volue money");
                        }
                        account1.WithdrawMoney(money);
                    }
                    else if (type0.Equals("corrent"))
                    {
                        Console.Write("введите сумму ");
                        decimal money;
                        while (!decimal.TryParse(Console.ReadLine(), out money) || money < 0)
                        {
                            Console.WriteLine("Incorrect volue money");
                        }
                        account2.WithdrawMoney(money);
                    }
                }



                else if (act.Equals("перевести"))
                {
                    Console.WriteLine("from corrent or saving?");
                    string str = Console.ReadLine();
                    if (Equals(str, "corrent"))
                    {
                        Console.WriteLine("Сколько?");
                        decimal transfer;
                        while (!decimal.TryParse(Console.ReadLine(), out transfer) || transfer < 0)
                        {
                            Console.WriteLine("Incorrect value of money");
                        }
                        account2.MoneytransferSave(account1, transfer);
                    }
                    if (Equals(str, "saving"))
                    {
                        Console.WriteLine("Сколько?");
                        decimal transfer;
                        while (!decimal.TryParse(Console.ReadLine(), out transfer) || transfer < 0)
                        {
                            Console.WriteLine("Incorrect value of money");
                        }
                        account1.MoneytransferCorrent(account2, transfer);
                    }
                }

                account1.Write(account1);
                account2.Write(account2);
                Console.ReadKey();
            }
        }
    }
}
    

