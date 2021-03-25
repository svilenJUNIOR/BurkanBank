using BurkanBankFinalEdition.database;

namespace BurkanBankFinalEdition.contracts
{
    public interface IController
    {
        public void AddClient(string firstName, string lastName, string mail, string pass, int age, naMalkiqBankataContext db);
        public void LogIn(string mail, string pass, naMalkiqBankataContext db);
        public void AddAccount(string pass, string accountName ,naMalkiqBankataContext db);
        public void DepositMoney(string accountName, decimal sum, naMalkiqBankataContext db);
        public void WithdrawMoney(string accountName, decimal sum, naMalkiqBankataContext db);
        public void SeeAccountBalance(string accountName, naMalkiqBankataContext db);
        public void CalcMoney(double amount, int months);
    }
}
