using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reports.DAL.Entities
{
    public class Report
    {
        public Guid Id { get; private init; }
        public Guid OwnerId { get; set; }
        public  DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public Guid TaskId { get; set; }
        
        public Report()
        {
        }

        public Report(Guid id, Guid ownerId, DateTime startTime, DateTime finishTime)
        {
            Id = id;
            OwnerId = ownerId;
            StartTime = startTime;
            FinishTime = finishTime;
        }
    }
}