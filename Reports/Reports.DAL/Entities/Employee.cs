using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Reports.DAL.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public EmployeeType Role { get; set; }
        public Guid LeaderId { get; set; }

        public Employee()
        {
        }

        public Employee(Guid id, string name, EmployeeType role, Guid leaderId)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id), "Id is invalid");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Name is invalid");
            }

            Id = id;
            Name = name;
            Role = role;
            LeaderId = leaderId;
        }
    }
}