static long RepeatedString(string s, long n)
{
    long result = 0;
    long restResult = 0;
    int rest = (int)(n % s.Length);

    for (int i = 0; i < s.Length; i++)
    {
        if (s[i] == 'a')
        {
            result++;

            if (i < rest)
            {
                restResult++;
            }
        }
    }

    result *= n / s.Length;

    return result + restResult;
}

string s = "aba";
long n = 10;

long result = RepeatedString(s, n);

Console.WriteLine(result);
