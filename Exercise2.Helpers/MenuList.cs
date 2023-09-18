using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2.Helpers
{
    public class MenuList : Object
    {
        private List<MenuItem> menuList;
        public MenuList()
        {
            menuList = new List<MenuItem>();
        }

        public void AddMenuItem(int menuIndex, string description)
        {
            menuList.Add(new MenuItem(menuIndex, description));
        }

        public List<MenuItem> GetMenuItems()
        {
            return menuList;
        }
    }
}
