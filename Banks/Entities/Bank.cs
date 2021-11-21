using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Banks.Entities
{
    public class Bank
    {
        private float _unverifiedLimit;
        private List<Client> subscribers = new List<Client>();
        public Bank(string name, float percent, float commission, float creditLimit, float unverifiedLimit, List<float> interests)
        {
            Name = name;
            BankPercent = percent;
            BankCommission = commission;
            CreditLimit = creditLimit;
            DepositInterests = interests;
            _unverifiedLimit = unverifiedLimit;
        }

        public float BankPercent { get; set; }
        public float BankCommission { get; }
        public float CreditLimit { get; set; }
        public string Name { get; }
        public List<float> DepositInterests { get; }
        public Dictionary<Client, List<Account>> ClientsAccounts { get; }

        public void AddClient(Client client)
        {
            if (ClientsAccounts.Keys.Contains(client))
            {
                throw new Exception("This client is already in the bank.");
            }

            ClientsAccounts.Add(client, new List<Account>());
        }

        public void AddClientAccount(Client client, string accountType, float sum, int term = 0)
        {
            if (ClientsAccounts.Keys.Contains(client))
            {
                switch (accountType)
                {
                    case "debit":
                        ClientsAccounts[client].Add(new DebitAccount(sum, this));
                        break;
                    case "credit":
                        ClientsAccounts[client].Add(new CreditAccount(sum, this));
                        break;
                    case "deposit":
                        ClientsAccounts[client].Add(new DepositAccount(sum, this, term));
                        break;
                }
            }
            else
            {
                switch (accountType)
                {
                    case "debit":
                        ClientsAccounts.Add(client, new List<Account>() { new DebitAccount(sum, this) });
                        break;
                    case "credit":
                        ClientsAccounts.Add(client, new List<Account>() { new CreditAccount(sum, this) });
                        break;
                    case "deposit":
                        ClientsAccounts.Add(client, new List<Account>() { new DepositAccount(sum, this, term) });
                        break;
                }
            }
        }

        public void RefillCash(Client client, Account account, float sum)
        {
            if (!client.Verified() && sum >= _unverifiedLimit)
                throw new Exception("Client is unverified.");
            if (!ClientsAccounts[client].Contains(account))
                throw new Exception("There is not account.");
            account.Refill(sum);
        }

        public void WithdrawalCash(Client client, Account account, float sum)
        {
            if (!client.Verified() && sum >= _unverifiedLimit)
                throw new Exception("Client is unverified.");
            if (!ClientsAccounts[client].Contains(account))
                throw new Exception("There is not account.");
            account.CashWithdrawal(sum);
        }

        public void Transfer(Client client1, Client client2, Account account1, Account account2, float sum)
        {
            WithdrawalCash(client1, account1, sum);
            RefillCash(client2, account2, sum);
        }

        public void Subscribe(Client client)
        {
            subscribers.Add(client);
        }

        public void ChangePercent(float newPercent)
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

        public void ChangeCreditLimit(float newLimit)
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

        private static void ChangeLimit(CreditAccount account, float newLimit)
        {
            account.ChangeLimit(newLimit);
        }
    }
}