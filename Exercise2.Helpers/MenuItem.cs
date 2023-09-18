using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2.Helpers
{
    public class MenuItem : Object
    {
        private int _menuIndex;

        public int MenuIndex
        {
            get { return _menuIndex; }
            //set { _menuIndex = value; }
        }
        public string Description { get; }
        public MenuItem(int menuIndex, string description)
        {
            _menuIndex = menuIndex;
            Description = description;
        }
        public override string ToString() => $"{_menuIndex}. {Description}";
    }
}
