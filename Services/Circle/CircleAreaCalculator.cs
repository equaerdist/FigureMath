namespace FigureMath.Services
{
    public class CircleAreaCalculator : IAreaCalculator<CircleParameters>
    {
        public double Calculate(CircleParameters parameters) 
            => Math.Pow(parameters.Radius, 2) * Math.PI;
    }
}
