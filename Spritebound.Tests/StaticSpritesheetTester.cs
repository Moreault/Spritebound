namespace Spritebound.Tests;

[TestClass]
public class StaticSpritesheetTester
{
    [TestClass]
    public class EqualsMethod : Tester
    {
        [TestMethod]
        public void WhenOtherIsNull_ReturnFalse()
        {
            //Arrange
            var instance = Fixture.Create<StaticSpritesheet>();

            //Act
            var result = instance.Equals(null);

            //Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void WhenReferencesAreTheSame_ReturnTrue()
        {
            //Arrange
            var instance = Fixture.Create<StaticSpritesheet>();

            //Act
            var result = instance.Equals(instance);

            //Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void WhenIdsAreDifferent_ReturnFalse()
        {
            //Arrange
            var instance = Fixture.Create<StaticSpritesheet>();
            var other = instance with { Id = Fixture.Create<int>() };

            //Act
            var result = instance.Equals(other);

            //Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void WhenFilenamesAreDifferent_ReturnFalse()
        {
            //Arrange
            var instance = Fixture.Create<StaticSpritesheet>();
            var other = instance with { Filename = Fixture.Create<string>() };

            //Act
            var result = instance.Equals(other);

            //Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void WhenCoordinatesAreDifferent_ReturnFalse()
        {
            //Arrange
            var instance = Fixture.Create<StaticSpritesheet>();
            var other = instance with { Coordinates = Fixture.CreateMany<Rectangle<int>>().ToList() };

            //Act
            var result = instance.Equals(other);

            //Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void WhenEverythingIsTheSame_ReturnTrue()
        {
            //Arrange
            var instance = Fixture.Create<StaticSpritesheet>();
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
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenFilenameIsBlank_ReturnWithoutFilename(string filename)
        {
            //Arrange
            var instance = Fixture.Build<StaticSpritesheet>().With(x => x.Filename, filename).Create();

            //Act
            var result = instance.ToString();

            //Assert
            result.Should().Be($"Spritesheet {instance.Id}");
        }

        [TestMethod]
        public void WhenFilenameIsNotBlank_ReturnWithFilename()
        {
            //Arrange
            var instance = Fixture.Create<StaticSpritesheet>();

            //Act
            var result = instance.ToString();

            //Assert
            result.Should().Be($"Spritesheet {instance.Id} ({Path.GetFileName(instance.Filename)})");
        }
    }
}