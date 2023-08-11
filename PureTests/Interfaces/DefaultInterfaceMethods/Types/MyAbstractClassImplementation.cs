namespace PureTests.Interfaces.DefaultInterfaceMethods.Types;

public class MyAbstractClassImplementation : MyAbstractClass
{
    public MyAbstractClassImplementation()
    {
        Prop = nameof(Prop);
    }

    public override string? Prop { get; }

    public override string GetProp() => "Get Prop from Implementation";
}