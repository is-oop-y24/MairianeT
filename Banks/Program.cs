using System;
using System.Runtime.CompilerServices;
using Banks.Entities;
using Banks.Services;

namespace Banks
{
    internal static class Program
    {
        private static ICentralBank _centralBank = new CentralBank();
        private static void Main()
        {
        }
    }
}
