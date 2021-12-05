namespace BackupsExtra.Entities
{
    public enum LimitType
   {
       /// <summary>
       /// deposit time
       /// </summary>
       Time,

       /// <summary>
       /// credit number
       /// </summary>
       Number,

       /// <summary>
       /// debit Hybrid with no one limit
       /// </summary>
       HybridAll,

       /// <summary>
       /// debit Hybrid with at least limit
       /// </summary>
       HybridLeastOne,
   }
}
