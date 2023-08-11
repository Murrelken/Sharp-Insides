namespace PureTests.Delegates;

public class DelegatesUnitTests
{
    public event EventHandler<EventArgs>? OnSmthTriggered;

    private const string NotUpdatedValue = "Not Updated Value";
    private const string UpdatedValue = "Updated Value";
    private string? _testField;
    
    [SetUp]
    public void SetUp()
    {
        _testField = NotUpdatedValue;
        OnSmthTriggered += (sender, args) =>
        {
            if(sender is not DelegatesUnitTests concreteSender) return;

            concreteSender._testField = DelegatesUnitTests.UpdatedValue;
        };
    }

    [Test]
    public void CheckBase()
    {
        Assert.That(_testField, Is.EqualTo(NotUpdatedValue));

        var temp = Volatile.Read (ref OnSmthTriggered);

        OnSmthTriggered = null;
        
        temp?.Invoke(this, EventArgs.Empty);
        
        Assert.That(_testField, Is.EqualTo(UpdatedValue));
    }
}