using Exercise2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    public class Main
    {
        MenuList menuList = new();
        public void Run()
        {
            bool quit = false;
            NewMenu();
            do
            {
                menuList.WriteMenu();
                string input = Console.ReadLine();
                switch (input)
                {
                    case MenuHelpers.Quit:
                        quit = true;
                        break;
                    case MenuHelpers.YouthOrOlder:
                        PrintPrice(YouthOrOlder());
                        break;
                    case MenuHelpers.Company:
                        Company();
                        break;
                    case MenuHelpers.InputTimes10:
                        InputTimes10();
                        break;
                    case MenuHelpers.ThirdWord:
                        ThirdWord();
                        break;
                    default:
                        Util.NoValidInput();
                        break;
                }

            } while (!quit);
        }
        private void ThirdWord()
        {

            Console.WriteLine("Mata in en mening med minst 3 ord.");
            bool foundWord = false;

            while (!foundWord)
            {

                string input = Console.ReadLine();

                if (Util.TestForString(input))  // Test if input is valid string
                {
                    string word = Util.SelectWord(input, 2); // Select third word

                    if (word != "")  // Check if word is blank
                    {
                        Console.WriteLine($"Det tredje ordet i meningen är {word}.\n");
                        foundWord = true;
                    }
                    else Util.NoValidInput(); //Print to Console 
                }
                else Util.NoValidInput();
            }
        }



        private void InputTimes10()
        {

            int numberOfInputs = 10;
            string[] text = new string[numberOfInputs];
            Console.WriteLine($"Mata in valfri text {numberOfInputs} gånger.");
            Console.WriteLine("Inmatad text kommer att skrivas ut utan radavbrott.");

            for (int i = 0; i < numberOfInputs; i++)
            {
                Console.WriteLine($"Inmatning nr: {i + 1}");
                string input = Console.ReadLine();

                if (Util.TestForString(input))  // Test if input is valid string
                {
                    text[i] = input;
                }
                else
                {
                    Util.NoValidInput();  //Print to Console 
                    i--;
                }
            }

            for (int i = 0; i < numberOfInputs; i++)
            {
                Console.Write($"{i + 1}. {text[i]}");
                if (i < numberOfInputs - 1) Console.Write(", "); // Write ', ' between strings not at end
            }

            Console.Write("\n\n");

        }
        private void Company()
        {
            Console.Write("Hur många är ni i ert sällskap? ");
            string input = Console.ReadLine();

            int personsInCompany = Util.TestForInt(input);
            int sum = 0;

            if (personsInCompany != -1)
            {
                for (int i = 0; i < personsInCompany; i++)
                {
                    sum += GetPrice(YouthOrOlder());
                }
                Console.WriteLine($"Totalkostnad {sum:C0} för {personsInCompany} personer.\n");
            }
        }

        private enum Price
        {
            Free = 0,
            Youth = 80,
            Standard = 120,
            Senior = 90,
            NotDefined = -1,

        }
        private Price YouthOrOlder()
        {
            bool succes = false;
            Price price = Price.NotDefined;
            while (!succes)
            {
                Console.Write("Ange ålder: ");
                string input = Console.ReadLine();

                int age = Util.TestForInt(input);
                if (age != -1 && age >= 0)
                {
                    if (age < 5 || age > 100) price = Price.Free;
                    else if (age > 4 && age < 20) price = Price.Youth;
                    else if (age > 64 && age < 101) price = Price.Senior;
                    else if (age > 19 && age < 65) price = Price.Standard;
                    succes = true;
                    break;
                }
                Util.NoValidInput();
                price = Price.NotDefined;
            }
            return price;
        }

        private int GetPrice(Price p)
        {
            return Convert.ToInt16(p);
        }

        private void PrintPrice(Price p)
        {
            switch (p)
            {
                case Price.Free:
                    Console.WriteLine("Gratis\n");
                    break;
                case Price.Youth:
                    Console.WriteLine($"Ungdomspris: {GetPrice(p):C0}\n");
                    break;
                case Price.Standard:
                    Console.WriteLine($"Standardpris: {GetPrice(p):C0}\n");
                    break;
                case Price.Senior:
                    Console.WriteLine($"Pensionärspris: {GetPrice(p):C0}\n");
                    break;
                case Price.NotDefined:
                    break;
                default:
                    break;
            }
        }
        private void NewMenu()
        {

            menuList = new MenuList();
            
            menuList.AddMenuItem(Convert.ToInt16(MenuHelpers.Quit), "->För att avsluta");
            menuList.AddMenuItem(Convert.ToInt16(MenuHelpers.YouthOrOlder), "->Ungdom eller Pensionär");
            menuList.AddMenuItem(Convert.ToInt16(MenuHelpers.Company), "->Sällskap");
            menuList.AddMenuItem(Convert.ToInt16(MenuHelpers.InputTimes10), "->Upprepa tio gånger");
            menuList.AddMenuItem(Convert.ToInt16(MenuHelpers.ThirdWord), "->Det tredje ordet");
            
        }
    }
}


