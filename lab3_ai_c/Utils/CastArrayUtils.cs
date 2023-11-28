namespace lab3_ai_c.Utils;

public static class CastArrayUtils
{
    public static int[] CastArrayTo1D(int[,] pattern)
    {
        return pattern.Cast<int>().ToArray();
    }

    public static int[,] CastArrayTo2D(int[] vector)
    {
        int size = 10;
        int index = 0;
        int[,] result = new int[size, size];

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                result[x, y] = vector[index];
                index++;
            }
        }

        return result;
    }
}
