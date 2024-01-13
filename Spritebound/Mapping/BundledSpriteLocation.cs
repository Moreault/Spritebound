namespace ToolBX.Spritebound.Mapping;

public sealed record BundledSpriteLocation : SpriteLocation
{
    public int Index { get; init; }

    public BundledSpriteLocation()
    {

    }

    public BundledSpriteLocation(int index, string name) : base(name)
    {
        Index = index;
    }

    public BundledSpriteLocation(int index, string name, int width, int height) : base(name, width, height)
    {
        Index = index;
    }

    public BundledSpriteLocation(int index, string name, int x, int y, int width, int height) : base(name, x, y, width, height)
    {
        Index = index;
    }

    public BundledSpriteLocation(int index, string name, Size<int> size) : base(name, size)
    {
        Index = index;
    }

    public BundledSpriteLocation(int index, string name, Vector2<int> position, Size<int> size) : base(name, position, size)
    {
        Index = index;
    }

    public BundledSpriteLocation(int index, string name, Rectangle<int> coordinates) : base(name, coordinates)
    {
        Index = index;
    }
}