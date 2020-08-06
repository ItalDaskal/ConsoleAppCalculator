using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCalculator
{
    public class Brackets
    {
        public static async Task<List<string>> CalcExercise(List<string> exercise)
        {
            List<string> insideBrackets = new List<string>();
            List<string> exe = new List<string>();
            double sum = 0;

            int startIndex = 0;
            int endIndex = 0;

            for (int i = 0; i < exercise.Count; i++)
            {
                if (exercise[i] == "(")
                {
                    startIndex = i;
                    for (int y = ++i; y <= exercise.Count - 1; y++)
                    {
                        if (exercise[y] == ")")
                        {
                            endIndex = y;
                            break;
                        }
                        else
                        {
                            insideBrackets.Add(exercise[y]);
                        }
                    }

                    exe = await Task.Run(() => MultiplicationAndDivision.CalcExercise(insideBrackets));
                    sum = await Task.Run(() => AdditionAndSubtraction.CalcExercise(exe));

                    exercise[endIndex] = sum.ToString();
                    for (int d = --endIndex; d >= startIndex; d--)
                    {
                        exercise.RemoveAt(d);
                    }
                    i = startIndex;
                }
            }
            return exercise;
        }
    }
}
