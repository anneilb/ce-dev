using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int iAnswer = 0;
            int iUserGuess = 0;
            int iCounter = 0;

            for (; ; )
            {
                iCounter = iCounter + 1;
                iAnswer = rnd.Next(1, 101);

                System.Console.WriteLine("Please guess the number (hint {0}):", iAnswer);
                iUserGuess = Int32.Parse(System.Console.ReadLine());

                if (iUserGuess == iAnswer)
                {
                    System.Console.WriteLine("That's correct! The correct answer was {0}.", iUserGuess);
                    System.Console.WriteLine("Your number of tries was {0}.", iCounter);  
                    break;
                }
                else
                {
                    //keep looping 
                }
            }
            
            System.Console.ReadLine();

        }
    }
}
