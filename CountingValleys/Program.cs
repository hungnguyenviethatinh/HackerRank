static int CountingValleys(int steps, string path)
{
    int result = 0;
    int altitude = 0;
    int current = 1;

    for (int i = 0; i < steps - 1; i++)
    {
        if (i > 0 && i <= current)
        {
            continue;
        }

        if (path[i] == 'U')
        {
            altitude++;
        }

        if (path[i] == 'D')
        {
            altitude--;
        }

        for (int j = i + 1; j < steps; j++)
        {
            current = j;

            if (path[j] == 'U')
            {
                altitude++;
            }

            if (path[j] == 'D')
            {
                altitude--;
            }

            if (path[i] == 'U' && path[j] == 'D' && altitude == 0)
            {
                break;
            }

            if (path[i] == 'D' && path[j] == 'U' && altitude == 0)
            {
                result++;

                break;
            }
        }
    }

    return result;
}

//int steps = 10;
//string path = "DUDDDUUDUU";
int steps = 12;
string path = "DDUUDDUDUUUD";

int result = CountingValleys(steps, path);

Console.WriteLine(result);
