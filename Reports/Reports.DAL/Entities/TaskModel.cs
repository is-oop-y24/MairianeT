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
        // public List<Change> Changes { get; set; }
        // public List<string> Comments { get; private init; }
        public Guid Id { get; private init; }
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
            // Changes = new List<Change>();
            // Comments = new List<string>();
        }

        // public void ChangeDesignatedEmployee(Employee entity)
        // {
        //     DesignatedEmployee = entity;
        //     Changes.Add(new Change(new Guid(), ChangeType.DesignatedEmployee));
        // }
        //
        // public void AddComment(string comment)
        // {
        //     Comments.Add(comment);
        //     Changes.Add(new Change(new Guid(), ChangeType.Comment));
        // }
        //
        // public void ChangeStatus(StatusType newStatus)
        // {
        //     Status = newStatus;
        //     Changes.Add(new Change(new Guid(), ChangeType.Status));
        // }
        //
        // public void ChangeDescription(string newDescription)
        // {
        //     Description = newDescription;
        //     Changes.Add(new Change(new Guid(), ChangeType.Description));
        // }
    }
}