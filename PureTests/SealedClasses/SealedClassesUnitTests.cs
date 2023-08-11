namespace PureTests.SealedClasses;

public class SealedClassesUnitTests
{
    private sealed class TestSealedClass
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }

    private class TestOpenClass
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }

    private TestSealedClass _testSealedClass;
    private TestOpenClass _testOpenClass;

    [SetUp]
    public void SetUp()
    {
        _testSealedClass = new TestSealedClass();
        _testOpenClass = new TestOpenClass();
    }

    [Test]
    public void CheckBase()
    {
        Console.WriteLine(_testSealedClass.ToString());
        Console.WriteLine(_testOpenClass.ToString());

        Assert.Pass();
    }
}