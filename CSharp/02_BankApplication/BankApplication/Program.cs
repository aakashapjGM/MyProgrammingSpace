namespace BankApplication
{
    class BankAccount
    {
        private string _accountOwner;
        private double _accountBalance;
        private static int _AccountCount;

        public BankAccount(string Owner, double initalDeposit = 0)
        {
            this._accountOwner = Owner;
            this._accountBalance = initalDeposit;

            Console.WriteLine("------------------------------------");
            if ( initalDeposit > 0 )
            {
                Console.WriteLine($"A/C Owner Name: {this._accountOwner}");
                Console.WriteLine($"A/c Opening Deposit Amount: {initalDeposit}");
                Console.WriteLine($"A/c Balance: {this._accountBalance}");
            }
            else
            {
                Console.WriteLine($"A/C Owner Name: {this._accountOwner}");
                Console.WriteLine($"A/c Balance: {this._accountBalance}");
            }

            _AccountCount += 1;

            Console.WriteLine("Congratulations! Account Created Successfully.");
            Console.WriteLine("------------------------------------");


        }

        public double CheckBalance()
        {
            Console.WriteLine($"A/c Balance: {this._accountBalance}");
            return _accountBalance;
        }

        public void Deposit(double Amount)
        {
            if (Amount > 0) this._accountBalance += Amount;
            else Console.WriteLine("Amount must be greater that zero");
        }

        public void Withdraw(double Amount)
        {
            if (Amount > 0 && Amount <= this._accountBalance) 
            {
                this._accountBalance -= Amount;
                Console.WriteLine($"Withdraw Successful\nUpdated A/c Balance: {_accountBalance}");
            }
            else if (Amount < 0) Console.WriteLine($"Negative Value Entered");
            else Console.WriteLine($"Insufficient amount\nA/c Balance: {this._accountBalance}");
        }

        public string GetOwnerName()
        {
            Console.WriteLine($"Owner Name: {this._accountOwner}");
            return _accountOwner;
        }

        public void AccountDetails()
        {
            Console.WriteLine($"A/c Holder Name: {_accountOwner}\nA/c Balance: {_accountBalance}");
            
        }

        public static int TotalOpenedAccount()
        {
            return _AccountCount;
        }

    }

    class MainProgramClass
    {
        public static void Main(string[] args)
        {
            int num_ = 123;
            BankAccount AcHolder_1 = new("Aakash Bera");
            BankAccount AcHolder_2 = new("Nohar Nirmalkar", 700.50);

            Console.WriteLine($"Total Number of Account: { BankAccount.TotalOpenedAccount() }");

            string myString = "Aakash";
            Console.WriteLine(myString.ToUpper());
        }
    }
}
