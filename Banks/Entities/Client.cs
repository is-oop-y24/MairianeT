using System;

namespace Banks.Entities
{
    public class Client
    {
        private Client(string name, string surname, string address = "", int phoneNumber = 0)
        {
            Name = name;
            Surname = surname;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public string Name { get; }
        public string Surname { get; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
    }
}