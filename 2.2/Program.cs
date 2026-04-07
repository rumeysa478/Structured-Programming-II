using System.Net.NetworkInformation;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Metadata;
using System.Diagnostics;
using vize.çalışma;
using System.Drawing;

namespace vize.çalışma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //W1
            //-------------------------------//
            //creating an instance of class
            ClassName clas = new ClassName();

            //accesing properties
            clas.Attribute = "atr";

            //accesing methods
            clas.MethodName();


            //W2
            //-------------------------------//
            Staff staff = new();
            // Set value to public fields directly
            staff.LastName = "Zeki";

            // Get staff ID
            int staffId = staff.StaffId;

            // get staff' last name directly (without property)
            string staffName = staff.LastName;

            // get staff' first name indirectly (using get accessor)
            string staffName2 = staff.FirstName;

            //W3
            //-------------------------------//
            /*
            +public: Accessible from anywhere.
            -private: Accessible only within the defining class.
            -protected: Accessible in own class and derived classes (inherited) MİRAS.
            +internal: Accessible within the same assembly (typically, the same project).
            +protected internal: Accessible within the same assembly or by derived classes (even if they are 
            in a different assembly).
            -private protected: Accessible in the defining class and derived types within the same 
            assembly. 
            */
            //internal, protected internal, public erişilir.

            //W4
            //-------------------------------//
            //virtual -> derived class, base classın methodlarına
            //ulaşabilsin diye base class tarafından kullanılır
            //override -> methodları derive, miras almak için kullanılır
            //sealed -> prevents a class from being inherited, overrided
            /*
            // Constructor with three arguments
            public SportCar(string brand, string make, string model, int year) : base(brand)
            {
                Make = make;
                Model = model;
                Year = year;
                TransmissionType = "Automatic"; // Default value for TransmissionType
            }
            */

            //W5
            //-------------------------------//
            /*Compile-Time (Static) Polymorphism*/
            //method overloading, operator overloading
            // multiple methods with the same name but different parameter count or different data types

            /*Run - Time(Dynamic) Polymorphism*/
            //Virtual/Override Keywords
            //Abstract Classes: soyut sınıf: kendisinden object, instance üretilemeyen no body(new Shape() denemez)
            //Interface: sınıfın neler yapabileceğini belirten ama bu işlerin nasıl
            //yapılacağını söylemeyen
            //Interface isimleri her zaman büyük I harfi ile başlar, gövdesiz method

            //dynamic kullanıldığında compile time eroru verilmez eğer eror varsa
            //run timea kadar beklenir
            dynamic dynCircle = new InterfaceCircle(2.0);
            dynamic dynRectangle = new Rectangle(3.0, 4.0);

            //Upcasting converts a derived‐class reference to a base‐class type.
            Shape shape1 = new Circle(5.0); // Upcasting
            Console.WriteLine($"Upcasting Circle Area: {shape1.Area()}");
            //Downcasting converts a base‐class reference back to a derived‐class type.

            //W6
            //-------------------------------//
            // readonly field: can only be assigned a value in the constructor or at field declaration
            // readonly property: only has a getter
            //readonly field cannot be changed outside constructor
        }
    }

    //W1
    class ClassName
    {
        // Properties (data members)/variables
        public string Attribute { get; set; }

        // Methods (behaviors)
        public void MethodName()
        {
            //static olmadığı için instance gerekir
        }
        /*property ->sıfat, veriyi saklar/döndürür ,parametre yok
        başka bir classda, bulunduğu classın instanceı oluşturulmazsa çağırılamaz
        sadece bulunduğuclass içinde kullanılabilir.*/
        //method   ->eylem, veriye işlem yapar     ,parametre var
    }

    //W2
    class Staff
    {
        //instance variable -> belong to an instance of class, instance kendine o fieldı oluşturur.
        //static variable -> belong to an specific class, bütün instanceler aynı fieldı kullanır, instance olmadan da kullanılır.

        // Private fields for sensitive data
        private DateTime dateOfBirth;

        //static field shared by all instances
        public static int staffId = 0;

        //properties should get or set values, must be public
        //1
        public string LastName { get; set; }
        //2
        public int StaffId
        {
            get { return staffId; }
            set { staffId = value; }
        }
        //3
        public string FirstName
        {
            get => FirstName;
            set => FirstName = value;

        }
        /*
        default constructor -> no parameters
        parameterized constructor -> yes parameters
        ............................
        Copy Constructor -> creates a new object by
        copying the values of another object, implemented manually
        public Araba(Araba eskiAraba) 
        { 
            this.Model = eskiAraba.Model;
        }
        ............................
        Static Constructor ->  initialize(başlatmak) static members of the class
        static Staff()
        {
            companyName = "Istanbul University";
            Console.WriteLine($"Company Name: {companyName}");
        } 
        */
    }

    //W3
    public class BankAccount
    {
        private decimal _balance; //Only accessible in BankAccount
        public string AccountNumber { get; private set; } // Public getter, private setter
        protected string OwnerName; // Accessible in BankAccount and derived classes
        internal string BankName; // Accessible in the same assembly
        protected internal string BranchCode; // Accessible in the same assembly OR derived classes
        private protected string InternalId; // Accessible in the same class and derived class in the same assembly
        //SavingsAccount : BankAccount //(miras_edilen,derived class,child : miras_eden,base class,parent)

    }

    //W4
    public class Parent
    {
        public virtual void Log(string message)
        {
            Console.WriteLine("Base: " + message);
        }

        public void Show()
        {
            Console.WriteLine("BaseClass Show");
        }
    }
    public class Child : Parent
    {
        public override void Log(string message)
        {
            base.Log(message); // call parent implementation
            Console.WriteLine("Parent: " + message);
        }

    }

    public class Person
    {
        public string Name;
        public Person(string name)
        {
            Name = name;
        }
    }

    public class Student : Person
    {
        public int Id;
        public Student(string name, int id) : base(name)
        {
            this.Id = id;
        }
    }

    //W5
    public class StringConcat
    {
        //METHOD OVERLOADING
        // Method for int parameters       
        public int Calc(int price, int vat)
        {
            return price + (price * vat / 100);
        }
        // Method for double parameters       
        public double Calc(double price, double vat)
        {
            return price + (price * vat / 100);
        }


        //OPERATOR OVERLOADING
        public string text;
        // Constructor (Yapıcı Metot) olmazsa "new StringConcat" hata verir!
        //if method has same name with class = constructer method
        public StringConcat(string t)
        {
            text = t;
        }
        public static StringConcat operator %(StringConcat sc1, StringConcat sc2)
        {
            return new StringConcat(sc1.text + sc2.text);
        }
        // overload % operator for StringConcat and string
        public static StringConcat operator %(StringConcat sc, string str)
        {
            return new StringConcat(sc.text + str);
        }
    }

    //ABSTRACT
    // Abstract property - contains no implementation bu yüzden override
    public abstract class Shape
    {
        public abstract double Area(); // no body
    }
    public class Circle : Shape
    {
        public double Radius { get; }
        //!!!!!!!!!!ÖNEMLİ!!!!!!!!!!!!!!!!!!
        public Circle(double r) => Radius = r;
        public override double Area() // must implement
        => Math.PI * Radius * Radius;
    }

    //INTERFACE
    //bütün methodlar implement edilmeli
    public interface IShape
    {
        double Area();
    }
    // Class implementing the interface
    public class Circle : IShape
    {
       public double Radius { get; }
        public Circle(double r) => Radius = r;
        // Implementation of the method from the interface
        public double Area() => Math.PI * Radius * Radius;

    }
    interface IPrintable
    {
        void Print();
    }

    // Interface for saveable objects
    public interface ISaveable
    {
        void Save();
        void Load(string id);
    }

    // Document class that implements both printable and saveable interfaces
    public class Document : IPrintable, ISaveable
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Document(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        // Method from the IPrintable interface
        public void Print()
        {
            Console.WriteLine($"Printing document: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Content: {Content}");
            Console.WriteLine("Printing completed.");
        }

        // Methods from the ISaveable interface
        public void Save()
        {
            Console.WriteLine($"Saving document: {Title}");
            // Saving operations are performed here
            Console.WriteLine("Save operation completed.");
        }

        public void Load(string id)
        {
            Console.WriteLine($"Loading document, ID: {id}");
            // Loading operations are performed here
            Console.WriteLine("Load operation completed.");
        }
    }
    //W6
    public class Ogrenci
    {
        //required
        public required string Ad { get; set; } // Zorunlu
        public int Yas { get; set; }            // İsteğe bağlı
        // DOĞRU KULLANIM:
        //var ogrenci1 = new Ogrenci { Ad = "Ahmet" };
    }
    // The partial keyword allows splitting a class definition across multiple files
    // Partial methods must be declared in one part and implemented in another
    // Partial methods must return void and be private by default
    //1st part
    public partial class Employee
    {
        // Fields
        private int _id;
        private string _name;
        private DateTime _hireDate;

        // Properties
        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public DateTime HireDate { get => _hireDate; set => _hireDate = value; }

        // Constructor
        public Employee(int id, string name)
        {
            _id = id;
            _name = name;
            _hireDate = DateTime.Now;
        }

        // Basic methods in the first part
        public void DisplayBasicInfo()
        {
            Console.WriteLine($"Employee ID: {_id}");
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine($"Hire Date: {_hireDate.ToShortDateString()}");
        }
    }
    //2nd part
    //Implementation part
    public partial class Employee
    {
        // Additional fields for the second part
        private decimal _salary;
        private string _department;

        // Additional properties
        public decimal Salary { get => _salary; set => _salary = value; }
        public string Department { get => _department; set => _department = value; }

        // Methods specific to the second part
        public void SetEmploymentDetails(decimal salary, string department)
        {
            _salary = salary;
            _department = department;
        }

        public void DisplayEmploymentDetails()
        {
            Console.WriteLine($"Department: {_department}");
            Console.WriteLine($"Salary: ${_salary}");
        }

        // This method uses data from both parts of the class
        public void DisplayAllInfo()
        {
            Console.WriteLine("\n--- Employee Complete Information ---");
            DisplayBasicInfo();
            DisplayEmploymentDetails();
            Console.WriteLine($"Years of Service: {CalculateYearsOfService()}");
            Console.WriteLine("-------------------------------------");
        }

        // Private helper method
        private int CalculateYearsOfService()
        {
            return DateTime.Now.Year - HireDate.Year;
        }
    }

    // Example of partial interface
    public partial interface IEmployee
    {
        void CalculateTax();
    }

    // Second part of the partial interface
    public partial interface IEmployee
    {
        void CalculateBonus();
    }

    // Implementing the partial interface
    public class Manager : IEmployee
    {
        public void CalculateBonus()
        {
            Console.WriteLine("Manager bonus calculated");
        }

        public void CalculateTax()
        {
            Console.WriteLine("Manager tax calculated");
        }
    }
    public class Developer : IEmployee
    {
        public void CalculateBonus()
        {
            Console.WriteLine("Developer bonus calculated");
        }

        public void CalculateTax()
        {
            Console.WriteLine("Developer tax calculated");
        }
    }

    //READONLY
    public class OgrenciProfil
    {
        // readonly field: can only be assigned a value in the constructor or at field declaration
        public readonly int OgrenciNo;
        public readonly string KayitTarihi;          // Normal properties - defined as nullable
        public string? Ad { get; set; }
        public string? Soyad { get; set; }

        // readonly property: only has a getter
        public string TamAd => $"{Ad} {Soyad}";

        // Different constructor types
        public OgrenciProfil(int ogrenciNo)
        {
            // readonly field can be assigned a value in the constructor
            OgrenciNo = ogrenciNo;
            KayitTarihi = DateTime.Now.ToString("dd.MM.yyyy");
        }
        public OgrenciProfil(int ogrenciNo, string ad, string soyad) : this(ogrenciNo)
        {
            Ad = ad;
            Soyad = soyad;
        }

        public void BilgileriGoster()
        {
            Console.WriteLine($"Öğrenci No: {OgrenciNo}");
            Console.WriteLine($"Ad Soyad: {TamAd}");
            Console.WriteLine($"Kayıt Tarihi: {KayitTarihi}");
            Console.WriteLine("---------------------");
        }

        public void AdDegistir(string yeniAd)
        {
            // Normal property can be changed
            Ad = yeniAd;

            // This would cause an error, readonly field cannot be changed outside constructor
            // OgrenciNo = 5555;
        }
    }

    // readonly struct example: the entire struct becomes immutable
    public readonly struct Koordinat
    {
        public readonly double X { get; }
        public readonly double Y { get; }

        public Koordinat(double x, double y)
        {
            X = x;
            Y = y;
        }

        // readonly method: guarantees that it won't modify the struct's state
        public readonly double MesafeHesapla() => Math.Sqrt(X * X + Y * Y);

        public readonly override string ToString() => $"({X}, {Y})";
    }


}




