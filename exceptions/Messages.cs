namespace BurkanBankFinalEdition.exceptions
{
    public abstract class Messages
    {
        //////////////////////////////////// BAD BAD BAD BAD //////////////////////////////////////
        public const string invalidFirstName = "Field first name cannot be empty!\n";
        public const string invalidLastName = "Field last name cannot be empty!\n";
        public const string invalidEmail = "Field email cannot be empty!\n";
        public const string invalidPassword = "Password must contain more than 6 symbols!\n";
        public const string invalidAge = "People under the age of 18 cannot legally posses bank accounts!\n";
        public const string ExistingAccount = "This email has already been used!\n";
        public const string InexistingUSer = "Wrong email or password\n";
        public const string InexistingAccount = "No such bank account!\n";
        public const string ExistingBankAccount = "Account with this name already exists!\n";
        public const string EmptyAccount = "Your account is empty!\n";
        public const string NotEnoughMoney = "Sum to Withdraw is {0}. Current account balance is {1}!\n";
        public const string AccountNotFound = "No account matches the password\n";
        public const string InvalidNumberOfMoths = "Invalid number of months\n";
        public const string InvalidNumberOfOperation = "Invalid number of operation\n";

        //////////////////////////////////// GOOD GOOD GOOD GOOD //////////////////////////////////////
        public const string SuccessfulRegistraion = "Registration successful!\n";
        public const string SuccessfulLogIn = "Log In successful!\n";
        public const string SuccessfulAccountCreation = "Successfully created bank account with name";
    }
}
