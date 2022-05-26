using Arithmetics.Core.Models;
using Arithmetics.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Arithmetic.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class ArithmeticsController : ControllerBase
    {
        private readonly IExpressionEvaluator _expressionEvaluator;

        public ArithmeticsController(ILogger<ArithmeticsController> logger, IExpressionEvaluator expressionEvaluator)
        {
            _expressionEvaluator = expressionEvaluator;
        }

        [HttpPost]
        public ExpressionEvaluationCalculation GetExpressionEvaluationCalculation([FromBody] ExpressionEvaluationCalculationInput request) => _expressionEvaluator.StringExpressionToResult(request.Input);
    }
}
