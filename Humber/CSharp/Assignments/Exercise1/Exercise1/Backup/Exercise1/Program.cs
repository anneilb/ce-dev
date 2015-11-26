using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            int iValue1;
            int iValue2;
            double dTotal;
            string sOperator;

            System.Console.WriteLine("Please enter value 1:");
            iValue1 = Int32.Parse( System.Console.ReadLine());

            System.Console.WriteLine("Please enter value 2:");
            iValue2 = Int32.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Please enter the operator:");
            sOperator = System.Console.ReadLine();
            
            switch(sOperator)  
            {
               case "+":
                   dTotal = iValue1 + iValue2;
                   System.Console.WriteLine("{0}+{1}={2}", iValue1, iValue2, dTotal);  
                   break;

               case "-":
                   dTotal = iValue1 - iValue2;
                   System.Console.WriteLine("{0}-{1}={2}", iValue1, iValue2, dTotal);
                   break;

               case "*":
                   dTotal = iValue1 * iValue2;
                   System.Console.WriteLine("{0}*{1}={2}", iValue1, iValue2, dTotal);
                   break;

               case "/":
                   dTotal = iValue1 / iValue2;
                   System.Console.WriteLine("{0}/{1}={2}", iValue1, iValue2, dTotal);
                   break;

               case "%":
                   dTotal = iValue1 % iValue2;
                   System.Console.WriteLine("{0}%{1}={2}", iValue1, iValue2, dTotal);
                   break;

                default:
                    System.Console.WriteLine("Invalid operator.");
                    break; 
            }

            System.Console.ReadKey();   
        }
    }
}
