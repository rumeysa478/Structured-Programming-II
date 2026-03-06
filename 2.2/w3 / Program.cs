namespace w3
{
    // Shape.cs
    public class Shape
    {
        protected double area; //miras alındığında erişilebilir
        protected void CalculateArea()
        {
            Console.WriteLine("Base calculation method");
        }
        public void ShowArea()
        {
            Console.WriteLine($"Area: {area}");
        }
    }
    public class Circle : Shape //circle sınıfı shape sınıfından miras alıyor
    {
        private double radius;
        public Circle(double radius)
        {
            this.radius = radius;
            CalculateCircleArea();
        }
        private void CalculateCircleArea()
        {
            area = Math.PI * radius * radius;  // Can access protected field (area) from base class
            CalculateArea();  // Can access protected method from base class
        }        
    }



    public class DigerSinif
    {
        private decimal salary = 0m;
        public string username = "rumeysa";
        private protected int ID = 051524007;
        
        public static void Eris()
        {
            Console.WriteLine(Program.acik);
            //Console.WriteLine(Program.hususi);
            //Console.WriteLine(Program.korumali);
            Console.WriteLine(Program.dahili);
            Console.WriteLine(Program.dahili_korumalı);
            //Console.WriteLine(Program.dahili_hususi);
        }
        static void Main()
        {
            Circle circle = new Circle(5);
            circle.ShowArea();
            circle.area = 100; //error
            circle.CalculteArea(); //error

            Shape shape = new Shape();
            shape.ShowArea();//sadece showareaya erişilebilir
        }
    }
    internal class Program
    {
        public static int acik;
        private static int hususi; //erişilemez
        protected static int korumali; //erişilemez
        internal static int dahili;
        protected static internal int dahili_korumalı;
        private protected static int dahili_hususi; //erişilemez

        public void Goster() 
        {
            Console.WriteLine(acik);
            Console.WriteLine(hususi);
            Console.WriteLine(korumali);
            Console.WriteLine(dahili);
            Console.WriteLine(dahili_korumalı);
            Console.WriteLine(dahili_hususi);

            
            DigerSinif deneme = new DigerSinif();
            deneme.username = "rmsa";
            Console.WriteLine(deneme.salary);
            Console.WriteLine(deneme.username);
            Console.WriteLine(deneme.ID);
            
        }
        
        static void Main(string[] args)
        {
            
        }
    }
    
}
