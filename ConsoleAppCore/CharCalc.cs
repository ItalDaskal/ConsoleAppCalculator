using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppCalculator
{
    public class CharCalc
    {
        public static void calc()
        {
            int sum = 0;
            int num = 0;
            string calcolate = null;
            string clientInput = null;
            string action = null;

            while (clientInput != "=")
            {
                Console.WriteLine("enter a number or mathematical symbol\n");
                clientInput = Console.ReadLine();

                calcolate += clientInput;

                if (sum == 0)
                {
                    sum = Int32.Parse(clientInput);
                }
                else
                {
                    if (clientInput == "+" || clientInput == "-" || clientInput == "*" || clientInput == "/" || clientInput == "%" || clientInput == "=")
                    {
                        if (clientInput == "=")
                        {
                            Console.WriteLine("{0} {1}", calcolate, sum);
                        }
                        action = clientInput;
                    }
                    else
                    {
                        num = Int32.Parse(clientInput);
                    }

                    if (num != 0 && action != null && action != "=")
                    {
                        sum = calc(action, num, sum);
                        num = 0;
                    }
                }
            }
        }

        public static int calc(string action, int num, int sum)
        {
            //double res = 0;
            switch (action)
            {
                case "+":
                    sum += num;
                    break;
                case "-":
                    sum -= num;
                    break;
                case "*":
                    sum *= num;
                    break;
                case "/":
                    sum /= num;
                    break;
                case "%":
                    sum %= num;
                    break;
            }
            return sum;
        }
    }
}
