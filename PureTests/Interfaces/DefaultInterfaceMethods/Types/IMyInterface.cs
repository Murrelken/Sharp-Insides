namespace PureTests.Interfaces.DefaultInterfaceMethods.Types;

public interface IMyInterface
{
    public string? Prop => "Interface Prop";
    public string GetProp() => Prop ?? "Prop is null";
}