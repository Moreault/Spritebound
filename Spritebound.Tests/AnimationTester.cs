namespace Spritebound.Tests;

[TestClass]
public class AnimationTester
{
    [TestClass]
    public class Id : Tester
    {
        [TestMethod]
        public void WhenValueIsSet_ReturnValue()
        {
            //Arrange
            var value = Fixture.Create<int>();

            //Act
            var instance = new Animation
            {
                Id = value,
            };

            //Assert
            instance.Id.Should().Be(value);
        }
    }

    [TestClass]
    public class Description : Tester
    {
        [TestMethod]
        public void WhenValueIsSet_ReturnValue()
        {
            //Arrange
            var value = Fixture.Create<string>();

            //Act
            var instance = new Animation
            {
                Description = value,
            };

            //Assert
            instance.Description.Should().Be(value);
        }
    }

    [TestClass]
    public class Frames : Tester
    {
        [TestMethod]
        public void WhenNullIsPassed_ReturnEmpty()
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
        public void WhenEmptyIsPassed_ReturnEmpty()
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
        public void WhenFramesArePassed_ReturnFrames()
        {
            //Arrange
            var frames = Fixture.CreateMany<Frame>().ToList();

            //Act
            var instance = new Animation
            {
                Frames = frames,
            };

            //Assert
            instance.Frames.Should().BeEquivalentTo(frames);
        }
    }

    [TestClass]
    public class FramesPerSecond : Tester
    {
        [TestMethod]
        public void WhenValueIsSet_ReturnValue()
        {
            //Arrange
            var value = Fixture.Create<int>();

            //Act
            var instance = new Animation
            {
                FramesPerSecond = value,
            };

            //Assert
            instance.FramesPerSecond.Should().Be(value);
        }

        [TestMethod]
        public void WhenValueIsNegative_SetToZero()
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
        public void WhenValueIsZero_SetToZero()
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
    }

    [TestClass]
    public class IsLooped : Tester
    {
        [TestMethod]
        public void WhenValueIsSet_ReturnValue()
        {
            //Arrange
            var value = Fixture.Create<bool>();

            //Act
            var instance = Fixture.Build<Animation>().With(x => x.IsLooped, value).Create();

            //Assert
            instance.IsLooped.Should().BeTrue();
        }
    }

    [TestClass]
    public class LoopRestartIndex : Tester
    {
        [TestMethod]
        public void WhenValueIsSet_ReturnValue()
        {
            //Arrange
            var value = Fixture.Create<int>();

            //Act
            var instance = Fixture.Build<Animation>().With(x => x.LoopRestartIndex, value).Create();

            //Assert
            instance.LoopRestartIndex.Should().Be(value);
        }

        [TestMethod]
        public void WhenValueIsNegative_SetToZero()
        {
            //Arrange
            var value = -Fixture.Create<int>();

            //Act
            var instance = Fixture.Build<Animation>().With(x => x.LoopRestartIndex, value).Create();

            //Assert
            instance.LoopRestartIndex.Should().Be(0);
        }

        [TestMethod]
        public void WhenValueIsZero_SetToZero()
        {
            //Arrange
            var value = 0;

            //Act
            var instance = Fixture.Build<Animation>().With(x => x.LoopRestartIndex, value).Create();

            //Assert
            instance.LoopRestartIndex.Should().Be(0);
        }
    }

    [TestClass]
    public class Duration : Tester
    {
        [TestMethod]
        public void WhenThereAreNoFrames_ReturnZero()
        {
            //Arrange
            var instance = Fixture.Build<Animation>().With(x => x.Frames, new List<Frame>()).Create();

            //Act
            var result = instance.Duration;

            //Assert
            result.Should().Be(0);
        }

        [TestMethod]
        public void WhenFramesPerSecondIsZero_ReturnZero()
        {
            //Arrange
            var instance = Fixture.Build<Animation>().With(x => x.FramesPerSecond, 0).Create();

            //Act
            var result = instance.Duration;

            //Assert
            result.Should().Be(0);
        }

        [TestMethod]
        public void WhenFramesHaveNoDelay_ReturnNumberOfFramesDividedByFramesPerSecond()
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
        public void WhenFramesHaveDelay_ReturnNumberOfFramesDividedByFramesPerSecondPlusAllFramesDelay()
        {
            //Arrange
            var instance = Fixture.Create<Animation>();

            //Act
            var result = instance.Duration;

            //Assert
            result.Should().Be(instance.Frames.Count / instance.FramesPerSecond + instance.Frames.Sum(x => x.Delay));
        }
    }

    [TestClass]
    public class EqualsMethod : Tester
    {
        [TestMethod]
        public void WhenOtherIsNull_ReturnFalse()
        {
            //Arrange
            var instance = Fixture.Create<Animation>();

            //Act
            var result = instance.Equals((Animation)null!);

            //Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void WhenReferencesAreEqual_ReturnTrue()
        {
            //Arrange
            var instance = Fixture.Create<Animation>();

            //Act
            var result = instance.Equals(instance);

            //Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void WhenEverythingButIdIsTheSame_ReturnFalse()
        {
            //Arrange
            var instance = Fixture.Create<Animation>();
            var other = instance with { Id = Fixture.Create<int>() };

            //Act
            var result = instance.Equals(other);

            //Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void WhenEverythingButFramesPerSecondIsTheSame_ReturnFalse()
        {
            //Arrange
            var instance = Fixture.Create<Animation>();
            var other = instance with { FramesPerSecond = Fixture.Create<int>() };

            //Act
            var result = instance.Equals(other);

            //Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void WhenEverythingButFramesIsTheSame_ReturnFalse()
        {
            //Arrange
            var instance = Fixture.Create<Animation>();
            var other = instance with { Frames = Fixture.CreateMany<Frame>().ToList() };

            //Act
            var result = instance.Equals(other);

            //Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void WhenEverythingButIsLoopedIsTheSame_ReturnFalse()
        {
            //Arrange
            var instance = Fixture.Create<Animation>();
            var other = instance with { IsLooped = !instance.IsLooped };

            //Act
            var result = instance.Equals(other);

            //Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void WhenEverythingButLoopRestartIndexIsTheSame_ReturnFalse()
        {
            //Arrange
            var instance = Fixture.Create<Animation>();
            var other = instance with { LoopRestartIndex = Fixture.Create<int>() };

            //Act
            var result = instance.Equals(other);

            //Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void WhenEverythingButDescriptionIsTheSame_ReturnTrue()
        {
            //Arrange
            var instance = Fixture.Create<Animation>();
            var other = instance with { Description = Fixture.Create<string>() };

            //Act
            var result = instance.Equals(other);

            //Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void WhenEverythingIsTheSame_ReturnTrue()
        {
            //Arrange
            var instance = Fixture.Create<Animation>();
            var other = instance with { };

            //Act
            var result = instance.Equals(other);

            //Assert
            result.Should().BeTrue();
        }
    }

    [TestClass]
    public class ToStringMethod : Tester
    {
        [TestMethod]
        public void Always_ReturnAnimationAndId()
        {
            //Arrange
            var instance = Fixture.Create<Animation>();

            //Act
            var result = instance.ToString();

            //Assert
            result.Should().Be($"Animation {instance.Id}");
        }
    }

    [TestClass]
    public class Serialization : Tester
    {
        [TestMethod]
        public void WhenUsingJson_DeserializeEquivalentObject()
        {
            //Arrange
            var instance = Fixture.Create<Animation>();
            var json = System.Text.Json.JsonSerializer.Serialize(instance);

            //Act
            var result = System.Text.Json.JsonSerializer.Deserialize<Animation>(json);

            //Assert
            result.Should().BeEquivalentTo(instance);
        }

        [TestMethod]
        public void WhenUsingNewtonsoft_DeserializeEquivalentObject()
        {
            //Arrange
            var instance = Fixture.Create<Animation>();
            var json = JsonConvert.SerializeObject(instance);

            //Act
            var result = JsonConvert.DeserializeObject<Animation>(json);

            //Assert
            result.Should().BeEquivalentTo(instance);
        }
    }
}