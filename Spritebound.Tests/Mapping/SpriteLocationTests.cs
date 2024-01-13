namespace Spritebound.Tests.Mapping;

[TestClass]
public class SpriteLocationTests : RecordTester<SpriteLocation>
{
    [TestMethod]
    public void NewtonsoftSerialization_Always_Deserialize()
    {
        //Arrange
        var instance = Fixture.Create<SpriteLocation>();

        var json = JsonConvert.SerializeObject(instance);

        //Act
        var result = JsonConvert.DeserializeObject<SpriteLocation>(json);

        //Assert
        result.Should().Be(instance);
    }

    [TestMethod]
    public void ParameterlessConstructor_Always_ReturnEmptyObject()
    {
        //Arrange

        //Act
        var result = new SpriteLocation();

        //Assert
        result.Filename.Should().BeEmpty();
        result.Coordinates.Should().Be(new Rectangle<int>());
    }

    [TestMethod]
    public void ConstructorWithName_Always_SetNameWithEmptyCoordinates()
    {
        //Arrange
        var name = Fixture.Create<string>();

        //Act
        var result = new SpriteLocation(name);

        //Assert
        result.Should().BeEquivalentTo(new SpriteLocation
        {
            Filename = name,
            Coordinates = new Rectangle<int>(),
        });
    }

    [TestMethod]
    public void ConstructorWithNameWidthAndHeight_Always_SetNameWidthAndHeight()
    {
        //Arrange
        var name = Fixture.Create<string>();
        var width = Fixture.Create<int>();
        var height = Fixture.Create<int>();

        //Act
        var result = new SpriteLocation(name, width, height);

        //Assert
        result.Should().BeEquivalentTo(new SpriteLocation
        {
            Filename = name,
            Coordinates = new Rectangle<int>(0, 0, width, height),
        });
    }

    [TestMethod]
    public void ConstructorWithNameAndAllIndividualCoordinates_Always_SetNameAndCoordinates()
    {
        //Arrange
        var name = Fixture.Create<string>();
        var x = Fixture.Create<int>();
        var y = Fixture.Create<int>();
        var width = Fixture.Create<int>();
        var height = Fixture.Create<int>();

        //Act
        var result = new SpriteLocation(name, x, y, width, height);

        //Assert
        result.Should().BeEquivalentTo(new SpriteLocation
        {
            Filename = name,
            Coordinates = new Rectangle<int>(x, y, width, height),
        });
    }

    [TestMethod]
    public void ConstructorWithNameAndSize_Always_SetNameAndSize()
    {
        //Arrange
        var name = Fixture.Create<string>();
        var size = Fixture.Create<Size<int>>();

        //Act
        var result = new SpriteLocation(name, size);

        //Assert
        result.Should().BeEquivalentTo(new SpriteLocation
        {
            Filename = name,
            Coordinates = new Rectangle<int>(0, 0, size),
        });
    }

    [TestMethod]
    public void ConstructorWithPositionAndSize_Always_SetAllCoordinates()
    {
        //Arrange
        var name = Fixture.Create<string>();
        var position = Fixture.Create<Vector2<int>>();
        var size = Fixture.Create<Size<int>>();

        //Act
        var result = new SpriteLocation(name, position, size);

        //Assert
        result.Should().BeEquivalentTo(new SpriteLocation
        {
            Filename = name,
            Coordinates = new Rectangle<int>(position, size),
        });
    }

    [TestMethod]
    public void ConstructorWithNameAndCoordinates_Always_SetNameAndCoordinates()
    {
        //Arrange
        var name = Fixture.Create<string>();
        var coordinates = Fixture.Create<Rectangle<int>>();

        //Act
        var result = new SpriteLocation(name, coordinates);

        //Assert
        result.Should().BeEquivalentTo(new SpriteLocation
        {
            Filename = name,
            Coordinates = coordinates,
        });
    }

    [TestMethod]
    public void ToString_WhenFilenameIsEmpty_ReturnInvalidSpriteLocation() => Ensure.WhenIsNullOrWhiteSpace(name =>
    {
        //Arrange

        //Act
        var result = new SpriteLocation(name).ToString();

        //Assert
        result.Should().Be("Invalid sprite location");
    });

    [TestMethod]
    public void ToString_WhenFilenameIsValid_ReturnFilenameWithCoordinates()
    {
        //Arrange
        var instance = Fixture.Create<SpriteLocation>();

        //Act
        var result = instance.ToString();

        //Assert
        result.Should().Be($"Sprite '{Path.GetFileName(instance.Filename)}' at {instance.Coordinates}");
    }

    [TestMethod]
    public void Ensure_IsJsonSerializable() => Ensure.IsJsonSerializable<SpriteLocation>(Fixture);

    [TestMethod]
    public void Ensure_HasBasicGetSetFunctionality() => Ensure.HasBasicGetSetFunctionality<SpriteLocation>(Fixture);
}