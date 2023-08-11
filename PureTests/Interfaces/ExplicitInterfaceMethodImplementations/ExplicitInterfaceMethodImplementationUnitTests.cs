using System.Text;
using PureTests.Interfaces.DefaultInterfaceMethods.Types;

namespace PureTests.Interfaces.ExplicitInterfaceMethodImplementations;

public class ExplicitInterfaceMethodImplementationUnitTests
{
    private MyInterfaceFirstImplementation _firstImplementation;
    private MyInterfaceSecondImplementation _secondImplementation;
    private MyInterfaceThirdImplementation _thirdImplementation;

    [SetUp]
    public void SetUp()
    {
        _firstImplementation = new MyInterfaceFirstImplementation();
        _secondImplementation = new MyInterfaceSecondImplementation();
        _thirdImplementation = new MyInterfaceThirdImplementation();
    }

    [Test]
    public void CheckEIMI()
    {
        Console.WriteLine(_firstImplementation.InterfaceMethod());
        Console.WriteLine(((IMyInterface)_firstImplementation).InterfaceMethod());
        Console.WriteLine(_secondImplementation.InterfaceMethod());
        Console.WriteLine(((IMyInterface)_secondImplementation).InterfaceMethod());
        Console.WriteLine(_thirdImplementation.InterfaceMethod());
        Console.WriteLine(((IMyInterface)_thirdImplementation).InterfaceMethod());
    }
}

public interface IMyInterface
{
    public string InterfaceMethod();
}

public class MyInterfaceFirstImplementation : IMyInterface
{
    public string InterfaceMethod() => "First Implementation String";
    string IMyInterface.InterfaceMethod() => "First EIMI String";
}

public class MyInterfaceSecondImplementation : IMyInterface
{
    public string InterfaceMethod() => "Second Implementation String";
    string IMyInterface.InterfaceMethod() => "Second EIMI String";
}

public class MyInterfaceThirdImplementation : IMyInterface
{
    public string InterfaceMethod() => "Third Implementation String";
}