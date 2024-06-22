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
        var filename = Dummy.Create<string>();
        var coordinates = Dummy.Create<Rectangle<int>>();
        var zoom = Dummy.Create<int>();

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
        var filename = Dummy.Create<string>();
        var position = Dummy.Create<Vector2<int>>();
        var size = Dummy.Create<Size<int>>();
        var zoom = Dummy.Create<int>();

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
        var instance = Dummy.Create<WebSpriteLocation>();

        //Act
        var result = instance.ToString();

        //Assert
        result.Should().Be($"{instance.Filename} ({instance.Coordinates}) x{instance.Zoom}");
    }

    [TestMethod]
    public void Ensure_IsJsonSerializable() => Ensure.IsJsonSerializable<WebSpriteLocation>(Dummy);

    [TestMethod]
    public void Ensure_HasBasicGetSetFunctionality() => Ensure.HasBasicGetSetFunctionality<WebSpriteLocation>(Dummy);
}