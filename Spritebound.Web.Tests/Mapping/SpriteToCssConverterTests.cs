namespace Spritebound.Web.Tests.Mapping;

[TestClass]
public class SpriteToCssConverterTests : Tester<SpriteToCssConverter>
{
    [TestMethod]
    public void ConvertParams_WhenSpritesIsNull_Throw()
    {
        //Arrange
        WebSpriteLocation[] sprites = null!;

        //Act
        var action = () => Instance.Convert(sprites);

        //Assert
        action.Should().Throw<ArgumentNullException>().WithParameterName(nameof(sprites));
    }

    [TestMethod]
    public void ConvertParams_WhenSpritesEmpty_ReturnEmpty()
    {
        //Arrange
        var sprites = Array.Empty<WebSpriteLocation>();

        //Act
        var result = Instance.Convert(sprites);

        //Assert
        result.Should().BeEmpty();
    }

    [TestMethod]
    public void ConvertParams_WhenThereIsSingleSprite_ConvertToCss()
    {
        //Arrange
        var sprite = Fixture.Create<WebSpriteLocation>();

        //Act
        var result = Instance.Convert(new List<WebSpriteLocation> { sprite });

        //Assert
        result.Should().Be($"background: url({sprite.Filename}) -{sprite.Position.X}px -{sprite.Position.Y}px no-repeat; width: {sprite.Size.Width}px; height: {sprite.Size.Height}px; zoom:{sprite.Zoom}; image-rendering: pixelated;");
    }

    [TestMethod]
    public void ConvertParams_WhenMultipleSprites_ConvertToLayeredCss()
    {
        //Arrange
        var sprites = Fixture.CreateMany<WebSpriteLocation>(2).ToArray();

        //Act
        var result = Instance.Convert(sprites);

        //Assert
        result.Should().Be($"background: url({sprites[1].Filename}) -{sprites[1].Position.X}px -{sprites[1].Position.Y}px no-repeat, url({sprites[0].Filename}) -{sprites[0].Position.X}px -{sprites[0].Position.Y}px no-repeat; width: {sprites[0].Size.Width}px; height: {sprites[0].Size.Height}px; zoom:{sprites[0].Zoom}; image-rendering: pixelated;");
    }




    [TestMethod]
    public void ConvertEnumerable_WhenSpritesIsNull_Throw()
    {
        //Arrange
        IEnumerable<WebSpriteLocation> sprites = null!;

        //Act
        var action = () => Instance.Convert(sprites);

        //Assert
        action.Should().Throw<ArgumentNullException>().WithParameterName(nameof(sprites));
    }

    [TestMethod]
    public void ConvertEnumerable_WhenSpritesEmpty_ReturnEmpty()
    {
        //Arrange
        var sprites = new List<WebSpriteLocation>();

        //Act
        var result = Instance.Convert(sprites);

        //Assert
        result.Should().BeEmpty();
    }

    [TestMethod]
    public void ConvertEnumerable_WhenThereIsSingleSprite_ConvertToCss()
    {
        //Arrange
        var sprite = Fixture.Create<WebSpriteLocation>();

        //Act
        var result = Instance.Convert(new List<WebSpriteLocation> { sprite });

        //Assert
        result.Should().Be($"background: url({sprite.Filename}) -{sprite.Position.X}px -{sprite.Position.Y}px no-repeat; width: {sprite.Size.Width}px; height: {sprite.Size.Height}px; zoom:{sprite.Zoom}; image-rendering: pixelated;");
    }

    [TestMethod]
    public void ConvertEnumerable_WhenMultipleSprites_ConvertToLayeredCss()
    {
        //Arrange
        var sprites = Fixture.CreateMany<WebSpriteLocation>(2).ToList();

        //Act
        var result = Instance.Convert(sprites);

        //Assert
        result.Should().Be($"background: url({sprites[1].Filename}) -{sprites[1].Position.X}px -{sprites[1].Position.Y}px no-repeat, url({sprites[0].Filename}) -{sprites[0].Position.X}px -{sprites[0].Position.Y}px no-repeat; width: {sprites[0].Size.Width}px; height: {sprites[0].Size.Height}px; zoom:{sprites[0].Zoom}; image-rendering: pixelated;");
    }
}