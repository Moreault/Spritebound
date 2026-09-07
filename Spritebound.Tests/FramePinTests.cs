namespace Spritebound.Tests;

[TestClass]
public class FramePinTests : RecordTester<FramePin>
{
    [TestMethod]
    public void Name_WhenNullIsPassed_ReturnEmpty()
    {
        //Arrange

        //Act
        var instance = new FramePin
        {
            Name = null!,
        };

        //Assert
        instance.Name.Should().BeEmpty();
    }

    [TestMethod]
    public void Equals_WhenNamesDifferOnlyInCase_ReturnTrue()
    {
        //Arrange
        var instance = Dummy.Build<FramePin>().With(x => x.Name, "Muzzle").Create();
        var other = instance with { Name = "MUZZLE" };

        //Act
        var result = instance.Equals(other);

        //Assert
        result.Should().BeTrue();
    }

    // Equal pins have to land in the same bucket : a case-insensitive Equals with a case-sensitive hash is
    // a dictionary that loses entries depending on how they were typed.
    [TestMethod]
    public void GetHashCode_WhenNamesDifferOnlyInCase_ReturnSameHashCode()
    {
        //Arrange
        var instance = Dummy.Build<FramePin>().With(x => x.Name, "Muzzle").Create();
        var other = instance with { Name = "MUZZLE" };

        //Act
        var result = instance.GetHashCode();

        //Assert
        result.Should().Be(other.GetHashCode());
    }

    [TestMethod]
    [DataRow("")]
    [DataRow(" ")]
    [DataRow(null)]
    public void ToString_WhenNameIsBlank_ReturnUnnamedPinMessage(string name)
    {
        //Arrange
        var instance = Dummy.Build<FramePin>().With(x => x.Name, name).Create();

        //Act
        var result = instance.ToString();

        //Assert
        result.Should().Be($"Unnamed pin at {instance.Position}");
    }

    [TestMethod]
    public void ToString_WhenNameIsNotBlank_ReturnWithName()
    {
        //Arrange
        var instance = Dummy.Create<FramePin>();

        //Act
        var result = instance.ToString();

        //Assert
        result.Should().Be($"Pin {instance.Name} at {instance.Position}");
    }

    [TestMethod]
    public void Ensure_HasBasicGetSetFunctionality() => Ensure.HasBasicGetSetFunctionality<FramePin>(Dummy);
}
