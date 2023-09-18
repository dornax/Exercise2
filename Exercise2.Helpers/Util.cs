using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise2.Helpers
{
    public static class Util
    {
        public static string SelectWord(string word, int at)
        {
            // Split string delimted by space. If there are more than one whitespace 
            // between words discard spaces.
            var words = word.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string result = (words.Length > at) ? words.ElementAt(at).ToString() : "";
            return result;
        }

        public static string AskForString(string prompt, IUI ui)
        {
            string answer="";
            
            while (true)
            {
                ui.Write($"{prompt}");
                answer = ui.GetInput();
                if (TestForString(answer)) break;
                else NoValidInput(ui);
            }
            return answer;
        }

        public static int AskForInt(string prompt, IUI ui)
        {
            bool success = false;
            int value=-1;
            while (!success)
            {
                string input = AskForString(prompt, ui);

                value = TestForInt(input);
                if (value != -1)
                {
                    success = true;
                    return value;
                }
                else NoValidInput(ui);
            }
            return value;
        }
        public static void NoValidInput(IUI ui) => ui.WriteLine("Ogiltig inmatning");
        public static bool TestForString(string str) =>
            string.IsNullOrWhiteSpace(str) ? false : true;

        public static int TestForInt(string str)
        {
            if (int.TryParse(str, out int value))
            {
                return value;
            }
            return -1;      // No success 
        }
    }
}

