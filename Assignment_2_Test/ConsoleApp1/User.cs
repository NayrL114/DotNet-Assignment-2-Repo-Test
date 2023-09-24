using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal abstract class User
    {
        /*public string firstName { get; set; }
        public string lastName { get; set; }*/

        public string Name { get; set; }

        /*
        public Person(string name)
        {
            this.Name = name;
        }
        */
    }
}

/*
public abstract class Person
{
    //public int Id { get; set; }
    public string Name { get; set; }
    //public string Description { get; set; }
    public Person(string personName)
    {
        this.Name = personName;
    }

    //public virtual void DisplayMainMenu();

}
*/