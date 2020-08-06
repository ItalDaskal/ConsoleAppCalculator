using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleAppCalculator
{
    public class Calculator
    {
        public static async Task<double> CalcAsync(string clientInput)
        {
            List<string> exercise = await Task.Run(() => CalcHelper.ExerciseStandards(clientInput));

            List<string> firstStepExe = await Task.Run(() => Brackets.CalcExercise(exercise));
            if (firstStepExe.Count == 1)
            {
                return double.Parse(firstStepExe[0]);
            }

            List<string> secondStepExe = await Task.Run(() => MultiplicationAndDivision.CalcExercise(firstStepExe));
            if (secondStepExe.Count == 1)
            {
                return double.Parse(secondStepExe[0]);
            }

            return await Task.Run(() => AdditionAndSubtraction.CalcExercise(secondStepExe));
        }
    }
}
