namespace PureTests;

public class TestUnitTests
{
    [Test]
    public void Test()
    {
        var s = "Grüße, Jürgen ❤";

        var charArr = s.ToArray();

        for (var i = 0; i < charArr.Length; i++)
        {
            Console.WriteLine(charArr[i].GetTypeCode());
        }
        Console.WriteLine(s.Length);

        Assert.Pass();
    }
}