namespace Spritebound.Tests;

[TestClass]
public sealed class FrameTests : RecordTester<Frame>
{
    [TestMethod]
    public void Ensure_HasBasicGetSetFunctionality() => Ensure.HasBasicGetSetFunctionality<Frame>(Fixture);
}