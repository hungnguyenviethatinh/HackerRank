static int JumpingOnTheClouds(List<int> c)
{
    int result = 0;

    int current = 0;

    for (int i = 0; i < c.Count - 1; i++)
    {
        if (i != current)
        {
            continue;
        }
        
        if (i + 2 < c.Count && c[i + 2] == 0)
        {
            current = i + 2;
            result++;
        }
        else if (c[i + 1] == 0)
        {
            current = i + 1;
            result++;
        }
    }

    return result;
}

var c = new List<int> { 0, 0, 0, 1, 0, 0 };

int result = JumpingOnTheClouds(c);

Console.WriteLine(result);
