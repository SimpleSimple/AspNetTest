using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethod.Console
{
    class PetFactory
    {
        public static IPet CreatePet(PetType type)
        {
            switch (type)
            {
                case PetType.Cat:
                    return new Cat();
                case PetType.Dog:
                    return new Dog();
                default: 
                    return null;
            }
        }
    }
}
