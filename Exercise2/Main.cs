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
        public IUI ui;
        public Main(IUI ui)
        {
            this.ui = ui;
        }   
        MenuList menuList = new MenuList();
        public void Run()
        {
            bool quit = false;
            NewMenu();
            do
            {
                WriteMenu();
                string input = ui.GetInput();
                switch (input)
                {
                    case MenuHelpers.Quit:
                        quit = true;
                        break;
                    case MenuHelpers.YouthOrOlder:
                        PrintTicket(YouthOrOlder());
                        break;
                    case MenuHelpers.Company:
                        Company();
                        break;
                    case MenuHelpers.InputTimesX:
                        InputTimesX();
                        break;
                    case MenuHelpers.ThirdWord:
                        ThirdWord();
                        break;
                    default:
                        Util.NoValidInput(ui);
                        break;
                }

            } while (!quit);
        }
 
        private void ThirdWord()
        {

            ui.WriteLine("Mata in en mening med minst 3 ord.");
            bool foundWord = false;

            while (!foundWord)
            {

                string input = ui.GetInput();

                if (Util.TestForString(input))  // Test if input is valid string
                {
                    string word = Util.SelectWord(input, 2); // Select third word

                    if (word != "")  // Check if word is blank
                    {
                        ui.WriteLine($"Det tredje ordet i meningen är {word}.\n");
                        foundWord = true;
                    }
                    else Util.NoValidInput(ui); //Print to Console 
                }
                else Util.NoValidInput(ui);
            }
        }
 
        private void InputTimesX()
        {

            int numberOfInputs = 10;
            string[] text = new string[numberOfInputs];
            ui.WriteLine($"Mata in valfri text {numberOfInputs} gånger.");
            ui.WriteLine("Inmatad text kommer att skrivas ut utan radavbrott.");

            for (int i = 0; i < numberOfInputs; i++)
                text[i] = Util.AskForString($"Inmatning nr: {i + 1}\n", ui);

            WriteTimesX(text, numberOfInputs);

        }

        private void WriteTimesX(string[] text, int size)
        {
            for (int i = 0; i < size; i++)
            {
                ui.Write($"{i + 1}. {text[i]}");
                if (i < size - 1) ui.Write(", "); // Write ', ' between strings not at end
            }

            ui.Write("\n\n");

        }

        private void Company()
        {
                                    
            int personsInCompany = Util.AskForInt("Hur många är ni i ert sällskap? ", ui);
            int sum = 0;
            for (int i = 0; i < personsInCompany; i++)
            {
                sum += GetPrice(YouthOrOlder());
            }
            ui.WriteLine($"Totalkostnad {sum:C0} för {personsInCompany} personer.\n");
            
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
            bool success = false;
            Price price = Price.NotDefined;
            while (!success)
            {
                int age = Util.AskForInt("Ange ålder: ", ui);
                               
                if (age != -1 && age >= 0)
                {
                    if (age < 5 || age > 100) price = Price.Free;
                    else if (age > 4 && age < 20) price = Price.Youth;
                    else if (age > 64 && age < 101) price = Price.Senior;
                    else if (age > 19 && age < 65) price = Price.Standard;
                    success = true;
                    break;
                }
                Util.NoValidInput(ui);
                price = Price.NotDefined;
            }
            return price;
        }

        private int GetPrice(Price p)
        {
            return Convert.ToInt16(p);
        }

        private void PrintTicket(Price p)
        {
            switch (p)
            {
                case Price.Free:
                    ui.WriteLine("Gratis\n");
                    break;
                case Price.Youth:
                    ui.WriteLine($"Ungdomspris: {GetPrice(p):C0}\n");
                    break;
                case Price.Standard:
                    ui.WriteLine($"Standardpris: {GetPrice(p):C0}\n");
                    break;
                case Price.Senior:
                    ui.WriteLine($"Pensionärspris: {GetPrice(p):C0}\n");
                    break;
                case Price.NotDefined:
                    break;
                default:
                    break;
            }
        }

        private void WriteMenu() 
        {
            foreach (var item in menuList.GetMenuItems())
            {
                ui.WriteLine(item.ToString());
            }
        }

        private void NewMenu()
        {

            menuList = new MenuList();
            
            menuList.AddMenuItem(Convert.ToInt16(MenuHelpers.Quit), "->För att avsluta");
            menuList.AddMenuItem(Convert.ToInt16(MenuHelpers.YouthOrOlder), "->Ungdom eller Pensionär");
            menuList.AddMenuItem(Convert.ToInt16(MenuHelpers.Company), "->Sällskap");
            menuList.AddMenuItem(Convert.ToInt16(MenuHelpers.InputTimesX), "->Upprepa tio gånger");
            menuList.AddMenuItem(Convert.ToInt16(MenuHelpers.ThirdWord), "->Det tredje ordet");
            
        }
    }
}


