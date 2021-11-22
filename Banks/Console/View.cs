using System;
using Banks.Entities;

namespace Banks.Console
{
    public class View
    {
        private Controller _controller = new Controller();
        public void Start()
        {
            System.Console.WriteLine("Who are you? \n 1. Bank owner \n 2. Client");
            string answer = System.Console.ReadLine();
            switch (answer)
            {
                case "1":
                    BankOwnerAnswer();
                    Start();
                    break;
                case "2":
                    ClientAnswer();
                    Start();
                    break;
            }
        }

        public void ClientAnswer()
        {
            System.Console.WriteLine("What do you want to do?");
            System.Console.WriteLine("1. Register");
            System.Console.WriteLine("2. Open account");
            System.Console.WriteLine("3. Put money");
            System.Console.WriteLine("4. Withdraw money");
            System.Console.WriteLine("5. Transfer money");
            System.Console.WriteLine("6. Close transaction");
            System.Console.WriteLine("7. Bank information");
            System.Console.WriteLine("8. Exit");
            string answer = System.Console.ReadLine();
            switch (answer)
            {
                case "1":
                    RegisterClient();
                    ClientAnswer();
                    break;
                case "2":
                    OpenAccountClient();
                    ClientAnswer();
                    break;
                case "3":
                    PutMoneyClient();
                    ClientAnswer();
                    break;
                case "4":
                    WithdrawMoneyClient();
                    ClientAnswer();
                    break;
                case "5":
                    TransferClient();
                    ClientAnswer();
                    break;
                case "6":
                    CancelTransactionClient();
                    ClientAnswer();
                    break;
                case "7":
                    BankInfoClient();
                    ClientAnswer();
                    break;
                case "8":
                    break;
            }
        }

        public void RegisterClient()
        {
            var builder = new ClientBuilder();
            System.Console.WriteLine("What is your name?");
            builder.SetName(System.Console.ReadLine());
            System.Console.WriteLine("What is your surname?");
            builder.SetSurname(System.Console.ReadLine());
            System.Console.WriteLine("Do you want to enter your address and passport details and verify yourself? \n 1. Yes \n 2. No");
            switch (System.Console.ReadLine())
            {
                case "1":
                    System.Console.WriteLine("What is your address?");
                    builder.SetAddress(System.Console.ReadLine());
                    System.Console.WriteLine("Enter the series and number of the passport: ");
                    builder.SetPassport(System.Console.ReadLine());
                    System.Console.WriteLine("Your profile is now verified!");
                    break;
            }

            _controller.RegisterClient(builder);
        }

        public void OpenAccountClient()
        {
            System.Console.WriteLine("Enter your surname: ");
            string clientSurname = System.Console.ReadLine();
            System.Console.WriteLine("Choose bank for your account: \n" + _controller.ShowBanks());
            int bankNumber = Convert.ToInt32(System.Console.ReadLine()) - 1;
            System.Console.WriteLine("Enter sum for your account: ");
            double sum = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("What type of account do you want to open? \n 1. deposit \n 2. credit \n 3. debit");
            switch (System.Console.ReadLine())
            {
                case "1":
                    System.Console.WriteLine("For how long would you like to open an account? (days)");
                    int term = System.Console.Read();
                    _controller.OpenDepositAccount(bankNumber, clientSurname, sum, term);
                    System.Console.WriteLine("Your deposit account has been opened");
                    break;
                case "2":
                    _controller.OpenCreditAccount(bankNumber, clientSurname, sum);
                    System.Console.WriteLine("Your credit account has been opened");
                    break;
                case "3":
                    _controller.OpenDebitAccount(bankNumber, clientSurname, sum);
                    System.Console.WriteLine("Your debit account has been opened");
                    break;
            }
        }

        public void PutMoneyClient()
        {
            System.Console.WriteLine("Enter your surname: ");
            string clientSurname = System.Console.ReadLine();
            System.Console.WriteLine("Choose bank: \n" + _controller.ShowBanks());
            int bankNumber = Convert.ToInt32(System.Console.ReadLine()) - 1;
            System.Console.WriteLine("Choose your account ID: " + _controller.ShowAccountsForClient(clientSurname));
            int accountId = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Enter the amount for refill: ");
            double sum = Convert.ToDouble(System.Console.ReadLine());
            _controller.RefillMoney(bankNumber, clientSurname, accountId, sum);
        }

        public void WithdrawMoneyClient()
        {
            System.Console.WriteLine("Enter your surname: ");
            string clientSurname = System.Console.ReadLine();
            System.Console.WriteLine("Choose bank: \n" + _controller.ShowBanks());
            int bankNumber = Convert.ToInt32(System.Console.ReadLine()) - 1;
            System.Console.WriteLine("Choose your account ID: " + _controller.ShowAccountsForClient(clientSurname));
            int accountId = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Enter the amount for withdraw: ");
            double sum = Convert.ToDouble(System.Console.ReadLine());
            _controller.WithdrawMoney(bankNumber, clientSurname, accountId, sum);
        }

        public void TransferClient()
        {
            System.Console.WriteLine("Enter your surname: ");
            string client1Surname = System.Console.ReadLine();
            System.Console.WriteLine("Enter recipient surname: ");
            string client2Surname = System.Console.ReadLine();
            System.Console.WriteLine("Choose bank: \n" + _controller.ShowBanks());
            int bankNumber = Convert.ToInt32(System.Console.ReadLine()) - 1;
            System.Console.WriteLine("Choose your account ID: " + _controller.ShowAccountsForClient(client1Surname));
            int account1Id = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Choose your account ID: " + _controller.ShowAccountsForClient(client2Surname));
            int account2Id = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Enter the amount for transfer: ");
            double sum = Convert.ToDouble(System.Console.ReadLine());
            _controller.TransferMoney(bankNumber, client1Surname, client2Surname, account1Id, account2Id, sum);
        }

        public void CancelTransactionClient()
        {
            System.Console.WriteLine("Enter your surname: ");
            string clientSurname = System.Console.ReadLine();
            System.Console.WriteLine("Choose your account ID: " + _controller.ShowAccountsForClient(clientSurname));
            int accountId = Convert.ToInt32(System.Console.ReadLine());
            _controller.CancelTransaction(accountId);
        }

        public void BankInfoClient()
        {
            System.Console.WriteLine("Select a bank to provide information");
            System.Console.WriteLine(_controller.ShowBanks());
            int bankNumber = Convert.ToInt32(System.Console.ReadLine()) - 1;
            System.Console.WriteLine(_controller.BankInfo(bankNumber));
        }

        public void BankOwnerAnswer()
        {
            System.Console.WriteLine("What do you want to do? \n 1. Register bank \n 2. Change percent/credit limit \n 3. Exit");
            string answer = System.Console.ReadLine();
            switch (answer)
            {
                case "1":
                    RegisterBankAnswer();
                    BankOwnerAnswer();
                    break;
                case "2":
                    ChangePercentOrCreditLimitAnswer();
                    BankOwnerAnswer();
                    break;
            }
        }

        public void RegisterBankAnswer()
        {
            var builder = new BankBuilder();
            System.Console.WriteLine("Bank name: ");
            builder.SetName(System.Console.ReadLine());
            System.Console.WriteLine("Bank percent: ");
            builder.SetPercent(Convert.ToDouble(System.Console.ReadLine()));
            System.Console.WriteLine("Bank commission: ");
            builder.SetCommission(Convert.ToDouble(System.Console.ReadLine()));
            System.Console.WriteLine("Bank credit limit: ");
            builder.SetCreditLimit(Convert.ToDouble(System.Console.ReadLine()));
            System.Console.WriteLine("Bank unverified limit: ");
            builder.SetUnverifiedLimit(Convert.ToDouble(System.Console.ReadLine()));
            System.Console.WriteLine("Bank interest for : \n < 50000");
            double lowInterest = Convert.ToDouble(System.Console.ReadLine());
            System.Console.WriteLine(" \n >= 50000 and < 100000 ");
            double averageInterest = Convert.ToDouble(System.Console.ReadLine());
            System.Console.WriteLine(" \n >= 100000 ");
            double highInterest = Convert.ToDouble(System.Console.ReadLine());
            builder.SetInterests(lowInterest, averageInterest, highInterest);
            _controller.CreateBank(builder);
        }

        public void ChangePercentOrCreditLimitAnswer()
        {
            System.Console.WriteLine("What do you want to change? \n 1. Percent \n 2. Credit limit");
            string answer = System.Console.ReadLine();
            switch (answer)
            {
                case "1":
                    ChangePercentAnswer();
                    break;
                case "2":
                    ChangeCreditLimitAnswer();
                    break;
            }
        }

        public void ChangePercentAnswer()
        {
            System.Console.WriteLine("In which bank do you want to change the percents?");
            System.Console.WriteLine(_controller.ShowBanks());
            int bankNumber = Convert.ToInt32(System.Console.ReadLine()) - 1;
            System.Console.WriteLine("New percent:");
            double newPersent = Convert.ToDouble(System.Console.ReadLine());
            _controller.ChangePersent(bankNumber, newPersent);
        }

        public void ChangeCreditLimitAnswer()
        {
            System.Console.WriteLine("In which bank do you want to change the credit limit?");
            System.Console.WriteLine(_controller.ShowBanks());
            int bankNumber = Convert.ToInt32(System.Console.ReadLine()) - 1;
            System.Console.WriteLine("New credit limit:");
            double newCreditLimit = Convert.ToDouble(System.Console.ReadLine());
            _controller.ChangePersent(bankNumber, newCreditLimit);
        }
    }
}