namespace Spritebound.Tests;

[TestClass]
public class AnimatedSpritesheetTests : RecordTester<AnimatedSpritesheet>
{
    [TestClass]
    public class ToStringMethod : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void ToString_WhenFilenameIsBlank_ReturnWithoutFilename(string filename)
        {
            //Arrange
            var instance = Fixture.Build<AnimatedSpritesheet>().With(x => x.Filename, filename).Create();

            //Act
            var result = instance.ToString();

            //Assert
            result.Should().Be($"Spritesheet {instance.Id}");
        }

        [TestMethod]
        public void ToString_WhenFilenameIsNotBlank_ReturnWithFilename()
        {
            //Arrange
            var instance = Fixture.Create<AnimatedSpritesheet>();

            //Act
            var result = instance.ToString();

            //Assert
            result.Should().Be($"Spritesheet {instance.Id} ({Path.GetFileName(instance.Filename)})");
        }
    }

    [TestMethod]
    public void Ensure_IsJsonSerializable() => Ensure.IsJsonSerializable<AnimatedSpritesheet>(Fixture);
}