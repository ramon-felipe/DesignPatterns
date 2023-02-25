using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Iterator
{
    public class Car
    {
        public string Name { get; set; } = "";

        public override string ToString()
        {
            return $"Car's name: {this.Name}";
        }
    }
}
