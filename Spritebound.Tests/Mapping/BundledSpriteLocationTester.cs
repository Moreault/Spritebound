namespace Spritebound.Tests.Mapping
{
    [TestClass]
    public class BundledSpriteLocationTester
    {
        //TODO Test
        [TestClass]
        public class Serialization : Tester<BundledSpriteLocation>
        {
            //TODO Test (it suddenly doesn't like its multiple constructors but had no issue with it before)
            [TestMethod]
            public void Always_Deserialize()
            {
                //Arrange
                var json = JsonConvert.SerializeObject(Instance);

                //Act
                var result = JsonConvert.DeserializeObject<BundledSpriteLocation>(json);

                //Assert
                result.Should().Be(Instance);
            }
        }
    }
}