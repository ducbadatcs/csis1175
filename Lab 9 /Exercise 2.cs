using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        //notes: Entering Zero directly into the weight and height values won't raise exceptions.
        //idk why
        class BodyMaxIndexCalculator
        {
            //Fields
            private int weight;
            private int height;

            //Constructors
            public BodyMaxIndexCalculator() { }
            public BodyMaxIndexCalculator(int weight, int height)
            {
                this.weight = weight;
                this.height = height;
            }
            //Calculate BMI
            public double CalculateBMI()
            {
                double bmi = 0;
                try
                {
                    bmi = this.weight / (this.height * this.height);
                }
                catch (ArithmeticException ae)
                {
                    //AE caused by division by 0, or overflow, or results in infinity
                    //https://learn.microsoft.com/en-us/dotnet/api/system.arithmeticexception?view=net-8.0

                    Console.WriteLine("Error: Zero division from invalid data!");
                    return 0;
                }
                return bmi;
                

            }

            public override string ToString()
            {
                return $"Weight: {this.weight}\n" +
                       $"Height: {this.height}\n" +
                       $"BMI: {this.CalculateBMI()}";
            }
        }

        class BMIApp
        {
            public static void Test()
            {
                int weight = 0, height = 0;
                Console.Write("Enter weight in kilograms: ");
                //during entering we only need to catch FormatException
                //https://learn.microsoft.com/en-us/dotnet/api/system.formatexception?view=net-8.0
                try
                {
                    weight = int.Parse(Console.ReadLine());
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Invalid data error: " + fe.Message +"\nWeight will be zero!");
                    weight = 0;
                }
                catch (Exception ex) when (weight == 0) //yes, apparently you can do this. It will check if weight is 0 and if it is, it'll throw an ArithmeticException
                {
                    Console.WriteLine("Weight is zero!");
                    Console.WriteLine(ex.Message);
                }

                Console.Write("Enter height in meters: ");
                try
                {
                    height = int.Parse(Console.ReadLine());
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Invalid data error: " + fe.Message + "\nHeight will be zero!");
                    height = 0;
                }
                catch (Exception ex) when (height == 0)
                {
                    Console.WriteLine("Height is zero!");
                    Console.WriteLine(ex.Message);
                }

                BodyMaxIndexCalculator bmic = new BodyMaxIndexCalculator(weight, height);
                Console.WriteLine(bmic.ToString());
                Console.ReadKey();
            }
        }

        static void Main(string[] args)
        {

            BMIApp.Test();
        }
    }
}
