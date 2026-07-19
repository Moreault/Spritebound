namespace Spritebound.Tests.Mapping;

[TestClass]
public class SpriteLocationTests : RecordTester<SpriteLocation>
{
    [TestMethod]
    public void NewtonsoftSerialization_Always_Deserialize()
    {
        //Arrange
        var instance = Dummy.Create<SpriteLocation>();

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
        var filename = Dummy.FileName.WithExtension.OneOf("png", "gif", "bmp", "jpg").Create();

        //Act
        var result = new SpriteLocation { Filename = filename };

        //Assert
        result.Filename.Should().Be(filename);
        result.Coordinates.Should().Be(new Rectangle<int>());
    }

    [TestMethod]
    public void ConstructorWithName_Always_SetNameWithEmptyCoordinates()
    {
        //Arrange
        var name = Dummy.Create<string>();

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
        var name = Dummy.Create<string>();
        var width = Dummy.Create<int>();
        var height = Dummy.Create<int>();

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
        var name = Dummy.Create<string>();
        var x = Dummy.Create<int>();
        var y = Dummy.Create<int>();
        var width = Dummy.Create<int>();
        var height = Dummy.Create<int>();

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
        var name = Dummy.Create<string>();
        var size = Dummy.Create<Size<int>>();

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
        var name = Dummy.Create<string>();
        var position = Dummy.Create<Vector2<int>>();
        var size = Dummy.Create<Size<int>>();

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
        var name = Dummy.Create<string>();
        var coordinates = Dummy.Create<Rectangle<int>>();

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
    public void ToString_WhenFilenameIsEmpty_Throw() => Ensure.WhenIsNullOrWhiteSpace(name =>
    {
        //Arrange

        //Act
        var action = () => new SpriteLocation(name);

        //Assert
        action.Should().Throw<ArgumentNullException>().WithParameterName("value");
    });

    [TestMethod]
    public void ToString_WhenFilenameIsValid_ReturnFilenameWithCoordinates()
    {
        //Arrange
        var instance = Dummy.Create<SpriteLocation>();

        //Act
        var result = instance.ToString();

        //Assert
        result.Should().Be($"Sprite '{Path.GetFileName(instance.Filename)}' at {instance.Coordinates}");
    }

    [TestMethod]
    public void Ensure_IsJsonSerializable() => Ensure.IsJsonSerializable<SpriteLocation>(Dummy);

    [TestMethod]
    public void Ensure_HasBasicGetSetFunctionality() => Ensure.HasBasicGetSetFunctionality<SpriteLocation>(Dummy);
}