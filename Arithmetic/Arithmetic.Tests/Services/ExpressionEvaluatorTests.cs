using Arithmetics.Core.Services;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Arithmetic.Tests.Services
{
    public class ExpressionEvaluatorTests
    {
        [Theory]
        [InlineData("4+5*2", 14)]
        [InlineData("4+5/2", 6.5)]
        [InlineData("4+5/2-1", 5.5)]
        [InlineData("99*2", 198)]
        [InlineData("4+5", 9)]
        [InlineData("2-1", 1)]
        [InlineData("5*2", 10)]
        [InlineData("5*2/8*4+9+12", 26)]
        public void Check_ExpressionCalculator_ReturnExpectedAnswer(string expression, decimal expectedAnswer)
        {
            // Act
            var sut = new ExpressionEvaluator().StringExpressionToResult(expression);

            // Assert
            using (new AssertionScope())
            {
                sut.Input.Should().Be(expression);
                sut.Output.Should().Be(expectedAnswer);
            }
        }
    }
}
