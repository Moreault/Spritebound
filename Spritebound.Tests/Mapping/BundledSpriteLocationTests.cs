namespace Spritebound.Tests.Mapping;

[TestClass]
public sealed class BundledSpriteLocationTests : RecordTester<BundledSpriteLocation>
{
    [TestMethod]
    public void ParameterlessConstructor_Always_ReturnEmptyObject()
    {
        //Arrange

        //Act
        var result = new BundledSpriteLocation();

        //Assert
        result.Filename.Should().BeEmpty();
        result.Coordinates.Should().Be(new Rectangle<int>());
        result.Index.Should().Be(0);
    }

    [TestMethod]
    public void ConstructorWithName_Always_SetNameWithEmptyCoordinates()
    {
        //Arrange
        var index = Fixture.Create<int>();
        var name = Fixture.Create<string>();

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
        var index = Fixture.Create<int>();
        var name = Fixture.Create<string>();
        var width = Fixture.Create<int>();
        var height = Fixture.Create<int>();

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
        var index = Fixture.Create<int>();
        var name = Fixture.Create<string>();
        var x = Fixture.Create<int>();
        var y = Fixture.Create<int>();
        var width = Fixture.Create<int>();
        var height = Fixture.Create<int>();

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
        var index = Fixture.Create<int>();
        var name = Fixture.Create<string>();
        var size = Fixture.Create<Size<int>>();

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
        var index = Fixture.Create<int>();
        var name = Fixture.Create<string>();
        var position = Fixture.Create<Vector2<int>>();
        var size = Fixture.Create<Size<int>>();

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
        var index = Fixture.Create<int>();
        var name = Fixture.Create<string>();
        var coordinates = Fixture.Create<Rectangle<int>>();

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
        var instance = Fixture.Create<BundledSpriteLocation>();

        var json = JsonConvert.SerializeObject(instance);

        //Act
        var result = JsonConvert.DeserializeObject<BundledSpriteLocation>(json);

        //Assert
        result.Should().Be(instance);
    }

    [TestMethod]
    public void Ensure_IsJsonSerializable() => Ensure.IsJsonSerializable<BundledSpriteLocation>(Fixture);

    [TestMethod]
    public void Ensure_HasBasicGetSetFunctionality() => Ensure.HasBasicGetSetFunctionality<BundledSpriteLocation>(Fixture);
}