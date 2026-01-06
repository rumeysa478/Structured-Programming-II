using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Metadata;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace final.practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1) Handle the exception given in the below code.
            string[] depts = { "MIS", "History", "Physics", "Economics" };
            object[] departments = depts;
            try
            {
                departments[1] = 9.8;
                Console.WriteLine(departments[1]);
            }
            catch (ArrayTypeMismatchException ex)
            {
                Console.WriteLine("your format is wrong");
            }
            finally
            {
                Console.ReadLine();
            }

            //2) Ask the user for a number.
            //If the user enters a value other than a number, handle the exception at the outer block
            Console.WriteLine("please enter a number: ");            
            try
            {
                int num = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("number is: " + num);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("please enter a number!");
            }
            finally
            {
                Console.ReadLine();
            }

            //3) The following codes open the test.txt file in the application folder and
            //output its content to the console. If the file is not found, it throws an
            //exception.Notify the user of this situation.
            using (var reader = new StreamReader("test.txt"))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
            Console.ReadLine();

            try
            {
                using (var reader = new StreamReader("test.txt"))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
                Console.ReadLine();
            }
            catch (FileNotFoundException) 
            {
                Console.WriteLine("File not Found");
            }
            finally
            {
                Console.ReadLine();
            }

            //4) Replace the word starts with kara to beyaz given string array.
            string[] places = {"ankara", "maskara", "karagöz","karaburun"};
            
            for (int j = 0; j < places.Length; j++)
            {
                if (places[j].StartsWith("kara"))
                {
                    // İlk 4 harfi ("kara") at ve yerine "beyaz" ekle
                    // Substring(4) -> 4. indexten sonrasını alır (yani "kara" kısmını atlar)
                    places[j] = "beyaz" + places[j].Substring(4);
                }
            }
            // Sonuçları ekrana yazdırma
            foreach (string place in places)
            {
                Console.WriteLine(place);
            }

            //5) Write the LastIndexOf, and substr methods yourself. stfr.LastIndexOf(str1) en sondaki bu değeri bulur. sub string de alt eleman

            //public static string MySubstring(string text, int startIndex, int length)
            {
            string result = "";
            // Belirtilen indexten başla, istenen uzunluk kadar git
            for (int i = startIndex; i < startIndex + length; i++)
            {
                result += text[i]; // Karakterleri tek tek yeni stringe ekle
            }
            return result;
            }

            //public static int MyLastIndexOf(string mainStr, string searchStr)
            {
                int mainLen = mainStr.Length;
                int searchLen = searchStr.Length;

                // Döngüyü SONDAN BAŞA doğru kuruyoruz (LastIndexOf mantığı)
                // i, ana string içinde arama yapacağımız başlangıç noktası
                for (int i = mainLen - searchLen; i >= 0; i--)
                {
                    bool eslesme = true;

                    // Kelimeyi karakter karakter kontrol et
                    for (int j = 0; j < searchLen; j++)
                    {
                        // mainStr[i + j] -> Ana metindeki kaydırmalı pozisyon
                        if (mainStr[i + j] != searchStr[j])
                        {
                            eslesme = false;
                            break; // Uyuşmazlık varsa bu indexi bırak, bir geriye git
                        }
                    }

                    // Eğer iç döngüden çıkıldığında eşleşme hala true ise, bulduk demektir.
                    if (eslesme)
                    {
                        return i; // Bulduğumuz indexi döndür
                    }
                }

                return -1; // Bulunamazsa standart olarak -1 döner
            }


            //6) Write a C# program that parses the strings "Oct 23, 1923" and "Mar 18, 1915" into DateTime objects.
            //Calculate and output the total number of days between the two dates.

            string dateTime = "Oct 23, 1923";
            string dateTime1 = "Mar 18, 1915";
            DateTime parsedDate = DateTime.Parse(dateTime);
            DateTime parsedDate1 = DateTime.Parse(dateTime1);
            Console.WriteLine(parsedDate.Days + parsedDate1.Days);

            //7) The area of intersection formed(inside the triangle) by the circular sectors determined by arcs is given by.
            //Write the program that calculates that area.
            • 𝑎 = 𝑥 + 𝑦 + 𝑧
            • Angles should be evaluated as radians.
            • (cos - 1 means Arccos(Acos)).

            //8) Write a method called HarmonicInteger that takes 5 integers as input
            // and returns their harmonic mean as double data type.

            //public static double HarmonicInteger(int i1, int i2, int i3, int i4, int i5)
            {
                double harmonic_mean = ((i1 + i2 + i3 + i4 + i5) / 5.0);
                return harmonic_mean;
            }

            //9) Write a method that takes 5 names from the user and stores them in
            // a List<string> collection.Print these names on the screen in alphabetical order.
            //public static void HarmonicInteger()
            {
                Console.WriteLine("please enter a name");
                string i1 = Console.ReadLine();
                Console.WriteLine("please enter a name");
                string i2 = Console.ReadLine();
                Console.WriteLine("please enter a name");
                string i3 = Console.ReadLine();
                Console.WriteLine("please enter a name");
                string i4 = Console.ReadLine();
                Console.WriteLine("please enter a name");
                string i5 = Console.ReadLine();

                List<string> storing = new List<string> { i1, i2, i3, i4, i5 };
                storing.Sort();
                foreach (string i in storing)
                {
                    Console.WriteLine(i);
                }

            }

            //10) Write a method named PrintNumbers that takes an int and a double
            //as parameters in order.The method should work as follows:
            • If either of the parameters is a negative number, it should print the negative number.
            • If both numbers are positive, it should print the reciprocal (multiplicative inverse, 1 / number) of the smaller number.

           //11) Write a method that accepts a variable number of arguments and returns their median. (Note: use params keyword)
           //public static int Medians(params int[] a)
            {
                int len = a.Length;
                if (len % 2 == 0)
                {
                    return (a[len / 2] + a[(len / 2) + 1]) / 2;
                }
                else
                {
                    return a[len / 2];
                }
            }

            //12) Write a method that takes a number as a parameter, assigns its square to the parameter, and returns the squared value.
            //public static double Sqr(ref double a)
            {
                a = Math.Sqrt(a);
                return a;
            }

            //13) Create a List<int> to hold a collection of numbers. Add 5 random numbers between 1 and 50 to the list.
            //Return the numbers from the list that are greater than the average of all numbers in the list.
            List<int> numbers = new List<int> { 5, 11, 20, 50, 9 };
            int avarage = 0;
            foreach (int i in numbers)
            {
                avarage = avarage + i;
            }
            avarage = avarage / 5;
            for (int i = 0; i < 5; i++)
            {
                if (numbers[i] > avarage)
                {
                    Console.WriteLine(numbers[i]);
                }
            }

            //14) Write a method that takes a List<string> as a parameter, filters the list,
            //and returns only the words that contain the letter "e".
            //public  static List<string> ContainE(List<string> strings)
            {
                List<string> ContainsE = new List<string> { };
                for (int i = 0; i < strings.Count; i++)
                {
                    if (strings[i].Contains("e") == true)
                    {
                        ContainsE.Add(strings[i]);
                    }
                }
                return ContainsE;

            }

            //15) Create a Dictionary<string, int> to store students' names and their grades.
            //Write a program that takes a student's name as input from the user and returns the corresponding grade.
            //public static int student(string name)
            {
            Dictionary<string, int> studentDict = new Dictionary<string, int> { };
            studentDict.Add("rumeysa", 100);
            return studentDict[name];
            }

        // 1) Create an array of 3 int elements. Ask the user to type an index value
        // between 0 and 3.The program throws an exception if the user types a
        // negative number or greater than the array's element size. Handle both exception situations.
        int[] arr = new int[3];
            Console.WriteLine("please enter an index value");
            int num = Convert.ToInt32(Console.ReadLine());
            try
            {
                Console.WriteLine(arr[num]);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("out of range");
            }
            catch (Exception ex)
            {
                // Beklenmedik diğer tüm hatalar için genel blok
                Console.WriteLine("Beklenmedik bir hata oluştu: " + ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }

            //2) Calculate the means of negative numbers and positive numbers separately given array.
            int[] numbers = { -12, 3, -9, -2, 6, 3, 58, -4 };
            
            //3) Split the given string with a dash – and output how many parts have 3 characters ?
            string phoneNumber = "212-440-00-00";

            // 1. Dash (-) karakterine göre parçalara ayır
            string[] parts = phoneNumber.Split('-');
            int count = 0;
            // 2. Her bir parçayı kontrol et
            foreach (string part in parts)
            {
                if (part.Length == 3)
                {
                    count++;
                }
            }

            //4) Write a method that takes two DateTime parameters and returns the number of months between these two dates.
            DateTime date1 = DateTime.Now;
            string date2 = "17 / 11 / 2005";
            DateTime.Parse(date2);
            int months = Math.Abs(date1.Year - DateTime.Parse(date2).Year) * 12 + Math.Abs(date1.Year - DateTime.Parse(date2).Year);

            //5) Write a program that converts a string given in the format "24-08-1993" to the format "08 / 24 / 1993".
            string input = "24-08-1993";
            // 1. String'i DateTime nesnesine çeviriyoruz (Gün-Ay-Yıl formatında olduğunu belirterek)
            DateTime date = DateTime.ParseExact(input, "dd-MM-yyyy", null);
            // 2. Yeni formatta ("Ay / Gün / Yıl") yazdırıyoruz
            string output = date.ToString("MM / dd / yyyy");

            //6) Write a method named TransformNumber that accepts a number as input.If the number is negative, the method calculates its cube and
            //assigns it back to the number. If the number is positive, it calculates
            //its square root and assigns it back to the number. Finally, the method returns the updated number.

            //7) Write a method named OnlyNegatives with the params parameter that returns only negatives from the received number array.
            //Test this method with the following array.
            int[] numbers = { -12, 3, -9, -2, 6, 3, 58, -4 };
            
            // 8) Write a program that processes a given List collection of numbers.
            // The program should add all positive numbers from the collection to a
            // list named Positives and all negative numbers to a separate list named Negatives.
        }
    }
}

