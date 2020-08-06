using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCalculator
{
    public class CalcHelper
    {
        public static List<string> MergeNumbers(List<string> exe)
        {
            string tmpNumber = null;
            List<string> exercise = new List<string>();

            foreach (string tmp in exe)
            {
                if (tmp != "+" && tmp != "-" && tmp != "*" && tmp != "/" && tmp != "=" && tmp != "(" && tmp != ")")
                {
                    tmpNumber += tmp;
                }
                else if (tmp == "+" || tmp == "-" || tmp == "*" || tmp == "/" || tmp == "=" || tmp == ")")
                {
                    if (tmpNumber != null)
                    {
                        exercise.Add(tmpNumber);

                        tmpNumber = null;
                    }
                    exercise.Add(tmp);

                }
                else if (tmp == "(")
                {
                    if (tmpNumber != null)
                    {
                        exercise.Add(tmpNumber);
                        exercise.Add("*");

                        tmpNumber = null;
                    }
                    exercise.Add(tmp);
                }
            }
            exercise.Add(tmpNumber);
            return exercise;
        }

        public static async Task<List<string>> ExerciseStandards(string clientInput)
        {
            List<string> exercise = new List<string>();

            foreach (char c in clientInput)
            {
                if (!string.IsNullOrWhiteSpace(c.GetTypeCode().ToString()))
                {
                    exercise.Add(c.ToString());
                }
            }

            if (exercise.Count > 1)
            {
                if (exercise[0] == "+" || exercise[0] == "-" || exercise[0] == "*" || exercise[0] == "/" || exercise[0] == "=")
                {
                    exercise[0] = "";
                }
                return await Task.Run(() => MergeNumbers(exercise));
            }
            else
            {
                throw new System.ArgumentException("Please enter correct exercise", "original");
            }
        }
    }
}
