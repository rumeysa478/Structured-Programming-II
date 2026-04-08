namespace vize.exercise
{
    public class Sphere
    {
        //Let the class have class variables named radius (𝑟),
        //surface area and volume. 
        //Let the radius property be modifiable and accessible from outside,
        //but the surface area and volume properties can only be accessed
        //and modified from inside the class.
        public double _radius;
        private double _surface_area;
        private double _volume;
        
        //Alternatively, verifying the radius is greater than zero using set method of the variable. If 
        //the user sets negative value to the radius,
        //set method should set it to 1. 
        public double Radius
        {
            get { return _radius; }
            set
            {
                if (value < 0)
                    _radius = value;
                else
                    _radius = value;
                // Yarıçap her değiştiğinde alan ve hacmi otomatik güncelleyelim
                SurfaceAreaCalculate();
                VolumeCalculate();
            }
        }
        private double SurfaceArea { get { return _surface_area; } }
        private double Volume { get { return _volume; } }

        //Create two constructor methods that
        //take int r and double r value accordingly. 
        public Sphere(int r) //void ekleme
        {
           Radius = r;
            // Property üzerinden atama yaparak
            // 'set' kontrolünü çalıştırıyoruz
        }
        public Sphere(double r)
        {
            Radius = r;
        }

        //Verify that the radius(𝑟) is greater than zero.
        //This method should be called from two constructor methods.
        private void ValidateRadius(double r)
        {
            if (r <= 0)
            {
                throw new ArgumentException("Yarıçap (r) sıfırdan büyük olmalıdır!");
            }
        }

        //Let the sphere class have methods named surface areaCalculate and 
        //volumeCalculate.
        public double SurfaceAreaCalculate()
        {
            _surface_area = 4 * Math.PI * Math.Pow(_radius, 2);
            return _surface_area;
        }
        public double VolumeCalculate()
        {
            _volume = (4.0 / 3.0) * Math.PI * Math.Pow(_radius, 3);
            return _volume;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"--- Küre Bilgileri (r: {_radius}) ---");
            Console.WriteLine($"Yüzey Alanı: {_surface_area:F2}");
            Console.WriteLine($"Hacim: {_volume:F2}");
            Console.WriteLine();
        }

    }

    //Q2
    public class arrayControl
    {
        // Dizilerin istatistiklerini tutacak özellikler (Properties)
        public int Count1 { get; private set; }
        public double Avg1 { get; private set; }
        public double Min1 { get; private set; }
        public double Max1 { get; private set; }
        public double Median1 { get; private set; }

        public int Count2 { get; private set; }
        public double Avg2 { get; private set; }
        public double Min2 { get; private set; }
        public double Max2 { get; private set; }
        public double Median2 { get; private set; }

        private double[] _arr1;
        private double[] _arr2;

        // Constructor: İki diziyi dışarıdan alır ve istatistikleri hesaplayıp saklar
        public arrayControl(double[] a1, double[] a2)
        {
            _arr1 = a1;
            _arr2 = a2;

            // 1. Dizi İstatistikleri
            Count1 = a1.Length;
            Avg1 = a1.Average();
            Min1 = a1.Min();
            Max1 = a1.Max();
            Median1 = CalculateMedian(a1);

            // 2. Dizi İstatistikleri
            Count2 = a2.Length;
            Avg2 = a2.Average();
            Min2 = a2.Min();
            Max2 = a2.Max();
            Median2 = CalculateMedian(a2);
        }

        // Medyan (Ortanca Değer) Hesaplama Metodu
        private double CalculateMedian(double[] arr)
        {
            double[] sortedArr = (double[])arr.Clone();
            Array.Sort(sortedArr);
            int size = sortedArr.Length;
            int mid = size / 2;

            if (size % 2 != 0) // Tek sayıysa ortadaki
                return sortedArr[mid];
            else // Çift sayıysa ortadaki ikisinin ortalaması
                return (sortedArr[mid - 1] + sortedArr[mid]) / 2;
        }

        // arraycompare Metodu
        public string ArrayCompare()
        {
            // 1. Tam eşitlik kontrolü (Elemanlar ve sıralama aynı mı?)
            if (_arr1.SequenceEqual(_arr2))
            {
                return "equal";
            }

            // 2. Eşit değilse kıyaslama yap
            string result = "Not equal. ";

            // Eleman sayısı kıyaslaması
            if (Count1 > Count2)
                result += "Array 1 is larger in size. ";
            else if (Count2 > Count1)
                result += "Array 2 is larger in size. ";
            else
                result += "Sizes are equal. ";

            // Ortalama kıyaslaması
            if (Avg1 > Avg2)
                result += "Array 1 has a higher average.";
            else if (Avg2 > Avg1)
                result += "Array 2 has a higher average.";
            else
                result += "Averages are equal.";

            return result;
        }
    }

    //Q3
    public class SinifA
    {
        private string _gizliVeri = "Gizli Bilgi"; // Private değişken

        // Başka sınıfların erişebilmesi için Property tanımlıyoruz
        public string GizliVeri
        {
            get { return _gizliVeri; }
            set { _gizliVeri = value; }
        }

        private void GizliMetot()
        {
            Console.WriteLine("Bu gizli bir işlemdi.");
        }

        // Bu metot public olduğu için dışarıdan çağrılabilir
        public void Calistir()
        {
            GizliMetot(); // İçeride olduğu için private metoda ulaşabilir
        }
    }

    //Q4
    public class Parent
    {
        // a) 0-25 aralığında değer alabilen Property
        private int _x;
        public int X
        {
            get { return _x; }
            set
            {
                if (value >= 0 && value <= 25) _x = value;
                else Console.WriteLine("Hata: x değeri 0-25 aralığında olmalı.");
            }
        }

        // b) Miras alınan sınıf tarafından erişilemeyen (private) değişken
        private string y = "Content";

        // i) Parent Constructor
        public Parent()
        {
            Console.WriteLine("Parent Constructor çalıştı.");
        }

        // c) Test metodu (Overriding için 'virtual' yapmalıyız)
        public virtual void Test()
        {
            Console.WriteLine($"Parent Test: x = {X}");
        }

        // e şıkkı için y'ye erişim sağlayacak bir yardımcı metod (isteğe bağlı)
        // Çünkü y private olduğu için Child doğrudan erişemez.
        protected string GetY() { return y; }
    }

    // --- CHILD CLASS (Miras alan) ---
    public class Child : Parent
    {
        // i) Child Constructor
        public Child()
        {
            Console.WriteLine("Child Constructor çalıştı.");
        }

        // e) Method Overriding
        public override void Test()
        {
            // y private olduğu için 'base.GetY()' veya benzeri bir yöntem gerekir.
            // Soru doğrudan 'y'yi çıktıla' dediği için y'yi Parent'ta 'protected' yapmak 
            // daha mantıklı olurdu ama soru 'erişilemesin' dediği için dolaylı yoldan yazıyoruz.
            Console.WriteLine($"Child Test (Overridden): y = {base.GetY()}");
        }
    }

    // --- RELATIVE CLASS (Miras alan) ---
    public class Relative : Parent
    {
        // i) Relative Constructor
        public Relative()
        {
            Console.WriteLine("Relative Constructor çalıştı.");
        }

        // g) Method Hiding ('new' keyword kullanılır)
        public new void Test()
        {
            Console.WriteLine($"Relative Test (Hiding): Tarih = {DateTime.Now.ToShortDateString()}");
        }
    }

    public class SinifB
    {
        public void Test()
        {
            SinifA a = new SinifA();
            // Doğrudan _gizliVeri'ye ulaşamazsın (Hata verir)
            // Ama Property üzerinden erişebilirsin:
            Console.WriteLine(a.GizliVeri);
        }
    }


    //------------------------------------------//
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Employee Constructor: İsim ve soy isim alır
        public Employee(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Console.WriteLine($"Employee nesnesi oluşturuldu: {FirstName} {LastName}");
        }
    }
    public class Developer : Employee
    {
        public string Specialty { get; set; }

        // Developer Constructor: İsim, Soyisim ve Uzmanlık alanı alır
        // 'base' keyword'ü ile Employee sınıfının constructor'ına verileri gönderir
        public Developer(string firstName, string lastName, string specialty)
            : base(firstName, lastName)
        {
            Specialty = specialty;
            Console.WriteLine($"Developer uzmanlık alanı kaydedildi: {Specialty}");
        }
    }
    //---------------------------------------//

    // a) Abstract temel sınıf tanımlama
    public abstract class Calisan
    {
        public double Maas { get; set; }
        public string Isim { get; set; }

        public Calisan(string isim, double maas)
        {
            Isim = isim;
            Maas = maas;
        }

        // b) İkramiye hesaplama metodu (Gövdesiz, alt sınıflar dolduracak)
        public abstract double IkramiyeHesapla();

        public void BilgiYazdir()
        {
            Console.WriteLine($"{Isim} - Maaş: {Maas} TL, İkramiye: {IkramiyeHesapla()} TL");
        }
    }

    // b) Tam Zamanlı: Tam maaş ikramiye
    public class TamZamanli : Calisan
    {
        public TamZamanli(string isim, double maas) : base(isim, maas) { }
        public override double IkramiyeHesapla() => Maas; // 1 tam maaş
    }

    // b) Yarı Zamanlı: Yarım maaş ikramiye
    public class YariZamanli : Calisan
    {
        public YariZamanli(string isim, double maas) : base(isim, maas) { }
        public override double IkramiyeHesapla() => Maas * 0.5; // Yarım maaş
    }

    // b) Sözleşmeli: Çeyrek maaş ikramiye
    public class Sozlesmeli : Calisan
    {
        public Sozlesmeli(string isim, double maas) : base(isim, maas) { }
        public override double IkramiyeHesapla() => Maas * 0.25; // Çeyrek maaş
    }
    //----------------------------//

    internal class Program
    {
        static void Main(string[] args)
        {
            // h. İki ayrı instance oluşturma
            Sphere s1 = new Sphere(5);    // int r
            Sphere s2 = new Sphere(5.5);  // double r

            // i. Hesaplama ve çıktıları yazdırma
            // (Metotlar property set edildiğinde otomatik çalışıyor ama manuel de çağrılabilir)
            s1.DisplayInfo();
            s2.DisplayInfo();

            // Negatif değer testi (f maddesi kontrolü)
            Sphere s3 = new Sphere(-10);
            Console.WriteLine("Negatif r (-10) girildiğinde sistemin tepkisi:");
            s3.DisplayInfo();
        }
    }
}
