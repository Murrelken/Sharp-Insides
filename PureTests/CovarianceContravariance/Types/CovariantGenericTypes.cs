namespace PureTests.CovarianceContravariance.Types;

internal interface ICovariantGenericInterface<out T> where T : First
{
    // Can't use covariant generic types in properties' not private setters and methods' input params because it's not type-safe
    // T CovariantProp { get; protected set; }
    // void DoSmthWithCovariantObject(T value);
        
    // This works!
    T CovariantProp { get; }
    T GetSomeCovariantObject();
}

internal class CovariantGenericInterfaceImplementation<T> : ICovariantGenericInterface<T> where T : First
{
    public CovariantGenericInterfaceImplementation(T covariantProp)
    {
        CovariantProp = covariantProp;
    }

    public T CovariantProp { get; set; }
    public T GetSomeCovariantObject()
    {
        return CovariantProp;
    }
}