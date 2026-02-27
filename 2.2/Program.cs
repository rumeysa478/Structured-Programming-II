namespace w2
{
    
    internal class Fenerbahce
    {
        public int classVariable = 2026;
        //inernal ya da instance class variable olurlar çünkü static kullanmadık
        //ve sadece fenerbahce classında kullanılabilir

        public static int staticVariable = 1453;
        //we can call this variable without creating instance for fenerbahce class

        public void MethodX()
        {
            Program test = new Program();
        }

        public void MethodA()
        {
            int var_A = 1;        
            classVariable = 2023;
            //değişkene yeni değer atanabilir
            Console.WriteLine(classVariable);
            //static olsaydın classVariable'yi çağıramazdık
        }

        public void MethodB()
        {
            int var_B = -1;
            Console.WriteLine(classVariable);
            //Console.WriteLine(var_A);
            //variables are local bu yüzden diğer methodlarda çağırılamaz

            Fenerbahce.StaticMethod(); //çağırılabilir
        }

        public static void StaticMethod()
        {
            Console.WriteLine("this is a static method example");
        }
    }

    internal class Program
    {     
        public void Deneme()
        {
            //static method can be accesible inside non-static method
            Fenerbahce.StaticMethod();
        }
        static void Main(string[] args)
        {
            Fenerbahce mac = new Fenerbahce();
            //bir sınıfın birden fazla kopyası oluşturulabilir
            //classlara doğrudan ulaşılamaz bir kopyası oluşturulmalı
            //her instance kendi kopyasını oluşturur
            Console.WriteLine(mac.classVariable);
            Fenerbahce avrmac = new Fenerbahce();

            Console.WriteLine("calling method a");
            mac.MethodA();
            Console.WriteLine("calling method b");
            mac.MethodB();
            //method a'da classVariable değerini değiştirdiğimiz için byi çağırınca da 2023 geldi

            Console.WriteLine("calling method b");
            avrmac.MethodB();//başka bir instanceden çağırdığımız için 2026 döner

            //Fenerbahce.classVariable kullanılamaz hata verir
            Console.WriteLine(Fenerbahce.staticVariable);

            //class variablea mac değişkeni ile ulaşılabilir
            //static variableye direk class adı ile ulaşılabilir

            //Console.WriteLine(mac.staticVariable); eror verir
        }
    }

    class test
    {
        public int sayi = 10;
        public int numara = 10;
        public double ondalikli;

        public int Sayi { get; set; } //first defining type of properties

        public int Numara
        {
            get { return numara; }
            set { numara = value; }
        }

        public double Ondalikli
        {
            get => ondalikli;
            set => ondalikli = value;   
        }

        public int getMethod()
        {
            return sayi;
        }

        public void setMethod(int newSayi)
        {
            sayi = newSayi;
        }
    }
}
