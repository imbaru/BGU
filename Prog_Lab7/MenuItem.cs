using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_Lab7
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public MenuItem(int _Id, string _Name)
        {
            Id = _Id;
            Name = _Name;
        }

        public void Show()
        {
            Console.WriteLine($"{Id}. {Name}");
        }
    }
}
