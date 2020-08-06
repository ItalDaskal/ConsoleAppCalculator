using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppCalculator
{
    public class AdditionAndSubtraction
    {
        public static double CalcExercise(List<string> exercise)
        {
            double sum = 0;
            double num = 0;
            string action = null;

            foreach (string tmp in exercise)
            {
                if (tmp == "+" || tmp == "-" || tmp == "*" || tmp == "/")
                {
                    action = tmp;
                }
                else
                {
                    num = double.Parse(tmp);
                }

                if (action != null && num != 0)
                {
                    if (sum == 0)
                    {
                        sum = num;
                    }
                    else
                    {
                        sum = Calculator(action, num, sum);
                    }
                    num = 0;
                }
            }
            return sum;
        }

        public static double Calculator(string action, double number, double sum)
        {
            switch (action)
            {
                case "+":
                    sum += number;
                    break;
                case "-":
                    sum -= number;
                    break;
            }

            return sum;
        }
    }
}
