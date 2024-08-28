namespace FigureMath.Services
{
    public record class SortedTriangleParameters(double fCathenus, double sCathenus, double hypotheneus);
    public class TriangleAreaCalculator : IAreaCalculator<TriangleParameters>
    {
        public static double HalfPerimeter(TriangleParameters p) => (p.A + p.B + p.C) / 2;
        private static SortedTriangleParameters GetSortedParams(TriangleParameters p)
        {

            double[] sides = [p.A, p.B, p.C];
            var sorted = sides.OrderBy(x => x);

            return  new(sorted.First(),  sorted.Skip(1).Take(1).First(), sorted.Last());
        }
        //точность?
        public static bool IsStraightTriangle(TriangleParameters p)
        {
            if (p.A == p.B && p.C == p.B) return false;
            var sorted = GetSortedParams(p);
            var expected = Math.Pow(sorted.hypotheneus, 2);
            var result = Math.Pow(sorted.fCathenus, 2) + Math.Pow(sorted.sCathenus, 2);
            return expected - 10E-10 <= result && result <= expected + 10E-10;
        }
        public double Calculate(TriangleParameters parameters)
        {
            if (IsStraightTriangle(parameters))
            {
                var sorted = GetSortedParams(parameters);

                return 0.5 * sorted.fCathenus * sorted.sCathenus;
            }
            var halfPerimeter = HalfPerimeter(parameters);
            return Math.Sqrt(
                halfPerimeter * 
                (halfPerimeter - parameters.A) * 
                (halfPerimeter - parameters.B) *
                (halfPerimeter - parameters.C));
        }
    }
}
