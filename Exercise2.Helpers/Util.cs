using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2.Helpers
{
    public static class Util
    {
        public static string SelectWord(string word, int at)
        {
            // Split string delimted by space. If there are more than one space 
            // between words discard spaces.
            var words = word.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string result = (words.Length > at) ? words.ElementAt(at).ToString() : "";
            return result;
        }

        public static void NoValidInput() => Console.WriteLine("Ogiltig inmatning\n");
        
        public static bool TestForString(string str) => 
            string.IsNullOrWhiteSpace(str) ? false : true;  
        

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
    }
}
