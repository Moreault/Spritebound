namespace Spritebound.Tests.Events;

[TestClass]
public class FrameEventTests : RecordTester<FrameEvent>
{
    [TestMethod]
    [DataRow("")]
    [DataRow(" ")]
    [DataRow(null)]
    public void ToString_WhenNameIsBlank_ReturnUnnamedEventMessage(string name)
    {
        //Arrange
        var instance = Fixture.Build<FrameEvent>().With(x => x.Name, name).Create();

        //Act
        var result = instance.ToString();

        //Assert
        result.Should().Be($"Trigger unnamed event at {instance.Origin}");
    }

    [TestMethod]
    public void ToString_WhenNameIsNotBlank_ReturnWithName()
    {
        //Arrange
        var instance = Fixture.Create<FrameEvent>();

        //Act
        var result = instance.ToString();

        //Assert
        result.Should().Be($"Trigger event {instance.Name} at {instance.Origin}");
    }

    [TestMethod]
    public void Ensure_HasBasicGetSetFunctionality() => Ensure.HasBasicGetSetFunctionality<FrameEvent>(Fixture);
}