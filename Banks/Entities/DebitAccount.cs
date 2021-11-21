namespace Banks.Entities
{
    public class DebitAccount : Account
    {
        public DebitAccount(double sum, Bank bank)
            : base(sum, bank)
        {
        }

        public override void RewindTime(int days)
        {
            Balance += Balance * days * Percent;
        }
    }
}