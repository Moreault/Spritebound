namespace Spritebound.Tests.Mapping;

[TestClass]
public class SpritesheetMapTests : Tester<GarbageSpritesheetMap>
{
    [TestMethod]
    public void Count_Always_ReturnTotal()
    {
        //Arrange

        //Act
        var result = Instance.Count;

        //Assert
        result.Should().Be(400);
    }

    [TestMethod]
    public void Indexer_WhenIndexIsZero_Throw()
    {
        //Arrange
        var index = 0;

        //Act
        var action = () => Instance[index];

        //Assert
        action.Should().Throw<ArgumentOutOfRangeException>().WithMessage($"{string.Format(Exceptions.IndexOutOfRange, Instance.Count, index)} (Parameter 'index')");
    }

    [TestMethod]
    public void Indexer_WhenIndexIsNegative_Throw()
    {
        //Arrange
        var index = -Dummy.Create<int>();

        //Act
        var action = () => Instance[index];

        //Assert
        action.Should().Throw<ArgumentOutOfRangeException>().WithMessage($"{string.Format(Exceptions.IndexOutOfRange, Instance.Count, index)} (Parameter 'index')");
    }

    [TestMethod]
    public void Indexer_WhenIndexIsOverMax_Throw()
    {
        //Arrange
        var index = Instance.Count + Dummy.Create<short>();

        //Act
        var action = () => Instance[index];

        //Assert
        action.Should().Throw<ArgumentOutOfRangeException>().WithMessage($"{string.Format(Exceptions.IndexOutOfRange, Instance.Count, index)} (Parameter 'index')");
    }

    [TestMethod]
    public void Indexer_WhenIndexIsOne_ReturnFirstPosition()
    {
        //Arrange

        //Act
        var result = Instance[1];

        //Assert
        result.Should().Be(new BundledSpriteLocation(1, "spritesheet.png", new Rectangle<int>(0, 0, 16, 16)));
    }

    [TestMethod]
    public void Indexer_WhenIndexIsMax_ReturnLastPosition()
    {
        //Arrange

        //Act
        var result = Instance[400];

        //Assert
        result.Should().Be(new BundledSpriteLocation(400, "spritesheet.png", new Rectangle<int>(304, 304, 16, 16)));
    }

    [TestMethod]
    public void Indexer_WhenIndexIsBetweenOneAndMax_ReturnLocation()
    {
        //Arrange
        var index = Dummy.Number.Between(1, Instance.Count).Create();

        const int amountPerLine = 20;

        var y = (index - 1) / amountPerLine;
        var x = index - 1 - amountPerLine * y;

        //Act
        var result = Instance[index];

        //Assert
        result.Should().Be(new BundledSpriteLocation(index, "spritesheet.png", new Rectangle<int>(x * 16, y * 16, new Size<int>(16, 16))));
    }

    [TestMethod]
    public void Indexer_WhenSameIndexIsQueriedTwice_ReturnSameReference()
    {
        //Arrange
        var index = Dummy.Number.Between(1, Instance.Count).Create();

        //Act
        var result1 = Instance[index];
        var result2 = Instance[index];

        //Assert
        result1.Should().BeSameAs(result2);
    }

    [TestMethod]
    [DataRow("")]
    [DataRow(" ")]
    [DataRow(null)]
    public void Constructor_WhenSpritesheetIsBlank_Throw(string filename)
    {
        //Arrange

        //Act
        var action = () => new InstancedGarbageSpritesheetMap(filename, Dummy.Create<Size<int>>(), Dummy.Create<Size<int>>());

        //Assert
        action.Should().Throw<ArgumentNullException>().WithParameterName(nameof(filename));
    }

    [TestMethod]
    public void Constructor_WhenSpritesheetIsNotBlank_DoNotThrow()
    {
        //Arrange

        //Act
        var action = () => new InstancedGarbageSpritesheetMap(Dummy.Create<string>(), Dummy.Create<Size<int>>(), Dummy.Create<Size<int>>());

        //Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void TryGet_WhenIndexNegative_ReturnFailure()
    {
        //Arrange
        var index = -Dummy.Create<int>();

        //Act
        var result = Instance.TryGet(index);

        //Assert
        result.Should().Be(Result<BundledSpriteLocation>.Failure());
    }

    [TestMethod]
    public void TryGet_WhenIndexIsOutsideUpperLimit_ReturnFailure()
    {
        //Arrange
        var index = Instance.Count + Dummy.Create<int>();

        //Act
        var result = Instance.TryGet(index);

        //Assert
        result.Should().Be(Result<BundledSpriteLocation>.Failure());
    }

    [TestMethod]
    public void TryGet_WhenIndexIsWithinBoundaries_ReturnItemAtIndex()
    {
        //Arrange
        var index = Random.Shared.Next(1, Instance.Count);

        //Act
        var result = Instance.TryGet(index);

        //Assert
        result.Should().Be(Result<BundledSpriteLocation>.Success(Instance[index]));
    }
}