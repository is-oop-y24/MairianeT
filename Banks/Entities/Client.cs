using Banks.Tools;

namespace Banks.Entities
{
    public class Client
    {
        public Client(string name, string surname, string address, string passport)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
                throw new BanksException("Client has invalid name!");
            Name = name;
            Surname = surname;
            Address = address;
            Passport = passport;
        }

        public string Name { get; }
        public string Surname { get; }
        public string Address { get; set; }
        public string Passport { get; set; }

        public static ClientBuilder Builder(string name, string surname) =>
            new ClientBuilder().SetName(name).SetSurname(surname);

        public bool Verified()
        {
            return !string.IsNullOrEmpty(Address) && !string.IsNullOrEmpty(Passport);
        }

        public void Update(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}