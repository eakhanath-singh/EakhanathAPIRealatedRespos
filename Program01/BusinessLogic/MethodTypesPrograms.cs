using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Program01.BusinessLogic
{
    public class MethodTypesPrograms
    {
        #region Overload
        /// <summary>
        /// Using Add function to define
        /// </summary>
        public class OverloadConcpet()
        {
            /// <summary>
            /// Calculator program to define method overloading 
            /// Method overloading is having multiple classes with same and different parameters as below
            /// Adding numbers using same method name but different parameters and parameter types
            /// </summary>
            public int Add(int a, int b)
            {
                return a + b;
            }
            /// <summary>
            /// Here the method name is same but having new c variable and passing as parameter
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <param name="c"></param>
            /// <returns></returns>
            public int Add(int a, int b, int c)
            {
                return a + b + c;
            }
            /// <summary>
            /// Here same method and change in parameter data types and converting the result set to integer
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <returns></returns>
            public int Add(double a, double b)
            {
                return Convert.ToInt32(a + b);
            }
        }

        #endregion


        #region OVerride
        /// <summary>
        /// Override is keyword which can help to create same method as from base class only if have any virtual or abstarct method are used 
        /// To use or to implement same virtual or abstart methods from base class in derived class use override keyword.
        /// </summary>
        public class Animal()
        {
            // Virtaul keyword can be used to create a method which can not be used in derived classes
            public virtual string Speak()
            {
                return ("Animals not speak they will make sounds");
            }
        }

        public class Dog(): Animal
        {
            // To use same method name and signature we can give override keyword as below for abstarct or virtual base class methods
            public override string Speak()
            {
                return ("Dog Barks");
            }
        }
        #endregion

        #region Method Hiding
        public class BaseClass()
        {
            // void methods will not ask for return values
            public void Show()
            {
                Console.WriteLine("BaseClass show");
            }
        }

        public class DerivedClass(): BaseClass
        {
            /// <summary>
            /// While using new keyword , this will hide when we call base class methods 
            /// the concpet of hiding the derived class methods is called method hiding.
            /// </summary>
            public new void Show()
            {
                Console.WriteLine("Derived Class Show");
            }
        }

        #endregion

        #region Abstract Methods
        /// Abstract class will have both abstarct methods and regular methods where abstarct methods will only fine declarations but not body like below abstarct method in class
        /// abstarct class and method will have abstract keyword <summary>
        /// Abstract class will have both abstarct methods and regular methods where abstarct methods will only fine declarations but not body like below abstarct method in class
        /// </summary>        //
        /// Abstarct class
        public abstract class Shape
        {
            /// <summary>
            /// Abstract method with only declaration but no body
            /// </summary>
            /// <returns></returns>
            public abstract double GetArea();

            /// <summary>
            /// Here we have regular method but we can not use any return type methods and must be have body
            /// </summary>
            public void Display()
            {
                Console.WriteLine("This is a Shape Value:");
            }

        }

        /// <summary>
        /// We must user override class for abstract cause due to it dosn't have declarations
        /// </summary>
        public class Circle: Shape
        {
            private double raduis;

            /// <summary>
            /// Created a constructor
            /// </summary>
            /// <param name="raduis"></param>
            public Circle(double raduis)
            {
                this.raduis = raduis;
            }
            /// <summary>
            /// Usign override keyword to use shape class properties
            /// </summary>
            /// <returns></returns>
            public override double GetArea()
            {
                return Math.PI * raduis * raduis;
            }
        }

        #endregion

        #region Interface class
        /// <summary>
        /// This interface class will have only declarations where the body will be implemented in derived class or classes which use this interface class
        /// It is a good partice to user I letter for interface class names
        /// defaut type is public methods
        /// </summary>
        public interface IAnimalSoundsAndEat
        {
            void Sound();
            void Eat(string foddtype);
        }

        /// <summary>
        /// Added Interface class as an inhert and used all the methods in this derived class.
        /// 
        /// </summary>
        public class DogBehaviour : IAnimalSoundsAndEat
        {
            public void Sound()
            {
                Console.WriteLine("Dog Barks");
            }

            public void Eat(string foodtype)
            {
                Console.WriteLine($"Dog Eats this type of food: {foodtype}");
            }
        }

        ///// <summary>
        ///// Here we must use all the methods from Interface class else it will show error please check the below code by uncommenting 
        ///// </summary>
        //public class DogBehavioura : IAnimalSoundsAndEat
        //{
        //    public void Eat(string foodtype)
        //    {
        //        Console.WriteLine($"Dog Eats this type of food: {foodtype}");
        //    }
        //}

        #endregion

        /// <summary>
        /// Calling the above methods in Main class
        /// </summary>
        public class GetOverloadclass ()
        {
            public static void Main()
            {
                // overload methods 
                OverloadConcpet OverloadValues = new OverloadConcpet();
                Console.WriteLine(OverloadValues.Add(12, 12));
                Console.WriteLine(OverloadValues.Add(12, 18,16));
                Console.WriteLine(OverloadValues.Add(12.25, 12.50));
                // here we will get Add overload methods result

                //Over ride 
                Animal animal = new Animal();
                Console.WriteLine(animal.Speak());// output is Animals not speak they will make sounds
                Dog dog = new Dog();
                Console.WriteLine(dog.Speak());// output is Dog barks
                Animal animal2 = new Dog();
                Console.WriteLine(animal2.Speak()); // output is Dog barks --- that is getting only value from child class, so base class properties will be override

                // Method Hiding
                BaseClass baseClass = new BaseClass(); 
                baseClass.Show(); // output Base class
                DerivedClass derivedClass = new DerivedClass();
                derivedClass.Show(); // Output derived class
                /// Here we are creating baseclass with derivde class this is because to using all methods form base and derived class for more clear view check the abstract region and results.
                BaseClass basefromDer = new DerivedClass();
                basefromDer.Show();// output base class 
                // where new keyword will hide this derived class method. // so output will be form base class method ,, basically child class properties are in hide

                ///Abstract method
                ///using base class to call derived class
                Shape baseshape = new Circle(10);// this will call and get radius to 10
                baseshape.Display();// we will get  string output
                baseshape.GetArea();// we will get the values Math.PI *10*10

                ///Interface method calling
                IAnimalSoundsAndEat animalSoundsAndEat = new DogBehaviour();
                animalSoundsAndEat.Sound();
                animalSoundsAndEat.Eat("Home_Waste_food");
            }
        }
    }
}
