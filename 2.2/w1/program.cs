using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace ConsoleApp1
{

    public class CalculateFruit
    {
        public static double Calculate(double price, double VAT)
        {
            return price + (price * VAT / 100);
        }
    }


    public class Student
    {
        public string gradType;//class attribute/variable
        //aproachable only in student class

        public string Name;
        public int Number;
        public void Study()
        {
            gradType = "undergrad";
            Console.WriteLine("student job is to study his courses");
        }

        public void TakeExam()
        {
            gradType = "bachelor";
            Console.WriteLine("another job of student is to take exam");
        }

    }

    public class Car
    {
        public string Make;
        public string Model;
        public int Year;

        public void StartEngine()
        {
            Console.WriteLine($"The {Year} {Make} {Model} engine has started.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //double number = new double();
            /*
            Console.WriteLine("please enter the apple price");
            int apple = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("please enter the vat rate");
            double vat = Convert.ToDouble(Console.ReadLine());
            double total = apple * vat + apple;
            */

            //creating an instance of CalculateFruit class
            //CalculateFruit fruit = new CalculateFruit();
            //double totalprice = fruit.Calculate(30, 18);


            double totalprice = CalculateFruit.Calculate(30, 18);
            Console.WriteLine(totalprice);

            int number = new int();
            Student ogrenci = new Student();
            ogrenci.Study();
            ogrenci.TakeExam();
            ogrenci.gradType = "under gradiation";
            ogrenci.Name = "r";
            ogrenci.Number = 548;
            Console.WriteLine($"Name:{ogrenci.Name}, Number:{ogrenci.Number}");
            //eğer static koyarsak new kullanmamıza gerek kalmaz

            Car car1 = new Car();
            car1.StartEngine();
        }
    }
}
