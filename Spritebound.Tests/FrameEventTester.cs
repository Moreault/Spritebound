namespace Spritebound.Tests;

[TestClass]
public class FrameEventTester
{
    [TestClass]
    public class EqualsMethod : Tester<FrameEvent>
    {
        [TestMethod]
        public void WhenOtherIsNull_ReturnFalse()
        {
            //Arrange

            //Act
            var result = Instance.Equals(null);

            //Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void WhenReferencesAreTheSame_ReturnTrue()
        {
            //Arrange

            //Act
            var result = Instance.Equals(Instance);

            //Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void WhenNameIsDifferent_ReturnFalse()
        {
            //Arrange
            var other = Instance with { Name = Fixture.Create<string>() };

            //Act
            var result = Instance.Equals(other);

            //Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void WhenOriginIsDifferent_ReturnFalse()
        {
            //Arrange
            var other = Instance with { Origin = Fixture.Create<Vector3<int>>() };

            //Act
            var result = Instance.Equals(other);

            //Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void WhenNameIsTheSameButWithDifferentCasing_ReturnTrue()
        {
            //Arrange
            var other = Instance with { Name = Instance.Name.ToLowerInvariant() };

            //Act
            var result = Instance.Equals(other);

            //Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void WhenNameAndOriginAreTheSame_ReturnTrue()
        {
            //Arrange
            var other = Instance with { };

            //Act
            var result = Instance.Equals(other);

            //Assert
            result.Should().BeTrue();
        }
    }

    [TestClass]
    public class ToStringMethod : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenNameIsBlank_ReturnUnnamedEventMessage(string name)
        {
            //Arrange
            var instance = Fixture.Build<FrameEvent>().With(x => x.Name, name).Create();

            //Act
            var result = instance.ToString();

            //Assert
            result.Should().Be($"Trigger unnamed event at {instance.Origin}");
        }

        [TestMethod]
        public void WhenNameIsNotBlank_ReturnWithName()
        {
            //Arrange
            var instance = Fixture.Create<FrameEvent>();

            //Act
            var result = instance.ToString();

            //Assert
            result.Should().Be($"Trigger event {instance.Name} at {instance.Origin}");
        }
    }
}