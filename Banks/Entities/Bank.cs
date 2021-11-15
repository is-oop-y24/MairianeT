using System.Collections.Generic;

namespace Banks.Entities
{
    public class Bank
    {
        public Bank(
            DebitAccount debitAccount = new DebitAccount(),
            CreditAccount creditAccount = new CreditAccount(),
            DepositAccount depositAccount = new DepositAccount())
        {
            DebitAccount = debitAccount;
            DepositAccount = depositAccount;
            CreditAccount = creditAccount;
            Clients = new List<Client>();
        }

        public DebitAccount DebitAccount { get; }
        public CreditAccount CreditAccount { get; }
        public DepositAccount DepositAccount { get; }
        public List<Client> Clients { get; }
    }
}