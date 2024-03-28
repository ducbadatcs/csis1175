using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ArithmeticException
            //Errors in arithmetic and/or casting
            try
            {
                int zero = 0; //change this to literally any other integer to fix
                int n = 5 / zero; //writing 5 / 0 will not work, since it would refuse to build.
            }
            catch (ArithmeticException ae)
            {
                Console.WriteLine(ae.Message);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

            //FormatException
            //Errors in formatting, aka strings
            try
            {
                Console.WriteLine($"{123:q4}"); //wrong statement
                //Console.WriteLine($"{123:d4}"); //correcct statement, the "d" can also be various other symbols that im too lazy to fill
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //IndexOutOfRangeException
            //occurs when trying to access an index outside of an array's length (index < 0 or index > array.length). 
            try
            {
                int[] a = { 1, 2, 3 }; //3 values
                Console.WriteLine(a[3]); //prints the 4th, which doesn't exist, change to value from 0 to 2
                
            }
            catch (IndexOutOfRangeException ioore)
            {
                Console.WriteLine(ioore.Message);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
