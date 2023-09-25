static int SockMerchant(int n, List<int> ar)
{
    int result = 0;

    for (int i = 0; i < n - 1; i++)
    {
        if (ar[i] == 0)
        {
            continue;
        }

        for (int j = i + 1; j < n; j++)
        {
            if (ar[i] == ar[j])
            {
                ar[j] = 0;
                result++;

                break;
            }
        }
    }

    return result;
}

int n = 7;
var ar = new List<int> { 1, 2, 1, 1, 3, 2, 1 };

int result = SockMerchant(n, ar);

Console.WriteLine(result);
