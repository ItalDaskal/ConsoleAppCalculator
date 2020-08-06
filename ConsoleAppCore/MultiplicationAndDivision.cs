using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppCalculator
{
    public class MultiplicationAndDivision
    {
        public static List<string> CalcExercise(List<string> exercise)
        {
            double sum = 0;
            string action = null;

            for (int i = 0; i < exercise.Count; i++)
            {
                if (exercise[i] == "*" || exercise[i] == "/")
                {
                    int reverseIndex = i - 1;
                    int forwardIndex = i + 1;
                    action = exercise[i];
                    double firstNumber = 0;
                    double secondNumber = 0;

                    firstNumber = double.Parse(exercise[reverseIndex]);
                    secondNumber = double.Parse(exercise[forwardIndex]);
                    if(action != null)
                    {
                        sum = Calculator(action, firstNumber, secondNumber, sum);
                    }

                    exercise[forwardIndex] = sum.ToString();
                    for (int d = i; d >= reverseIndex; d--)
                    {
                        exercise.RemoveAt(d);
                    }
                    i = reverseIndex;
                    action = null;
                }
            }
            return exercise;
        }

        public static double Calculator(string action, double firstNumber, double secondNumber, double sum)
        {
            switch (action)
            {
                case "*":
                    sum = firstNumber * secondNumber;
                    break;
                case "/":
                    sum = firstNumber / secondNumber;
                    break;
            }

            return sum;
        }
    }
}
