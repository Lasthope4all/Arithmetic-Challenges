using Arithmetics.Core.Models;

namespace Arithmetics.Core.Services
{
    public interface IExpressionEvaluator
    {
        public ExpressionEvaluationCalculation StringExpressionToResult(string expression);
    }
}
