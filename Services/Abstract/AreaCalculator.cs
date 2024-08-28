using FigureMath.Services.Abstract;

namespace FigureMath.Services
{
    public interface IAreaCalculator<in T> where T : FigureParameters
    {
        public double Calculate(T parameters);
    }
}
