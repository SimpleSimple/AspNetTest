

namespace FactoryMethod.Console
{
    using System;

    class Dog : IPet
    {
        public void Speak()
        {
            Console.WriteLine("I'm a Dog");
        }
    }

    class Cat : IPet
    {
        public void Speak()
        {
            Console.WriteLine("I'm a Cat");
        }
    }

    enum PetType
    { 
        Cat, Dog
    }
}
