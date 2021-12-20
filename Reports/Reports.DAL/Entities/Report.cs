using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reports.DAL.Entities
{
    public class Report
    {
        public Guid Id { get; private init; }
        public Guid OwnerId { get; set; }
        public  string StartTime { get; set; }
        public string FinishTime { get; set; }
        
        public Report()
        {
        }

        public Report(Guid id, Guid ownerId, string startTime, string finishTime)
        {
            Id = id;
            OwnerId = ownerId;
            StartTime = startTime;
            FinishTime = finishTime;
        }
        
    }
}