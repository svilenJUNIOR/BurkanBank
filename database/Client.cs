using System;
using System.Collections.Generic;
using BurkanBankFinalEdition.exceptions;

#nullable disable

namespace BurkanBankFinalEdition.database
{
    public partial class Client
    {
        private string firstName;
        private string lastName;
        private string email;
        private string pass;
        private int age;

        public Client()
        {
            Accounts = new HashSet<Account>();
        }

        public Client(string firstName, string lastName, string email, string pass, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = pass;
            this.Age = age;
        }
        public int Id { get; set; }
        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrEmpty(value) || value == " ")
                {
                    throw new ArgumentException(Messages.invalidFirstName);
                }

                firstName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrEmpty(value) || value == " ")
                {
                    throw new ArgumentException(Messages.invalidLastName);
                }

                lastName = value;
            }
        }
        public string Email
        {
            get { return this.email; }
            set
            {
                if (string.IsNullOrEmpty(value) || value == " ")
                {
                    throw new ArgumentException(Messages.invalidEmail);
                }

                email = value;
            }
        }
        public string Password
        {
            get { return this.pass; }
            set
            {
                if (string.IsNullOrEmpty(value) || value == " ")
                {
                    throw new ArgumentException(Messages.invalidPassword);
                }

                pass = value;
            }
        }
        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 18)
                {
                    throw new ArgumentException(Messages.invalidAge);
                }

                age = value;
            }
        }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
