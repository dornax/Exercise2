using System.Net.Security;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Exercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;

            do
            {
                Menu();
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        quit = true;
                        break;
                    case "1":
                        PrintPrice(YouthOrOlder());
                        break;
                    case "2":
                        Company();
                        break;
                    case "3":
                        InputTimes10();
                        break;
                    case "4":
                        ThirdWord();
                        break;
                    default:
                        NoValidInput();
                        break;
                }

            } while (!quit);

        }

        private static void ThirdWord()
        {

            Console.WriteLine("Mata in en mening med minst 3 ord.");
            bool foundWord = false;

            while (!foundWord) {

                string input = Console.ReadLine();

                if (TestForString(input))  // Test if input is valid string
                {
                    string word = SelectWord(input, 2); // Select third word
                    
                    if (word != "")  // Check if word is blank
                    {
                        Console.WriteLine($"Det tredje ordet i meningen är {word}.\n");
                        foundWord = true;
                    }
                    else NoValidInput(); //Print to Console 
                }
                else NoValidInput();
            }
        }

        private static string SelectWord(string word, int at)
        {   
            // Split string delimted by space. If there are more than one space 
            // between words discard spaces.
            var words = word.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string result =  (words.Length > at) ? words.ElementAt(at).ToString() : "";
            return result;
        }

        private static void InputTimes10()
        {

            int numberOfInputs = 10;
            string[] text = new string[numberOfInputs];
            Console.WriteLine($"Mata in valfri text {numberOfInputs} gånger.");
            Console.WriteLine("Inmatad text kommer att skrivas ut utan radavbrott.");

            for (int i = 0; i < numberOfInputs; i++)
            {
                Console.WriteLine($"Inmatning nr: {i+1}");
                string input = Console.ReadLine();

                if (TestForString(input))  // Test if input is valid string
                {
                    text[i] = input;
                }
                else 
                {
                    NoValidInput();  //Print to Console 
                    i--;
                } 
            }

            for (int i = 0; i < numberOfInputs; i++)
            {
                Console.Write($"{i+1}. {text[i]}");
                if (i < numberOfInputs - 1) Console.Write(", ");
            }

            Console.Write("\n\n");

        }
        private static void Company()
        {
            Console.Write("Hur många är ni i ert sällskap? ");
            string input = Console.ReadLine();

            int personsInCompany = TestForInt(input);
            int sum=0;

            if (personsInCompany != -1) 
            {
                for (int i = 0; i < personsInCompany; i++)
                {
                    sum += LookupPrice(YouthOrOlder()); 
                }
                Console.WriteLine($"Totalkostnad {sum:C0} för {personsInCompany} personer.\n");
            }
        }

        public enum Price
        {
            Free = 0,
            Youth = 80,
            Standard = 120,
            Senior = 90
        }
        public static void NoValidInput()
        {
            Console.WriteLine("Ogiltig inmatning\n");
        }

        public static bool TestForString(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static int TestForInt(string str)
        {
            if (TestForString(str))
            {
                if (int.TryParse(str, out int value))
                {
                    return value;
                }
            }
            return -1;      // No success 

        }

        public static Price YouthOrOlder()
        {
            Console.Write("Ange ålder: ");
            string input = Console.ReadLine();

            int age = TestForInt(input);
            if (age != -1)
            {
                if (age < 5 || age > 100) return Price.Free;
                else if (age < 20 && age > 5) return Price.Youth;
                else if (age > 64 && age < 100) return Price.Senior;
                else return Price.Standard;
            }
            return 0;
        }

        public static int LookupPrice(Price str)
        {
            return Convert.ToInt32(str);
        }
            
        public static void PrintPrice(Price p)
        {
            switch (p)
            {
                case Price.Free:
                    Console.WriteLine("Gratis\n");
                    break;
                case Price.Youth:
                    Console.WriteLine($"Ungdomspris: {LookupPrice(p):C0}\n");
                    break;
                case Price.Standard:
                    Console.WriteLine($"Standardpris: {LookupPrice(p):C0}\n");
                    break;
                case Price.Senior:
                    Console.WriteLine($"Pensionärspris: {LookupPrice(p):C0}\n");
                    break;
                default:
                    break;
            }
        }
        public static void Menu()
        {
            Console.WriteLine("Huvudmeny");
            Console.WriteLine("0 ->För att avsluta");
            Console.WriteLine("1 ->Ungom eller Pensionär");
            Console.WriteLine("2 ->Sällskap");
            Console.WriteLine("3 ->Upprepa tio gånger");
            Console.WriteLine("4 ->Det tredje ordet");
        }
    }
}