using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;

namespace Reports.DAL.Entities
{
    public class TaskModel
    {
        public string Description { get; set; }
        public StatusType Status { get; set; }
        public Guid DesignatedEmployeeId { get; set; }
        public Guid Id { get; private init; }
        public DateTime CreationTime { get; set; }
        public TaskModel()
        {
        }

        public TaskModel(Guid id, Guid employeeId, string description)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id), "Id is invalid");
            }

            if (string.IsNullOrEmpty(description))
            {
                throw  new ArgumentNullException(nameof(description), "Description is invalid");
            }

            Id = id;
            Description = description;
            Status = StatusType.Open;
            DesignatedEmployeeId = employeeId;
            CreationTime = DateTime.Now;
        }

        public void ChangeDesignatedEmployee(Guid employeeId)
        {
            DesignatedEmployeeId = employeeId;
        }
        
        public void ChangeStatus(StatusType newStatus)
        {
            Status = newStatus;
        }
        
        public void ChangeDescription(string newDescription)
        {
            Description = newDescription;
        }
    }
}