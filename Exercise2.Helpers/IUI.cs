using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2.Helpers
{
    public interface IUI
    {
        string GetInput();
        void Write(string message);
        void WriteLine(string message); 
    }   
}
