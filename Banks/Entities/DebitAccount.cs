namespace Banks.Entities
{
    public class DebitAccount : Account
    {
        public DebitAccount(double sum, Bank bank, int id)
            : base(sum, bank, id)
        {
        }

        public override void RewindTime(int days)
        {
            Balance += Balance * days * Percent;
        }
    }
}