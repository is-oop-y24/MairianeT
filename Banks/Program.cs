using System;
using Banks.Entities;

namespace Banks
{
    internal static class Program
    {
        private static void Main()
        {
            var builder = new ClientBuilder();
            builder.SetName("aaa").SetSurname("bbb");
            Client c1 = builder.GetClient();
            c1 = builder.SetAddress("ccc").GetClient();
            Console.WriteLine(c1.Name + " " + c1.Surname + " " + c1.Address);
        }
    }
}
