using System;
using System.Runtime.CompilerServices;
using Banks.Console;
using Banks.Entities;
using Banks.Services;

namespace Banks
{
    internal static class Program
    {
        private static ICentralBank _centralBank = new CentralBank();
        private static void Main()
        {
            Controller controller = new Controller();
            controller.Start();
        }
    }
}
