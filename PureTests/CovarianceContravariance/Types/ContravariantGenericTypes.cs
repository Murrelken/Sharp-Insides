namespace PureTests.CovarianceContravariance.Types;

/// <summary>
/// None of instances of type T is available for client's code by using some object by type of this interface.
/// So a client user (on compile-time stage) can't access and invoke any specific methods of an implementation of T.
/// 
/// However, it becomes possible to do so in concrete implementations of this interface.
/// Look at the ContravariantGenericInterfaceImplementation summary.
/// </summary>
/// <typeparam name="T"></typeparam>
internal interface IContravariantGenericInterface<in T> where T : First
{
    // Can't use contravariant generic types in properties' not private getters and methods' return params because it's not type-safe
    // T ContravariantProp { protected get; set; }
    // T GetSomeContravariantObject();

    // This works!
    T ContravariantProp { set; }
    void DoSmthWithContravariantObject(T value);
}

/// <summary>
/// If client use some object by type of this concrete implementation, the concrete T is known on compile-time,
/// and thus specific members of an implementation of T can be accessed and invoked.
/// That's the reason why previously private getter can be made public (or T can be used as a return value).
/// </summary>
/// <typeparam name="T"></typeparam>
internal class ContravariantGenericInterfaceImplementation<T> : IContravariantGenericInterface<T> where T : First
{
    public ContravariantGenericInterfaceImplementation(T contravariantProp)
    {
        ContravariantProp = contravariantProp;
    }

    public T ContravariantProp { get; set; }

    public void DoSmthWithContravariantObject(T value)
    {
        ContravariantProp = value;
    }
}