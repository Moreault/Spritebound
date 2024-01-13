namespace Spritebound.Web.Tests.Mapping;

[TestClass]
public sealed class WebSpriteLocationTests : RecordTester<WebSpriteLocation>
{
    [TestMethod]
    public void ParameterlessConstructor_Always_SetNothing()
    {
        //Arrange

        //Act
        var result = new WebSpriteLocation();

        //Assert
        result.Should().BeEquivalentTo(new WebSpriteLocation
        {
            Filename = string.Empty,
            Coordinates = new Rectangle<int>(),
            Zoom = 0
        });
    }

    [TestMethod]
    public void ConstructorWithCoordinates_Always_SetCoordinatesAndZoom()
    {
        //Arrange
        var filename = Fixture.Create<string>();
        var coordinates = Fixture.Create<Rectangle<int>>();
        var zoom = Fixture.Create<int>();

        //Act
        var result = new WebSpriteLocation(filename, coordinates, zoom);

        //Assert
        result.Should().BeEquivalentTo(new WebSpriteLocation
        {
            Filename = filename,
            Coordinates = coordinates,
            Zoom = zoom
        });
    }

    [TestMethod]
    public void ConstructorWithFilenamePositionSizeAndZoom_Always_SetAllValues()
    {
        //Arrange
        var filename = Fixture.Create<string>();
        var position = Fixture.Create<Vector2<int>>();
        var size = Fixture.Create<Size<int>>();
        var zoom = Fixture.Create<int>();

        //Act
        var result = new WebSpriteLocation(filename, position, size, zoom);

        //Assert
        result.Should().BeEquivalentTo(new WebSpriteLocation
        {
            Filename = filename,
            Coordinates = new Rectangle<int>(position, size),
            Zoom = zoom
        });
    }

    [TestMethod]
    public void ToSTring_Always_ReturnFilenameAndCoordinatesPlusZoom()
    {
        //Arrange
        var instance = Fixture.Create<WebSpriteLocation>();

        //Act
        var result = instance.ToString();

        //Assert
        result.Should().Be($"{instance.Filename} ({instance.Coordinates}) x{instance.Zoom}");
    }

    [TestMethod]
    public void Ensure_IsJsonSerializable() => Ensure.IsJsonSerializable<WebSpriteLocation>(Fixture);

    [TestMethod]
    public void Ensure_HasBasicGetSetFunctionality() => Ensure.HasBasicGetSetFunctionality<WebSpriteLocation>(Fixture);
}