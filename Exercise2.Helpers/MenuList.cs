using Exercise2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2.Helpers
{
    public class MenuList
    {
        private List<MenuItem> menuList;
        public MenuList() 
        { 
            menuList = new List<MenuItem>();  
        }

        public void AddMenuItem( int menuIndex, string description)
        {
            menuList.Add(new MenuItem(menuIndex, description));
        }

        public void WriteMenu() 
        {
            foreach (MenuItem item in menuList) 
            {
                Console.WriteLine($"{item.MenuIndex}. {item.Description}");            
            }
        }

    }
}
