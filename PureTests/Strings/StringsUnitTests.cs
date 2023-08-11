namespace PureTests.Strings;

public class StringsUnitTests
{
    const int B = 60 * 60;
    [SetUp]
    public void SetUp()
    {
    }

    [Test]
    public void CheckBase()
    {
        var flag = false;
        var start = DateTime.Now;
        var end = DateTime.Now;
        Console.WriteLine("Test ToLower");
        for (int ii = 0; ii < 10; ii++)
        {
            using (var fs = File.Open("strings test.txt", FileMode.OpenOrCreate))
            {
                using var sr = new StreamReader(fs);
                start = DateTime.Now;
                for (var i = 0; i < 10000000; i++)
                {
                    var first = sr.ReadLine();
                    var second = sr.ReadLine();
                    flag = first!.ToLower() == second!.ToLower();
                }
                end = DateTime.Now;
            }
            Console.WriteLine($"ToLower: {(end-start).Milliseconds}");
        }

        Console.WriteLine("Test ToUpper");
        for (int ii = 0; ii < 10; ii++)
        {
            using (var fs = File.Open("strings test.txt", FileMode.OpenOrCreate))
            {
                using var sr = new StreamReader(fs);
                start = DateTime.Now;
                for (var i = 0; i < 10000000; i++)
                {
                    var first = sr.ReadLine();
                    var second = sr.ReadLine();
                    flag = first!.ToUpper() == second!.ToUpper();
                }
                end = DateTime.Now;
            }
            Console.WriteLine($"ToUpper: {(end-start).Milliseconds}");
        }

        Console.WriteLine(flag);
        Console.WriteLine(B);
        Assert.Pass();
    }

    [Test]
    public void FillFile()
    {
        // var random = new Random();
        // var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        // chars += chars.ToLower();
        // using var fs = File.Open("strings test.txt", FileMode.OpenOrCreate);
        // using var sw = new StreamWriter(fs);
        //
        // for (int i = 0; i < 10000000; i++)
        // {
        //     var s = Enumerable
        //         .Range(0, i % 10 + 3)
        //         .Select(_ => chars[random.Next(chars.Length)])
        //         .ToArray();
        //     sw.WriteLine(s);
        //     sw.WriteLine(s);
        // }
        Assert.Pass();
    }
}