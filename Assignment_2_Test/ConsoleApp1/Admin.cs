using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Admin
    {
        private int Admin_ID;
        
        public Admin(int admin_ID)// :base(Name)
        {
            this.Admin_ID = admin_ID;
        }

        public void MainMenu()
        {
            Console.WriteLine("This would display the main menu for the ADMIN");
        }
    }
}
