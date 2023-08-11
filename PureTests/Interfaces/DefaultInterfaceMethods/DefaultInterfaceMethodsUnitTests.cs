using PureTests.Interfaces.DefaultInterfaceMethods.Types;

namespace PureTests.Interfaces.DefaultInterfaceMethods;

public class DefaultInterfaceMethodsUnitTests
{
    [SetUp]
    public void SetUp()
    {
    }

    [Test]
    public void CheckIfDIMsWorkAsOverridedVirtualMethods()
    {
        var myInterfaceImplementation = new MyInterfaceImplementation();
        IMyInterface myInterfaceImplementationInterfaceCompileTime = myInterfaceImplementation;

        var myAbstractClassImplementation = new MyAbstractClassImplementation();
        MyAbstractClass myAbstractClassImplementationInterfaceCompileTime = myAbstractClassImplementation;
        Assert.Multiple(() =>
        {
            Assert.That(myInterfaceImplementation.Prop, Is.EqualTo(myAbstractClassImplementation.Prop));
            Assert.That(myInterfaceImplementation.GetProp(), Is.EqualTo(myAbstractClassImplementation.GetProp()));
            Assert.That(myInterfaceImplementationInterfaceCompileTime.Prop, Is.EqualTo(myAbstractClassImplementationInterfaceCompileTime.Prop));
            Assert.That(myInterfaceImplementationInterfaceCompileTime.GetProp(), Is.EqualTo(myAbstractClassImplementationInterfaceCompileTime.GetProp()));
        });
    }
}