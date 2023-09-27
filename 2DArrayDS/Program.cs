static int HourGlassSum(List<List<int>> arr)
{
    int result = int.MinValue;
    int sum;
    for (int i = 0; i < arr.Count - 2; i++)
    {
        for (int j = 0; j < arr[i].Count - 2; j++)
        {
            sum =      arr[i][j] + arr[i][j + 1] + arr[i][j + 2]
                               + arr[i + 1][j + 1]
                + arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];

            if (result < sum)
            {
                result = sum;
            }
        }        
    }

    return result;
}

var arr = new List<List<int>>
{
    new List<int> { 0, -4, -6, 0, -7, -6 },
    new List<int> { -1, -2, -6, -8, -3, -1 },
    new List<int> { -8, -4, -2, -8, -8, -6 },
    new List<int> { -3, -1, -2, -5, -7, -4 },
    new List<int> { -3, -5, -3, -6, -6, -6 },
    new List<int> { -3, -6, 0, -8, -6, -7 },
};

int result = HourGlassSum(arr);

Console.WriteLine(result);
