namespace Spritebound.Tests;

[TestClass]
public class AnimationTests : RecordTester<Animation>
{
    [TestMethod]
    public void Frames_WhenNullIsPassed_ReturnEmpty()
    {
        //Arrange

        //Act
        var instance = new Animation
        {
            Frames = null!,
        };

        //Assert
        instance.Frames.Should().BeEmpty();
    }

    [TestMethod]
    public void Frames_WhenEmptyIsPassed_ReturnEmpty()
    {
        //Arrange

        //Act
        var instance = new Animation
        {
            Frames = new List<Frame>(),
        };

        //Assert
        instance.Frames.Should().BeEmpty();
    }

    [TestMethod]
    public void FramesPerSecond_WhenValueIsNegative_SetToZero()
    {
        //Arrange
        var value = -Fixture.Create<int>();

        //Act
        var instance = new Animation
        {
            FramesPerSecond = value,
        };

        //Assert
        instance.FramesPerSecond.Should().Be(0);
    }

    [TestMethod]
    public void FramesPerSecond_WhenValueIsZero_SetToZero()
    {
        //Arrange

        //Act
        var instance = new Animation
        {
            FramesPerSecond = 0,
        };

        //Assert
        instance.FramesPerSecond.Should().Be(0);
    }

    [TestMethod]
    public void LoopRestartIndex_WhenValueIsNegative_SetToZero()
    {
        //Arrange
        var value = -Fixture.Create<int>();

        //Act
        var instance = Fixture.Build<Animation>().With(x => x.LoopRestartIndex, value).Create();

        //Assert
        instance.LoopRestartIndex.Should().Be(0);
    }

    [TestMethod]
    public void LoopRestartIndex_WhenValueIsZero_SetToZero()
    {
        //Arrange
        var value = 0;

        //Act
        var instance = Fixture.Build<Animation>().With(x => x.LoopRestartIndex, value).Create();

        //Assert
        instance.LoopRestartIndex.Should().Be(0);
    }

    [TestMethod]
    public void Duration_WhenThereAreNoFrames_ReturnZero()
    {
        //Arrange
        var instance = Fixture.Build<Animation>().With(x => x.Frames, new List<Frame>()).Create();

        //Act
        var result = instance.Duration;

        //Assert
        result.Should().Be(0);
    }

    [TestMethod]
    public void Duration_WhenFramesPerSecondIsZero_ReturnZero()
    {
        //Arrange
        var instance = Fixture.Build<Animation>().With(x => x.FramesPerSecond, 0).Create();

        //Act
        var result = instance.Duration;

        //Assert
        result.Should().Be(0);
    }

    [TestMethod]
    public void Duration_WhenFramesHaveNoDelay_ReturnNumberOfFramesDividedByFramesPerSecond()
    {
        //Arrange
        var frames = Fixture.Build<Frame>().With(x => x.Delay, 0).CreateMany().ToList();
        var instance = Fixture.Build<Animation>().With(x => x.Frames, frames).Create();

        //Act
        var result = instance.Duration;

        //Assert
        result.Should().Be(frames.Count / instance.FramesPerSecond);
    }

    [TestMethod]
    public void Duration_WhenFramesHaveDelay_ReturnNumberOfFramesDividedByFramesPerSecondPlusAllFramesDelay()
    {
        //Arrange
        var instance = Fixture.Create<Animation>();

        //Act
        var result = instance.Duration;

        //Assert
        result.Should().Be(instance.Frames.Count / instance.FramesPerSecond + instance.Frames.Sum(x => x.Delay));
    }

    [TestMethod]
    public void ToString_Always_ReturnAnimationAndId()
    {
        //Arrange
        var instance = Fixture.Create<Animation>();

        //Act
        var result = instance.ToString();

        //Assert
        result.Should().Be($"Animation {instance.Id}");
    }

    [TestMethod]
    public void Serialization_WhenUsingNewtonsoft_DeserializeEquivalentObject()
    {
        //Arrange
        var instance = Fixture.Create<Animation>();
        var json = JsonConvert.SerializeObject(instance);

        //Act
        var result = JsonConvert.DeserializeObject<Animation>(json);

        //Assert
        result.Should().BeEquivalentTo(instance);
    }

    [TestMethod]
    public void Ensure_HasBasicGetSetFunctionality() => Ensure.HasBasicGetSetFunctionality<Animation>(Fixture);

    [TestMethod]
    public void Ensure_IsJsonSerializable() => Ensure.IsJsonSerializable<Animation>(Fixture);
}