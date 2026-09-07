namespace Spritebound.Tests;

[TestClass]
public sealed class FrameTests : RecordTester<Frame>
{
    [TestMethod]
    public void Pins_WhenNullIsPassed_ReturnEmpty()
    {
        //Arrange

        //Act
        var instance = new Frame
        {
            Pins = null!,
        };

        //Assert
        instance.Pins.Should().BeEmpty();
    }

    [TestMethod]
    public void Pins_ByDefault_ReturnEmpty()
    {
        //Arrange

        //Act
        var instance = new Frame();

        //Assert
        instance.Pins.Should().BeEmpty();
    }

    [TestMethod]
    public void GetPin_WhenFrameHasNoPins_ReturnNull()
    {
        //Arrange
        var instance = new Frame();

        //Act
        var result = instance.GetPin(Dummy.Create<string>());

        //Assert
        result.Should().BeNull();
    }

    [TestMethod]
    public void GetPin_WhenNoPinGoesByThatName_ReturnNull()
    {
        //Arrange
        var instance = new Frame
        {
            Pins = [new FramePin { Name = "Hand", Position = Dummy.Create<Vector3<int>>() }]
        };

        //Act
        var result = instance.GetPin("Muzzle");

        //Assert
        result.Should().BeNull();
    }

    [TestMethod]
    public void GetPin_WhenAPinGoesByThatName_ReturnItsPosition()
    {
        //Arrange
        var muzzle = Dummy.Create<Vector3<int>>();
        var instance = new Frame
        {
            Pins =
            [
                new FramePin { Name = "Hand", Position = Dummy.Create<Vector3<int>>() },
                new FramePin { Name = "Muzzle", Position = muzzle }
            ]
        };

        //Act
        var result = instance.GetPin("Muzzle");

        //Assert
        result.Should().Be(muzzle);
    }

    [TestMethod]
    public void GetPin_WhenNameDiffersOnlyInCase_ReturnItsPosition()
    {
        //Arrange
        var muzzle = Dummy.Create<Vector3<int>>();
        var instance = new Frame
        {
            Pins = [new FramePin { Name = "Muzzle", Position = muzzle }]
        };

        //Act
        var result = instance.GetPin("muzzle");

        //Assert
        result.Should().Be(muzzle);
    }

    // The compiler's copy constructor would carry the cached hash onto the clone, which then hashes as the
    // frame it was copied from rather than as itself.
    [TestMethod]
    public void GetHashCode_WhenCopiedWithDifferentPins_ReturnDifferentHashCode()
    {
        //Arrange
        var instance = new Frame
        {
            Pins = [new FramePin { Name = "Hand", Position = Dummy.Create<Vector3<int>>() }]
        };
        var original = instance.GetHashCode();

        //Act
        var result = (instance with { Pins = [new FramePin { Name = "Muzzle", Position = Dummy.Create<Vector3<int>>() }] }).GetHashCode();

        //Assert
        result.Should().NotBe(original);
    }

    [TestMethod]
    public void GetHashCode_WhenCopiedUnchanged_ReturnSameHashCode()
    {
        //Arrange
        var instance = Dummy.Create<Frame>();

        //Act
        var result = (instance with { }).GetHashCode();

        //Assert
        result.Should().Be(instance.GetHashCode());
    }

    [TestMethod]
    public void Equals_WhenPinsAreEqualButNotTheSameInstances_ReturnTrue()
    {
        //Arrange
        var position = Dummy.Create<Vector3<int>>();
        var instance = new Frame { Pins = [new FramePin { Name = "Muzzle", Position = position }] };
        var other = new Frame { Pins = [new FramePin { Name = "Muzzle", Position = position }] };

        //Act
        var result = instance.Equals(other);

        //Assert
        result.Should().BeTrue();
    }

    [TestMethod]
    public void Equals_WhenPinsDiffer_ReturnFalse()
    {
        //Arrange
        var instance = new Frame { Pins = [new FramePin { Name = "Muzzle", Position = Dummy.Create<Vector3<int>>() }] };
        var other = new Frame { Pins = [new FramePin { Name = "Hand", Position = Dummy.Create<Vector3<int>>() }] };

        //Act
        var result = instance.Equals(other);

        //Assert
        result.Should().BeFalse();
    }

    [TestMethod]
    public void Ensure_HasBasicGetSetFunctionality() => Ensure.HasBasicGetSetFunctionality<Frame>(Dummy);
}
