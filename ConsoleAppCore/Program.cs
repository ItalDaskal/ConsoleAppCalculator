using System;
using System.Threading.Tasks;

namespace ConsoleAppCalculator
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            bool endApp = false;
            Console.WriteLine("Calculator - Console App Core - C#\r");
            Console.WriteLine("-----------------------------------\n");
            while (!endApp)
            {
                try
                {
                    string clientInput = null;

                    Console.WriteLine("enter a mathematical exercise (  +  |  -  |  *  |  /  )\n");
                    clientInput = Console.ReadLine();

                    if (clientInput != null)
                    {
                        double res = await Task.Run(() => Calculator.CalcAsync(clientInput));
                        if (res.ToString() != null)
                        {
                            Console.WriteLine("{0} = {1} \n", clientInput, res);
                        }
                        else
                        {
                            Console.WriteLine("something went wrong. try again or get help.");
                        }

                        Console.WriteLine("------------------------\n");

                        Console.Write("Press 'n' to close the app, or press any other key and Enter to continue: \n");
                        if (Console.ReadLine() == "n") endApp = true;

                        Console.WriteLine("\n");

                    }
                    else
                    {
                        Console.WriteLine("please enter an arithmetic exercise!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }
            }
        }
    }
}


