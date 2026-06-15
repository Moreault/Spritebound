namespace Spritebound.Tests;

[TestClass]
public class StaticSpritesheetTests : RecordTester<StaticSpritesheet>
{
    [TestMethod]
    [DataRow("")]
    [DataRow(" ")]
    [DataRow(null)]
    public void ToString_WhenFilenameIsBlank_ReturnWithoutFilename(string filename)
    {
        //Arrange
        var instance = Dummy.Build<StaticSpritesheet>().With(x => x.Filename, filename).Create();

        //Act
        var result = instance.ToString();

        //Assert
        result.Should().Be($"Spritesheet {instance.Id}");
    }

    [TestMethod]
    public void ToString_WhenFilenameIsNotBlank_ReturnWithFilename()
    {
        //Arrange
        var instance = Dummy.Create<StaticSpritesheet>();

        //Act
        var result = instance.ToString();

        //Assert
        result.Should().Be($"Spritesheet {instance.Id} ({Path.GetFileName(instance.Filename)})");
    }
}