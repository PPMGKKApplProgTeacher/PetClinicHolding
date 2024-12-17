using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicHolding
{
    public class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Species { get; set; }

        public Pet(string name, int age, string species)
        {
            Name = name;
            Age = age;
            Species = species;
        }
    }
}
