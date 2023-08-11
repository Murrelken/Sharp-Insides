namespace PureTests.Polymorphism;

public class OverrideVsNewUnitTests
{
    private const string TestVirtualPropOneBase = "TestVirtualPropOneBase";
    private const string TestVirtualPropTwoBase = "TestVirtualPropTwoBase";
    private const string TestPropOneBase = "TestPropOneBase";
    private const string TestVirtualPropOneInheritor = "TestVirtualPropOneInheritor";
    private const string TestVirtualPropTwoInheritor = "TestVirtualPropTwoInheritor";
    private const string TestPropOneInheritor = "TestPropOneInheritor";

    private class OverrideVsNewBase
    {  
        public virtual string TestVirtualPropOne => TestVirtualPropOneBase;
        public virtual string TestVirtualPropTwo => TestVirtualPropTwoBase;
        public string TestPropOne => TestPropOneBase;
    }

    private sealed class OverrideVsNewInheritor : OverrideVsNewBase
    {
        public override string TestVirtualPropOne => TestVirtualPropOneInheritor;
        public string TestVirtualPropTwo => TestVirtualPropTwoInheritor;
        public string TestPropOne => TestPropOneInheritor;
    }

    private sealed class OverrideVsNewAnotherInheritor : OverrideVsNewBase
    {
    }

    private OverrideVsNewBase _baseInstance;
    private OverrideVsNewBase _inheritorInstanceAsBase;
    private OverrideVsNewInheritor _inheritorInstance;

    [SetUp]
    public void SetUp()
    {
        _baseInstance = new OverrideVsNewBase();
        _inheritorInstanceAsBase = new OverrideVsNewInheritor();
        _inheritorInstance = new OverrideVsNewInheritor();
    }

    [Test]
    public void CheckBase()
    {
        void WriteLineByBase(OverrideVsNewBase baseInstanceParam)
        {
            Console.WriteLine(baseInstanceParam.GetType());
            Console.WriteLine();
            Console.WriteLine(baseInstanceParam.TestVirtualPropOne);
            Console.WriteLine(baseInstanceParam.TestVirtualPropTwo);
            Console.WriteLine(baseInstanceParam.TestPropOne);
            Console.WriteLine();
        }

        Console.WriteLine("WriteLineByBase");
        Console.WriteLine();
        WriteLineByBase(_baseInstance);
        WriteLineByBase(_inheritorInstanceAsBase);
        WriteLineByBase(_inheritorInstance);
        Console.WriteLine();
        
        Assert.Pass();
    }

    [Test]
    public void CheckDynamic()
    {
        void WriteLineByDynamic(dynamic baseInstanceParam)
        {
            Console.WriteLine(baseInstanceParam.GetType());
            Console.WriteLine();
            Console.WriteLine(baseInstanceParam.TestVirtualPropOne);
            Console.WriteLine(baseInstanceParam.TestVirtualPropTwo);
            Console.WriteLine(baseInstanceParam.TestPropOne);
            Console.WriteLine();
        }

        Console.WriteLine("WriteLineByDynamic");
        Console.WriteLine();
        WriteLineByDynamic(_baseInstance);
        WriteLineByDynamic(_inheritorInstanceAsBase);
        WriteLineByDynamic(_inheritorInstance);
        Console.WriteLine();
        
        Assert.Pass();
    }

    [Test]
    public void CheckAsIs()
    {
        Console.WriteLine("WriteLine As Is");
        Console.WriteLine();
        Console.WriteLine(_baseInstance.GetType());
        Console.WriteLine();
        Console.WriteLine(_baseInstance.TestVirtualPropOne);
        Console.WriteLine(_baseInstance.TestVirtualPropTwo);
        Console.WriteLine(_baseInstance.TestPropOne);
        Console.WriteLine();

        Console.WriteLine(_inheritorInstanceAsBase.GetType());
        Console.WriteLine();
        Console.WriteLine(_inheritorInstanceAsBase.TestVirtualPropOne);
        Console.WriteLine(_inheritorInstanceAsBase.TestVirtualPropTwo);
        Console.WriteLine(_inheritorInstanceAsBase.TestPropOne);
        Console.WriteLine();

        Console.WriteLine(_inheritorInstance.GetType());
        Console.WriteLine();
        Console.WriteLine(_inheritorInstance.TestVirtualPropOne);
        Console.WriteLine(_inheritorInstance.TestVirtualPropTwo);
        Console.WriteLine(_inheritorInstance.TestPropOne);
        Console.WriteLine();
        Assert.Pass();
    }
}