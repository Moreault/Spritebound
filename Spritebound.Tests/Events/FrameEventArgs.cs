namespace Spritebound.Tests.Events;

[TestClass]
public sealed class FrameEventArgsTests : Tester
{
    [TestMethod]
    public void Ensure_ValueEquality() => Ensure.ValueEquality<FrameEventArgs>();

    [TestMethod]
    public void Ensure_ConsistentHashCode() => Ensure.ConsistentHashCode<FrameEventArgs>();
}