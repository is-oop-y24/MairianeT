using System.Security.Cryptography.X509Certificates;

namespace Banks.Console
{
    public class View
    {
        public void WriteLine(string message)
        {
            System.Console.WriteLine(message);
        }

        public string ReadLine()
        {
            return System.Console.ReadLine();
        }

        public double ReadDouble()
        {
            return System.Console.Read();
        }
    }
}