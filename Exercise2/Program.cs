using Exercise2.Helpers;
using System.Net.Security;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Exercise2
{
    public class Program
    {
        static void Main(string[] args)
        {
            IUI ui = new ConsoleUI();
            Main main = new Main(ui);
            main.Run();
        }
    }
}