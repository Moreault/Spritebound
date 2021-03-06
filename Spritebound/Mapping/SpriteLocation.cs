namespace ToolBX.Spritebound.Mapping;

/// <summary>
/// Filename and coordinates indicating where the sprite is located.
/// </summary>
public record SpriteLocation
{
    public string Filename { get; init; } = string.Empty;

    public Rectangle<int> Coordinates { get; init; }

    public SpriteLocation(string name) : this(name, new Rectangle<int>())
    {

    }

    public SpriteLocation(string name, int width, int height) : this(name, new Rectangle<int>(0, 0, width, height))
    {

    }

    public SpriteLocation(string name, int x, int y, int width, int height) : this(name, new Rectangle<int>(x, y, width, height))
    {

    }

    public SpriteLocation(string name, Size<int> size) : this(name, new Rectangle<int>(0, 0, size))
    {

    }

    public SpriteLocation(string name, Vector2<int> position, Size<int> size) : this(name, new Rectangle<int>(position, size))
    {

    }

    public SpriteLocation(string name, Rectangle<int> coordinates)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        Filename = name;
        Coordinates = coordinates;
    }

    public override string ToString() => string.IsNullOrEmpty(Filename) ? "Invalid sprite location" : $"Sprite '{Path.GetFileName(Filename)}' at {Coordinates}";
}