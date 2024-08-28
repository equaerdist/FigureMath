using FigureMath.Services;
using Xunit;

namespace FigureMath.Tests
{
    public class AreaCalculatorsTests
    {
        [Theory]
        [InlineData(0, 0)] 
        [InlineData(1e-10, Math.PI * 1e-20)] 
        [InlineData(1e10, Math.PI * 1e20)] 
        [InlineData(double.MaxValue, double.PositiveInfinity)] 
        [InlineData(double.Epsilon, Math.PI * double.Epsilon * double.Epsilon)] 
        [InlineData(-1, Math.PI)]
        public void CircleAreaTest_DefaultValues_Success(double radius, double expected)
        {
            var calculator = new CircleAreaCalculator();
            var actual = calculator.Calculate(new() { Radius = radius });
            Assert.Equal(expected, actual, 10);
        }
        [Theory]
        [InlineData(3, 4, 5, 6)]
        [InlineData(10, 10, 10, 15)] 
        [InlineData(1, 1, 1.41421356237, 1.707106781185)]
        [InlineData(0, 0, 0, 0)] 
        [InlineData(1e-10, 1e-10, 1e-10, 1.5e-10)] 
        [InlineData(1e10, 1e10, 1e10, 1.5e10)] 
        [InlineData(double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue * 1.5)] 
        [InlineData(7, 24, 25, 28)] 

        public void CalculateHalfPerimeterTest_DefaultValues_Success(double a, double b, 
            double c, double expected)
        {
            var p = new TriangleParameters() { A = a, B = b, C = c };
            var actual = TriangleAreaCalculator.HalfPerimeter(p);
            Assert.Equal(expected, actual, 10);
        }
        [Theory]
        [InlineData(3, 4, 5, true)] 
        [InlineData(5, 12, 13, true)] 
        [InlineData(8, 15, 17, true)] 
        [InlineData(7, 24, 25, true)] 
        [InlineData(9, 40, 41, true)] 
        [InlineData(10, 6, 8, true)] 
        [InlineData(6, 8, 10, true)] 
        [InlineData(1, 1, 1, false)] 
        [InlineData(2, 2, 3, false)] 
        [InlineData(5, 5, 5, false)]
        [InlineData(3, 4, 6, false)] 
        [InlineData(7, 10, 12, false)]
        public void StraightTriangleTest_DefaultValues_Success(double a, double b, double c, bool expected)
        {
            var p = new TriangleParameters() { A = a, B = b, C = c };
            var actual = TriangleAreaCalculator.IsStraightTriangle(p);
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(3, 4, 5, 6)] 
        [InlineData(10, 10, 10, 43.30127018922193)]
        [InlineData(6, 8, 10, 24)] 
        [InlineData(7, 24, 25, 84)] 
        [InlineData(9, 12, 15, 54)] 
        [InlineData(5, 5, 6, 12)] 
        [InlineData(7, 8, 9, 26.832815729997478)] 
        [InlineData(13, 14, 15, 84)] 
        [InlineData(100, 100, 100, 4330.127018922193)]
        public void TriangleAreaTest_DefaultValues_Success(double a, double b, double c, double expected)
        {
            var calculator = new TriangleAreaCalculator();
            var p = new TriangleParameters() { A = a, B = b, C = c };
            var actual = calculator.Calculate(p);
            Assert.Equal(expected, actual, 10);
        }
    }
}
