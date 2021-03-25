using Microsoft.Extensions.DependencyInjection;
using BurkanBankFinalEdition.database;
using System;
using BurkanBankFinalEdition.exceptions;
using BurkanBankFinalEdition.contracts;
using BurkanBankFinalEdition.IN.OUT;

namespace BurkanBankFinalEdition.models
{
    public class Engine : IEngine
    {
        public void Run()
        {
            var db = new naMalkiqBankataContext();

            IServiceProvider collector = new ServiceCollection()
                 .AddScoped<IWriter, Writer>()
                 .AddScoped<IReader, Reader>()
                 .AddScoped<IController, Controller>()
                 .BuildServiceProvider();
            IWriter write = collector.GetService<IWriter>();
            IReader read = collector.GetService<IReader>();
            IController controller = collector.GetService<IController>();

            bool isLogged = false;

            write.WriteLine("Press 1 to sign in");
            write.WriteLine("Press 2 to log in");

            write.Write("Command: ");
            int command = int.Parse(read.ReadLine());
            Console.WriteLine();

            while (!isLogged)
            {
                try
                {
                    if (command == 1)
                    {
                        write.Write("First name: ");
                        string firstName = read.ReadLine();

                        write.Write("Last name: ");
                        string lastName = read.ReadLine();

                        write.Write("Email: ");
                        string email = read.ReadLine();

                        write.Write("Password: ");
                        string pass = read.ReadLine();

                        write.Write("Age: ");
                        int age = int.Parse(read.ReadLine());

                        controller.AddClient(firstName, lastName, email, pass, age, db);

                        isLogged = true;
                        write.WriteLine(Messages.SuccessfulRegistraion);
                    }

                    else if (command == 2)
                    {
                        write.Write("Email: ");
                        string email = read.ReadLine();

                        write.Write("Password: ");
                        string pass = read.ReadLine();

                        controller.LogIn(email, pass, db);

                        isLogged = true;

                        write.WriteLine(Messages.SuccessfulLogIn);
                    }

                    else
                    {
                        throw new ArgumentException(Messages.InvalidNumberOfOperation);
                    }
                }
                catch (ArgumentException e)
                {
                    write.WriteLine(e.Message);
                }
            }

            while (isLogged)
            {
                try
                {
                    write.WriteLine("Press 1 to create new bank account");
                    write.WriteLine("Press 2 to deposit money in account");
                    write.WriteLine("Press 3 to withdraw money from account");
                    write.WriteLine("Press 4 to see the account's balance");
                    write.WriteLine("Press 5 to calculate the amount of money you will earn due to amount of interest");
                    write.WriteLine("Press 0 to exit");
                    write.Write("Command: ");

                    int num = int.Parse(read.ReadLine());
                    Console.WriteLine();

                    if (num == 1)
                    {
                        write.Write("Password: ");
                        string pass = read.ReadLine();

                        write.Write("How would you like to name the bank account (eg: Money for educaton): ");
                        string accountName = read.ReadLine();

                        controller.AddAccount(pass, accountName, db);
                        write.WriteLine(Messages.SuccessfulAccountCreation + " " + accountName + "\n");
                    }

                    else if (num == 2)
                    {
                        write.Write("Enter account name: ");
                        string accountName = read.ReadLine();

                        write.Write("Enter the amount of money you would like to deposit: ");
                        decimal sum = decimal.Parse(read.ReadLine());
                        Console.WriteLine();

                        controller.DepositMoney(accountName, sum, db);
                    }

                    else if (num == 3)
                    {
                        write.Write("Enter account name: ");
                        string accountName = read.ReadLine();

                        write.Write("Enter the amount of money you would like to withdraw: ");
                        decimal sum = decimal.Parse(read.ReadLine());
                        Console.WriteLine();

                        controller.WithdrawMoney(accountName, sum, db);
                    }

                    else if (num == 4)
                    {
                        write.Write("Enter account name: ");
                        string name = read.ReadLine();
                        controller.SeeAccountBalance(name, db);
                        Console.WriteLine();
                    }

                    else if (num == 5)
                    {
                        write.WriteLine("Option 1: 6 months to under 12 month with monthly interest of 2,51%.");
                        write.WriteLine("Option 2: 12 months to under 18 months with month with monthly interest of 2,72%.");
                        write.WriteLine("Option 3: 18 months to under 24 months with month with monthly interest of 3,15%.\n");

                        write.Write("Enter the amount of money you would like to invest: ");
                        double amount = double.Parse(read.ReadLine());

                        write.Write("Enter the amount of months: ");
                        int months = int.Parse(read.ReadLine());

                        controller.CalcMoney(amount, months);
                    }

                    else if (num == 0)
                    {
                        break;
                    }

                    else
                    {
                        throw new ArgumentException(Messages.InvalidNumberOfOperation);
                    }

                }
                catch (ArgumentException e)
                {
                    write.WriteLine(e.Message);
                }
            }
        }
    }
}
