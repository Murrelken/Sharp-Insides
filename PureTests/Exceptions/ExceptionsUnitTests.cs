namespace PureTests.Exceptions;

public class ExceptionsUnitTests
{
    [SetUp]
    public void SetUp()
    {
    }

    [Test]
    public void CheckIfThrownImplicitly()
    {
        try
        {
            MethodWithImplicitExceptionTryCatch();
        }
        catch (Exception e)
        {
            var firstStackTraceLineCodeLine = e.StackTrace
                .Split("\r\n")[0]
                .Split("line ")[1];
            
            Assert.That(firstStackTraceLineCodeLine, Is.EqualTo("42"));
        }
    }

    private void MethodWithImplicitExceptionTryCatch()
    {
        try
        {
            MethodWithImplicitExceptionThrow();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void MethodWithImplicitExceptionThrow()
    {
        throw new TestException("Implicit Throw");
    }

    [Test]
    public void CheckIfThrownExplicitly()
    {
        try
        {
            MethodWithExplicitExceptionTryCatch();
        }
        catch (Exception e)
        {
            var firstStackTraceLineCodeLine = e.StackTrace
                .Split("\r\n")[0]
                .Split("line ")[1];
            
            Assert.That(firstStackTraceLineCodeLine, Is.EqualTo("71"));
        }
    }

    private void MethodWithExplicitExceptionTryCatch()
    {
        try
        {
            MethodWithExplicitExceptionThrow();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw e;
        }
    }

    private void MethodWithExplicitExceptionThrow()
    {
        throw new TestException("Explicit Throw");
    }

    private class TestException : Exception
    {
        public TestException(string? message) : base(message)
        {
        }
    }
}