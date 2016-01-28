using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethod.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IPet aDog = PetFactory.CreatePet(PetType.Dog);
            aDog.Speak();
            // Cat
            IPet aCat = PetFactory.CreatePet(PetType.Cat);
            aCat.Speak();
        }
    }
}
