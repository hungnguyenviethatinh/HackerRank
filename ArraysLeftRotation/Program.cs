static List<int> RotateLeft(List<int> a, int d)
{
    int n = a.Count;
    var result = new List<int>(n);
    
    for (int i = 0; i < n; i++)
    {
        if (d + i < n)
        {
            result.Add(a[d + i]);
        }
        else
        {
            result.Add(a[d + i - n]);
        }
    }

    return result;
}

//n = 5, d = 4
//a =      1 2 3 4 5
//result = 5 1 2 3 4
//15 13
//33 47 70 37 8 53 13 93 71 72 51 100 60 87 97
//87 97 33 47 70 37 8 53 13 93 71 72 51 100 60
//20 10
//41 73 89 7 10 1 59 58 84 77 77 97 58 1 86 58 26 10 86 51
//77 97 58 1 86 58 26 10 86 51 41 73 89 7 10 1 59 58 84 77

var a = new List<int> { 1, 2, 3, 4, 5 };
int d = 4;

List<int> result = RotateLeft(a, d);

Console.WriteLine(string.Join(',', result));
