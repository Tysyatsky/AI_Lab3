using lab3_ai_c.Pattern;
using lab3_ai_c.Utils;

namespace lab3_ai_c
{
    class Program
    {
        private static readonly int sizeVector = 100;
        private static readonly int sizeMatrix = 10;
        static void Main()
        {
            HopfieldNetwork hopfield = new(sizeVector);

            int[] patA = CastArrayUtils.CastArrayTo1D(PatternLibrary.A);
            int[] patP = CastArrayUtils.CastArrayTo1D(PatternLibrary.P);
            int[] patO = CastArrayUtils.CastArrayTo1D(PatternLibrary.O);

            hopfield.Train(patA);
            hopfield.Train(patP);
            hopfield.Train(patO);

            try
            {
                Menu(hopfield);
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Menu(HopfieldNetwork hopfield)
        {
            Console.WriteLine("Letter to test: A, P, O: ");
            var key = Console.ReadKey();
            int[,] letter;
            int[,] jaggedLetter;

            switch (key.Key)
            {
                case ConsoleKey.A:
                    letter = PatternLibrary.A;
                    jaggedLetter = PatternLibrary.A1;
                    break;
                case ConsoleKey.O:
                    letter = PatternLibrary.O;
                    jaggedLetter = PatternLibrary.O1;
                    break;
                case ConsoleKey.P:
                    letter = PatternLibrary.P;
                    jaggedLetter = PatternLibrary.P1;
                    break;
                default:
                    throw new NotSupportedException("The letter is not supported!");
            }

            Test(hopfield, letter, jaggedLetter);
        }

        private static void Test(HopfieldNetwork hopfield, int[,] expectedPattern, int[,] testPattern)
        {
            int[] testPatternFlat = CastArrayUtils.CastArrayTo1D(testPattern);
            int[] recalledPattern = hopfield.Recall(testPatternFlat);
            int[,] result = CastArrayUtils.CastArrayTo2D(recalledPattern);

            Console.WriteLine("--- Jagged pattern ---");
            PatternPrinter.Print(testPattern, sizeMatrix);
            Console.WriteLine("--- Expected pattern ---");
            PatternPrinter.Print(expectedPattern, sizeMatrix);
            Console.WriteLine("--- Result pattern ---");
            PatternPrinter.Print(result, sizeMatrix);
        }
    }
}