namespace Banks.Entities
{
    public class DebitAccount : Account
    {
        public DebitAccount(float sum, Bank bank)
            : base(sum, bank)
        {
        }

        public override void RewindTime(int days)
        {
            Balance += days * Percent;
        }
    }
}