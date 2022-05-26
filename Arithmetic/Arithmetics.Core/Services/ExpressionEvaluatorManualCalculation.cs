using Arithmetics.Core.Models;
namespace Arithmetics.Core.Services
{
    public class ExpressionEvaluatorManualCalculation : IExpressionEvaluator
    {
        public const char Multiplication = '*';
        public const char Division = '/';
        public const char Addition = '+';
        public const char Subtraction = '-';
        public static readonly char[] Operators = { Multiplication, Division, Addition, Subtraction };

        public ExpressionEvaluationCalculation StringExpressionToResult(string expression)
        {
            var input = new string(expression);

            input = BreakdownString(input, Division);
            input = BreakdownString(input, Multiplication);
            input = BreakdownString(input, Addition);
            input = BreakdownString(input, Subtraction);

            var value = decimal.Parse(input);

            return new ExpressionEvaluationCalculation(expression, value);
        }

        public string BreakdownString(string input, char op)
        {
            var updatedInput = input;
            while (true)
            {
                var divIndex = updatedInput.IndexOf(op);

                if (divIndex < 0) break;

                var firstNumberIndex = GetIndexOfNumberBeforeOperator(updatedInput, divIndex);
                var secondNumberIndex = GetIndexOfNumberAfterOperator(updatedInput, divIndex);
                var calculation = updatedInput.Substring(firstNumberIndex, (secondNumberIndex - firstNumberIndex) + 1);
                var res = Calculate(calculation, op);
                updatedInput = updatedInput.Replace(calculation, res);
            }

            return updatedInput;
        }

        public int GetIndexOfNumberBeforeOperator(string equation, int indexOfOperator)
        {
            var pointer = indexOfOperator;
            while (true)
            {
                pointer--;

                if (pointer < 0) return 0;

                if (Operators.Contains(equation[pointer]))
                {
                    return pointer + 1;
                }
            }
        }

        public int GetIndexOfNumberAfterOperator(string equation, int indexOfOperator)
        {
            var pointer = indexOfOperator;
            while (true)
            {
                pointer++;

                if (pointer > equation.Length - 1) return equation.Length - 1;

                if (Operators.Contains(equation[pointer]))
                {
                    return pointer - 1;
                }
            }
        }

        public static string Calculate(string equation, char op)
        {
            var parts = equation.Split(op);
            var first = decimal.Parse(parts[0]);
            var second = decimal.Parse(parts[1]);

            return op switch
            {
                Division => (first / second).ToString(),
                Multiplication => (first * second).ToString(),
                Subtraction => (first - second).ToString(),
                Addition => (first + second).ToString(),
                _ => throw new System.Exception()
            };
        }
    }
}