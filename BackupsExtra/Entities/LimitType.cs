namespace BackupsExtra.Entities
{
    public enum LimitType
   {
       /// <summary>
       /// time
       /// </summary>
       Time,

       /// <summary>
       /// number
       /// </summary>
       Number,

       /// <summary>
       /// Hybrid with no one limit
       /// </summary>
       HybridAll,

       /// <summary>
       /// Hybrid with at least limit
       /// </summary>
       HybridLeastOne,
   }
}
