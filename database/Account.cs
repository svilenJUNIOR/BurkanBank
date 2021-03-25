using System;

#nullable disable

namespace BurkanBankFinalEdition.database
{
    public partial class Account
    {
        public Account(int clientId)
        {
            this.ClientId = clientId;
        }
        public int ClientId { get; set; }
        public int AccountId { get; set; }
        public decimal? Balance { get; set; }
        public string Name { get; set; }

        public virtual Client Client { get; set; }
    }
}
