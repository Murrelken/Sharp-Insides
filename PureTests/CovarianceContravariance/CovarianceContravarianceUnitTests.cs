using PureTests.CovarianceContravariance.Types;

namespace PureTests.CovarianceContravariance;

public class CovarianceContravarianceUnitTests
{
    [SetUp]
    public void SetUp()
    {
    }

    [Test]
    public void CheckBuiltInCovariant()
    {
        string[] strings = new string[] { "Test" };
        object[] objects = strings;

        objects[0] = "str";

        Console.WriteLine(objects[0]);

        Assert.Pass();
    }

    [Test]
    public void CheckCovariant()
    {
        ICovariantGenericInterface<Second> contravariantGenericSecond =
            new CovariantGenericInterfaceImplementation<Second>(new Second());
        ICovariantGenericInterface<First> contravariantGenericSecondToFirst = contravariantGenericSecond;

        Console.WriteLine(1);
        Console.WriteLine(contravariantGenericSecond.CovariantProp);
        Console.WriteLine(contravariantGenericSecond.GetSomeCovariantObject());

        Console.WriteLine(2);
        Console.WriteLine(contravariantGenericSecondToFirst.CovariantProp);
        Console.WriteLine(contravariantGenericSecondToFirst.GetSomeCovariantObject());

        Assert.Pass();
    }

    /// <summary>
    /// In fact, it doesn't matter what to pass as an input to the constructor - the runtime will be different,
    /// but the compile-time type will be the same (generic type defined on creating of concrete object) - "First"
    /// in this case
    /// </summary>
    [Test]
    public void CheckContravariantWithInheritorAsInput()
    {
        ContravariantGenericInterfaceImplementation<First> concreteContravariantGenericFirst =
            new ContravariantGenericInterfaceImplementation<First>(new Second());
        IContravariantGenericInterface<First> contravariantGenericFirst = concreteContravariantGenericFirst;
        IContravariantGenericInterface<Second> contravariantGenericFirstToSecond = contravariantGenericFirst;

        Console.WriteLine(0);
        contravariantGenericFirst.ContravariantProp = new Third();
        Console.WriteLine(contravariantGenericFirstToSecond.GetType().GetGenericArguments()[0]);
        Console.WriteLine(((ContravariantGenericInterfaceImplementation<First>)contravariantGenericFirstToSecond)
            .ContravariantProp);

        Console.WriteLine(1);
        Assert.DoesNotThrow(() =>
        {
            contravariantGenericFirst.DoSmthWithContravariantObject(new First());
            Console.WriteLine(concreteContravariantGenericFirst.ContravariantProp);
            contravariantGenericFirst.DoSmthWithContravariantObject(new Second());
            Console.WriteLine(concreteContravariantGenericFirst.ContravariantProp);
        });

        Console.WriteLine(2);
        Assert.DoesNotThrow(() =>
        {
            contravariantGenericFirst.ContravariantProp = new First();
            Console.WriteLine(concreteContravariantGenericFirst.ContravariantProp);
            contravariantGenericFirst.ContravariantProp = new Second();
            Console.WriteLine(concreteContravariantGenericFirst.ContravariantProp);
        });

        Console.WriteLine(3);
        Console.WriteLine(concreteContravariantGenericFirst.ContravariantProp);

        Console.WriteLine(4);
        Assert.DoesNotThrow(() =>
        {
            contravariantGenericFirstToSecond.DoSmthWithContravariantObject(new Second());
            Console.WriteLine(concreteContravariantGenericFirst.ContravariantProp);
        });

        Console.WriteLine(5);
        Assert.DoesNotThrow(() =>
        {
            contravariantGenericFirstToSecond.ContravariantProp = new Second();
            Console.WriteLine(concreteContravariantGenericFirst.ContravariantProp);
        });

        Assert.Pass();
    }

    [Test]
    public void CheckAssignmentCompatibility()
    {
        First first = new First();
        Second second = new Second();

        // Can't do that obviously
        // Second contravariantGenericFirstToSecond = first;
        First contravariantGenericSecondToFirst = second;

        Assert.Pass();
    }
}