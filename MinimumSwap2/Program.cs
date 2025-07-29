// See https://aka.ms/new-console-template for more information

using (var m = new Main())
{
    await m.DoMainWorkAsync();
}

Console.ReadLine();

internal interface ITest
{
    Task DoWorkAsync();
}

internal class Test : ITest
{
    public async Task DoWorkAsync()
    {
        await Task.Delay(1000);
        Console.WriteLine("DoWorkAsync");
    }
}

internal interface ITest2
{
    Task DoWork2Async();
}

internal class Test2 : ITest2
{
    private readonly ITest _test;

    public Test2(ITest test)
    {
        _test = test;
    }

    public async Task DoWork2Async()
    {
        Console.WriteLine("DoWork2Async");
        await Task.Delay(10000);
        await _test.DoWorkAsync();
    }
}

internal class Main : IDisposable
{
    private ITest _test;
    private ITest2 _test2;

    public Main()
    {
        _test = new Test();
        _test2 = new Test2(_test);
    }

    public void Dispose()
    {
        _test = null;
        _test2 = null;
    }

    public async Task DoMainWorkAsync()
    {
        Console.WriteLine("DoMainWorkAsync");
        await Task.Delay(1000);
        _ = _test2.DoWork2Async();
    }
}
