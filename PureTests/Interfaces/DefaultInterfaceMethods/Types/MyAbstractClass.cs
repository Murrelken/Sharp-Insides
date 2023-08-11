namespace PureTests.Interfaces.DefaultInterfaceMethods.Types;

public abstract class MyAbstractClass
{
    public virtual string? Prop => "Interface Prop";
    public virtual string GetProp() => Prop ?? "Prop is null";
}