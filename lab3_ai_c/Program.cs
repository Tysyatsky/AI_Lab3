using lab3_ai_c.Pattern;
using lab3_ai_c.Utils;

namespace lab3_ai_c
{
    class Program
    {
        private static readonly int size_v = 100;
        private static readonly int size_m = 10;
        static void Main()
        {
            HopfieldNetwork hopfield = new(size_v);

            int[] patA = CastArrayUtils.CastArrayTo1D(PatternLibrary.A);
            int[] patP = CastArrayUtils.CastArrayTo1D(PatternLibrary.P);
            int[] patO = CastArrayUtils.CastArrayTo1D(PatternLibrary.O);

            hopfield.Train(patA);
            hopfield.Train(patP);
            hopfield.Train(patO);

            Test(hopfield, PatternLibrary.A, PatternLibrary.A1);
            Test(hopfield, PatternLibrary.P, PatternLibrary.P1);
            Test(hopfield, PatternLibrary.O, PatternLibrary.O1);
        }

        private static void Test(HopfieldNetwork hopfield, int[,] expectedPattern, int[,] testPattern)
        {
            int[] testPatternFlat = CastArrayUtils.CastArrayTo1D(testPattern);
            int[] recalledPattern = hopfield.Recall(testPatternFlat);
            int[,] result = CastArrayUtils.CastArrayTo2D(recalledPattern);

            Console.WriteLine("--- Jagged pattern ---");
            PatternPrinter.Print(testPattern, size_m);
            Console.WriteLine("--- Expected pattern ---");
            PatternPrinter.Print(expectedPattern, size_m);
            Console.WriteLine("--- Result pattern ---");
            PatternPrinter.Print(result, size_m);
        }
    }
}