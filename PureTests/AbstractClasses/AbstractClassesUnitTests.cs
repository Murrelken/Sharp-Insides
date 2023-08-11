namespace PureTests.AbstractClasses;

public class AbstractClassesUnitTests
{
    private abstract class AbstractClass
    {
    }

    private class ConcreteClass : AbstractClass
    {
        public string TestProp { get; set; } = nameof(TestProp);
        public string TestField = nameof(TestField);
        
        public new Type GetType()
        {
            return typeof(string);
        }
    }

    private ConcreteClass _concreteClass;

    [SetUp]
    public void SetUp()
    {
        _concreteClass = new ConcreteClass();
    }

    [Test]
    public void CheckBase()
    {
        Console.WriteLine(_concreteClass.GetType());

        var path = AppDomain.CurrentDomain.BaseDirectory + "test.txt";

        AppDomain.CurrentDomain.ProcessExit += (sender, args) =>
        {
            Console.WriteLine(path);
            using var fs = File.Create(path);
        };

        Console.WriteLine(((AbstractClass)_concreteClass).GetType());
        Console.WriteLine(((dynamic)_concreteClass).GetType());
        
        Assert.Pass();
    }
}