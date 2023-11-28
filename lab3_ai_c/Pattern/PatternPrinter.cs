namespace lab3_ai_c.Pattern;

public static class PatternPrinter
{
    public static void Print(int[,] pattern, int size)
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (pattern[i, j] == 1)
                {
                    Console.Write('*');
                }
                else
                {
                    Console.Write(' ');
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
