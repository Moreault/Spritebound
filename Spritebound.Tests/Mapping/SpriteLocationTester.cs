namespace Spritebound.Tests.Mapping
{
    [TestClass]
    public class SpriteLocationTester
    {
        //TODO Test

        [TestClass]
        public class Serialization : Tester<SpriteLocation>
        {
            [TestMethod]
            public void WhenUsingNewtonsoft_Deserialize()
            {
                //Arrange
                var json = JsonConvert.SerializeObject(Instance);

                //Act
                var result = JsonConvert.DeserializeObject<SpriteLocation>(json);

                //Assert
                result.Should().Be(Instance);
            }
        }
    }
}