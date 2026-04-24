namespace vize.sonrası._1
{
    internal class Area
    {
        public double area;
        public Area(double side)
        {
            this.area = side * side; //Square
        }
        
        public Area(double side1, double side2)
        {
            this.area = side1 * side2; //Rectangle
        }

        public Area(string something, double r)
        {
            this.area = Math.PI * r * r; //Rectangle
        } 
    }

    class SpecialArea : Area
    {  
        public SpecialArea(double side) : base(side) 
        {
            this.area = base.area * 6; //cube area
        }

    }

    class Shape
    {
        public virtual void Draw()
        {
            Console.WriteLine("shape çizildi");
        }
    }
    class SpecialShape : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("SpecialShape çizildi");
        }

        public void SpecialMethod()
        {
            Console.WriteLine("özel method çalıştı");
        }
    }

    //Senaryo: the business force to write for each department to build a class named
    //AcmeCoop that should include a method Info and Display. (işletmede belirli departmanlar
    //var ve her departmanın sınıfı olup AcmeCoop classı olmak zorunda)
    //Tip: Interface structure should be used. (interface kullanaınca methodun içeriği olmaz ismi olur, içeriği miras alındığında oluşturulur)
    //interfacenin instancesını oluşturamazsın. tanımlamaya zorla kullanmaya değil.
    //departmentların instancesi oluşturulabilir.
    interface AcmeCoop
    {
        void Info();
        void Display();
    }

    class Department1 : AcmeCoop 
    {
        public void Info()
        {
            Console.WriteLine("HR Department Info");
        }

        public void Display()
        {
            Console.WriteLine("HR Display");
        }
    }

    class Department2 : AcmeCoop
    {
        public void Info()
        {
            Console.WriteLine("IT Department Info");
        }

        public void Display()
        {
            Console.WriteLine("IT Display");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //upcasting
            Shape cisim = new SpecialShape(); //child oluçturdu shape değil
            cisim.Draw();

            //cisim.SpecialMethod(); HATA
            //çözüm
            if (cisim is SpecialShape special)
            {
                special.SpecialMethod();
            }


            /////////////
            AcmeCoop dep1 = new Department1();
            AcmeCoop dep2 = new Department2();

            dep1.Info();
            dep1.Display();

            dep2.Info();
            dep2.Display();
        }
    }
}
