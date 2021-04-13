using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new ExpressionCalculator();
            ConsoleKeyInfo escape = new ConsoleKeyInfo();
  
            while(escape.Key != ConsoleKey.Escape) { 
                GetInput(calculator);
                escape = Console.ReadKey();
            } 

            Console.ReadLine();
                     
        }

        static void GetInput(ExpressionCalculator calc)
        {
            Console.WriteLine("Calculate: ");
            var input = Console.ReadLine();
            try
            {
                var calculationResult = calc.Calculate(input.ToString());
                Console.WriteLine(calculationResult);
            }
            catch(Exception argEx)
            {
                if (argEx.GetType() == typeof(ArgumentOutOfRangeException)) 
                {
                    Console.WriteLine("Only integer values are allowed.");
                }
                else
                {
                    Console.WriteLine($"An unspecified error occurred while calculating the above expression. Error: {argEx.Message}");
                }
                                      
            }          
        }

        
    }
}
