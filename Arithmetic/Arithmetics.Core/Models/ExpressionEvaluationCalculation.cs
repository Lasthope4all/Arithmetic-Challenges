namespace Arithmetics.Core.Models
{
    public class ExpressionEvaluationCalculation
    {
        public ExpressionEvaluationCalculation(string input, decimal output)
        {
            Input = input;
            Output = output;
        }

        public string Input { get; set; }

        public decimal Output { get; set; }
    }
}
