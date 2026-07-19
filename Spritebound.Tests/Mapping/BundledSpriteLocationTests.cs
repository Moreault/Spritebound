namespace Spritebound.Tests.Mapping;

[TestClass]
public sealed class BundledSpriteLocationTests : RecordTester<BundledSpriteLocation>
{
    [TestMethod]
    public void ParameterlessConstructor_Always_ReturnEmptyObjectWithFilename()
    {
        //Arrange
        var filename = Dummy.FileName.WithExtension.OneOf("png", "gif", "bmp", "jpg").Create();

        //Act
        var result = new BundledSpriteLocation { Filename = filename };

        //Assert
        result.Filename.Should().Be(filename);
        result.Coordinates.Should().Be(new Rectangle<int>());
        result.Index.Should().Be(0);
    }

    [TestMethod]
    public void ConstructorWithName_Always_SetNameWithEmptyCoordinates()
    {
        //Arrange
        var index = Dummy.Create<int>();
        var name = Dummy.Create<string>();

        //Act
        var result = new BundledSpriteLocation(index, name);

        //Assert
        result.Should().BeEquivalentTo(new BundledSpriteLocation
        {
            Index = index,
            Filename = name,
            Coordinates = new Rectangle<int>(),
        });
    }

    [TestMethod]
    public void ConstructorWithNameWidthAndHeight_Always_SetNameWidthAndHeight()
    {
        //Arrange
        var index = Dummy.Create<int>();
        var name = Dummy.Create<string>();
        var width = Dummy.Create<int>();
        var height = Dummy.Create<int>();

        //Act
        var result = new BundledSpriteLocation(index, name, width, height);

        //Assert
        result.Should().BeEquivalentTo(new BundledSpriteLocation
        {
            Index = index,
            Filename = name,
            Coordinates = new Rectangle<int>(0, 0, width, height),
        });
    }

    [TestMethod]
    public void ConstructorWithNameAndAllIndividualCoordinates_Always_SetNameAndCoordinates()
    {
        //Arrange
        var index = Dummy.Create<int>();
        var name = Dummy.Create<string>();
        var x = Dummy.Create<int>();
        var y = Dummy.Create<int>();
        var width = Dummy.Create<int>();
        var height = Dummy.Create<int>();

        //Act
        var result = new BundledSpriteLocation(index, name, x, y, width, height);

        //Assert
        result.Should().BeEquivalentTo(new BundledSpriteLocation
        {
            Index = index,
            Filename = name,
            Coordinates = new Rectangle<int>(x, y, width, height),
        });
    }

    [TestMethod]
    public void ConstructorWithNameAndSize_Always_SetNameAndSize()
    {
        //Arrange
        var index = Dummy.Create<int>();
        var name = Dummy.Create<string>();
        var size = Dummy.Create<Size<int>>();

        //Act
        var result = new BundledSpriteLocation(index, name, size);

        //Assert
        result.Should().BeEquivalentTo(new BundledSpriteLocation
        {
            Index = index,
            Filename = name,
            Coordinates = new Rectangle<int>(0, 0, size),
        });
    }

    [TestMethod]
    public void ConstructorWithPositionAndSize_Always_SetAllCoordinates()
    {
        //Arrange
        var index = Dummy.Create<int>();
        var name = Dummy.Create<string>();
        var position = Dummy.Create<Vector2<int>>();
        var size = Dummy.Create<Size<int>>();

        //Act
        var result = new BundledSpriteLocation(index, name, position, size);

        //Assert
        result.Should().BeEquivalentTo(new BundledSpriteLocation
        {
            Index = index,
            Filename = name,
            Coordinates = new Rectangle<int>(position, size),
        });
    }

    [TestMethod]
    public void ConstructorWithNameAndCoordinates_Always_SetNameAndCoordinates()
    {
        //Arrange
        var index = Dummy.Create<int>();
        var name = Dummy.Create<string>();
        var coordinates = Dummy.Create<Rectangle<int>>();

        //Act
        var result = new BundledSpriteLocation(index, name, coordinates);

        //Assert
        result.Should().BeEquivalentTo(new BundledSpriteLocation
        {
            Index = index,
            Filename = name,
            Coordinates = coordinates,
        });
    }


    [TestMethod]
    public void NewtonsoftSerialization_Always_Deserialize()
    {
        //Arrange
        var instance = Dummy.Create<BundledSpriteLocation>();

        var json = JsonConvert.SerializeObject(instance);

        //Act
        var result = JsonConvert.DeserializeObject<BundledSpriteLocation>(json);

        //Assert
        result.Should().Be(instance);
    }

    [TestMethod]
    public void Ensure_IsJsonSerializable() => Ensure.IsJsonSerializable<BundledSpriteLocation>(Dummy);

    [TestMethod]
    public void Ensure_HasBasicGetSetFunctionality() => Ensure.HasBasicGetSetFunctionality<BundledSpriteLocation>(Dummy);
}