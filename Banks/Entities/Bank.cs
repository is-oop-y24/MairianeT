using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Banks.Services;
using Banks.Tools;

namespace Banks.Entities
{
    public class Bank
    {
        private List<Client> subscribers = new List<Client>();
        public Bank(string name, double percent, double commission, double creditLimit, double unverifiedLimit, List<double> interests)
        {
            Name = name;
            BankPercent = percent;
            BankCommission = commission;
            CreditLimit = creditLimit;
            DepositInterests = interests;
            UnverifiedLimit = unverifiedLimit;
            ClientsAccounts = new Dictionary<Client, List<Account>>();
        }

        public double BankPercent { get; set; }
        public double BankCommission { get; }
        public double CreditLimit { get; set; }
        public string Name { get; }
        public List<double> DepositInterests { get; }
        public double UnverifiedLimit { get; }
        public Dictionary<Client, List<Account>> ClientsAccounts { get; }

        public void AddClient(Client client)
        {
            if (ClientsAccounts.Keys.Contains(client))
            {
                throw new BanksException("This client is already in the bank.");
            }

            ClientsAccounts.Add(client, new List<Account>());
        }

        public Account AddClientAccount(Client client, AccountType accountType, double sum, int id, int term = 0)
        {
            if (ClientsAccounts.Keys.Contains(client))
            {
                switch (accountType)
                {
                    case AccountType.Debit:
                        var debitAccount = new DebitAccount(sum, this, id);
                        ClientsAccounts[client].Add(debitAccount);
                        return debitAccount;
                    case AccountType.Credit:
                        var creditAccount = new CreditAccount(sum, this, id);
                        ClientsAccounts[client].Add(creditAccount);
                        return creditAccount;
                    case AccountType.Deposit:
                        var depositAccount = new DepositAccount(sum, this, term, id);
                        ClientsAccounts[client].Add(depositAccount);
                        return depositAccount;
                }
            }
            else
            {
                switch (accountType)
                {
                    case AccountType.Debit:
                        var debitAccount = new DebitAccount(sum, this, id);
                        ClientsAccounts.Add(client, new List<Account>() { debitAccount });
                        return debitAccount;
                    case AccountType.Credit:
                        var creditAccount = new CreditAccount(sum, this, id);
                        ClientsAccounts.Add(client, new List<Account>() { creditAccount });
                        return creditAccount;
                    case AccountType.Deposit:
                        var depositAccount = new DepositAccount(sum, this, term, id);
                        ClientsAccounts.Add(client, new List<Account>() { depositAccount });
                        return depositAccount;
                }
            }

            return null;
        }

        public void RefillCash(Client client, Account account, double sum)
        {
            if (!client.Verified() && sum >= UnverifiedLimit)
                throw new BanksException("Client is unverified.");
            if (!ClientsAccounts[client].Contains(account))
                throw new BanksException("There is not account.");
            account.Refill(sum);
        }

        public void WithdrawalCash(Client client, Account account, double sum)
        {
            if (!client.Verified() && sum >= UnverifiedLimit)
                throw new BanksException("Client is unverified.");
            if (!ClientsAccounts[client].Contains(account))
                throw new BanksException("There is not account.");
            account.CashWithdrawal(sum);
        }

        public void Transfer(Client client1, Client client2, Account account1, Account account2, double sum)
        {
            WithdrawalCash(client1, account1, sum);
            RefillCash(client2, account2, sum);
        }

        public void Subscribe(Client client)
        {
            subscribers.Add(client);
        }

        public void ChangePercent(double newPercent)
        {
            foreach (Client client in subscribers)
            {
                client.Update("Percent changes from " + BankPercent + " to " + newPercent + " in bank " + Name);
            }

            BankPercent = newPercent;
            foreach (Account account in ClientsAccounts.Values.SelectMany(accounts => accounts))
            {
                account.Percent = newPercent;
            }
        }

        public void ChangeCreditLimit(double newLimit)
        {
            foreach (Client client in subscribers)
            {
                client.Update("Percent changes from " + CreditLimit + " to " + newLimit + " in bank " + Name);
            }

            foreach (CreditAccount account in ClientsAccounts.Cast<List<Account>>().SelectMany(accounts => accounts).OfType<CreditAccount>())
            {
                ChangeLimit(account, newLimit);
            }

            CreditLimit = newLimit;
        }

        public void RewindTime(int days)
        {
            foreach (Account account in ClientsAccounts.Values.SelectMany(accounts => accounts))
            {
                account.RewindTime(days);
            }
        }

        private static void ChangeLimit(CreditAccount account, double newLimit)
        {
            account.ChangeLimit(newLimit);
        }
    }
}