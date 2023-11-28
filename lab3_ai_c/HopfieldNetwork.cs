namespace lab3_ai_c;

class HopfieldNetwork
{
    private int size;
    private int[,] weights;
    private int[] states;

    public int Size { get => size; private set => size = value; }

    public HopfieldNetwork(int size)
    {
        Size = size;
        weights = new int[size, size];
        states = new int[size];
    }

    public void Train(int[] pattern)
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                if (i != j)
                {
                    weights[i, j] += pattern[i] * pattern[j];
                }
            }
        }
    }

    public int[] Recall(int[] pattern)
    {
        Array.Copy(pattern, states, Size);

        for (int i = 0; i < Size; i++)
        {
            int sum = 0;

            for (int j = 0; j < Size; j++)
            {
                sum += weights[i, j] * states[j];
            }

            states[i] = sum >= 0 ? 1 : -1;
        }

        return states;
    }
}