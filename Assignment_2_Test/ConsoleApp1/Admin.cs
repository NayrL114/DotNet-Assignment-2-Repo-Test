using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Admin: User
    {
        private int Admin_ID;
        
        public Admin(int admin_ID, string name)// :base(Name)
        {
            this.Admin_ID = admin_ID;
            this.Name = name;
        }

        public void MainMenu()
        {
            Console.WriteLine("This would display the main menu for the ADMIN");
            Console.WriteLine("The Admin ID is {0} and the Name is {1}", this.Admin_ID, this.Name);
        }
    }
}
