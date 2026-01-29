
using System;
using System.Collections.Generic;

namespace InheritancePolimorphism
{
    class Program
    {
       static void Main(string[]Arg)
       {

          Dog bobby = new();
          Cat Otonio = new();

          bobby.MakeSound();
          Otonio.MakeSound();


           bobby.Eat();
           Otonio.Eat();   


            List<Animal> animals = new ();
                animals.Add(new Dog());
                animals.Add(new Cat());

        foreach (Animal animal in animals)
        {
            animal.MakeSound();
        }
           
       }
    }   
    public interface IAnimal
    {
        void Eat();
    }
      public class Animal : IAnimal
      {
        public Animal()
        {
            
        }
            public virtual void MakeSound()
            {
                  Console.WriteLine("Some generic animal sound");              
            }

        public virtual void Eat()
        {
            Console.WriteLine("Some generic animal food");
        }

        
      }

        public class Dog : Animal
        {
           public override void Eat()
            {
                Console.WriteLine("Kibble");
            }

            public override void MakeSound()
            {
                Console.WriteLine("Bark");
            }
        }
        public class Cat : Animal
        {
            public override void Eat()
            {
                Console.WriteLine("Kibble");
            }

            public override void MakeSound()
            {
                    Console.WriteLine("Meow");
            }
        }  
}

