using Arithmetics.Core.Models;
using System.Data;

namespace Arithmetics.Core.Services
{
    public class ExpressionEvaluator : IExpressionEvaluator
    {
        public ExpressionEvaluationCalculation StringExpressionToResult(string expression)
        {
            var expressionResult = new DataTable().Compute(expression, null).ToString();

            if (decimal.TryParse(expressionResult, out var result))
                return new ExpressionEvaluationCalculation(expression, result);

            throw new ArgumentOutOfRangeException();
        }
    }
}