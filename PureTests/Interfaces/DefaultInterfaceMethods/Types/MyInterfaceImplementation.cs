namespace PureTests.Interfaces.DefaultInterfaceMethods.Types;

public class MyInterfaceImplementation : IMyInterface
{
    public MyInterfaceImplementation()
    {
        Prop = nameof(Prop);
    }

    public string? Prop { get; set; }

    public string GetProp() => "Get Prop from Implementation";
}