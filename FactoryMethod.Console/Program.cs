using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FactoryMethod.Console
{
    using AspNetTest.Model;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            ReflectorSample();
        }

        static void FactorySample()
        {
            IPet aDog = PetFactory.CreatePet(PetType.Dog);
            aDog.Speak();
            // Cat
            IPet aCat = PetFactory.CreatePet(PetType.Cat);
            aCat.Speak();
        }

        static void ReflectorSample()
        {
            //var model = (User)Assembly.Load("AspNetTest.Model").CreateInstance(typeof("User"));
            //Console.Write(String.Format("Field1 : {0}  Field2 : {1}", model.Id, model.Name));
        }
    }
}
