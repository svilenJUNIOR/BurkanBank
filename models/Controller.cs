using BurkanBankFinalEdition.contracts;
using BurkanBankFinalEdition.database;
using System;
using BurkanBankFinalEdition.exceptions;
using System.Linq;

namespace BurkanBankFinalEdition.models
{
    public class Controller : IController
    {
        public void AddClient(string firstName, string lastName, string mail, string pass, int age, naMalkiqBankataContext db)
        {
            Client client = new Client();

            client.FirstName = firstName;
            client.LastName = lastName;
            client.Email = mail;
            client.Password = pass;
            client.Age = age;

            if (db.Clients.Any(x => x.Email == mail))
            {
                throw new ArgumentException(Messages.ExistingAccount);
            }

            else
            {
                db.Clients.Add(client);
                db.SaveChanges();
            }
        }
        public void LogIn(string mail, string pass, naMalkiqBankataContext db)
        {
            if (!db.Clients.Any(x => x.Email == mail && x.Password == pass))
            {
                throw new ArgumentException(Messages.InexistingUSer);
            }
        }
        public void AddAccount(string pass, string accountName, naMalkiqBankataContext db)
        {
            var client = db.Clients.FirstOrDefault(x => x.Password == pass);

            if (client is null)
            {
                throw new ArgumentException(Messages.AccountNotFound);
            }

            int clientId = client.Id;

            if (db.Accounts.Any(x => x.Name == accountName))
            {
                throw new ArgumentException(Messages.ExistingBankAccount);
            }

            Account account = new Account(clientId);
            account.Name = accountName;

            db.Accounts.Add(account);
            db.SaveChanges();
        }
        public void DepositMoney(string accountName, decimal sum, naMalkiqBankataContext db)
        {
            if (!db.Accounts.Any(x => x.Name == accountName))
            {
                throw new ArgumentException(Messages.InexistingAccount);
            }

            var account = db.Accounts.FirstOrDefault(x => x.Name == accountName);

            if (account.Balance is null)
            {
                account.Balance = 0;
            }

            account.Balance = account.Balance + sum;
            db.SaveChanges();
        }
        public void WithdrawMoney(string accountName, decimal sum, naMalkiqBankataContext db)
        {
            if (!db.Accounts.Any(x => x.Name == accountName))
            {
                throw new ArgumentException(Messages.InexistingAccount);
            }

            var account = db.Accounts.FirstOrDefault(x => x.Name == accountName);

            if (account.Balance is null || account.Balance == 0)
            {
                throw new ArgumentException(Messages.EmptyAccount);
            }

            if (sum > account.Balance)
            {
                throw new ArgumentException(string.Format(Messages.NotEnoughMoney, sum, account.Balance));
            }

            account.Balance = account.Balance - sum;
            db.SaveChanges();
        }
        public void SeeAccountBalance(string accountName, naMalkiqBankataContext db)
        {
            if (!db.Accounts.Any(x => x.Name == accountName))
            {
                throw new ArgumentException(Messages.InexistingAccount);
            }

            var account = db.Accounts.FirstOrDefault(x => x.Name == accountName);
            Console.WriteLine(account.Balance);
        }
        public void CalcMoney(double amount, int months)
        {
            double firstDeposit = amount;

            if (months >= 6 && months < 12)
            {
                double interest = 2.51;

                for (int i = 0; i < months; i++)
                {
                    amount += (interest / 100) * amount;
                }
            }

            else if (months >= 12 && months < 18)
            {

                double interest = 2.72;

                for (int i = 0; i < months; i++)
                {
                    amount += (interest / 100) * amount;
                }
            }

            else if (months >= 18 && months <= 24)
            {
                double interest = 3.15;

                for (int i = 0; i < months; i++)
                {
                    amount += (interest / 100) * amount;
                }
            }

            else if (months < 6 || months > 24)
            {
                throw new ArgumentException(Messages.InvalidNumberOfMoths);
            }

            Console.WriteLine($"Your account balance with grow with {amount - firstDeposit:f2} for {months} months.\n");
        }
    }
}
