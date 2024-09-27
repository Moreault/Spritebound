namespace ToolBX.Spritebound.Mapping;

/// <summary>
/// Filename and coordinates indicating where the sprite is located.
/// </summary>
public record SpriteLocation
{
    public required string Filename
    {
        get => _filename;
        init => _filename = string.IsNullOrWhiteSpace(value) ? throw new ArgumentNullException(nameof(value)) : value;
    }
    private readonly string _filename = null!;

    public Rectangle<int> Coordinates { get; init; }

    public Vector2<int> Position => Coordinates.Position;

    public Size<int> Size => Coordinates.Size;

    public SpriteLocation()
    {

    }

    [SetsRequiredMembers]
    public SpriteLocation(string name) : this(name, new Rectangle<int>())
    {

    }

    [SetsRequiredMembers]
    public SpriteLocation(string name, int width, int height) : this(name, new Rectangle<int>(0, 0, width, height))
    {

    }

    [SetsRequiredMembers]
    public SpriteLocation(string name, int x, int y, int width, int height) : this(name, new Rectangle<int>(x, y, width, height))
    {

    }

    [SetsRequiredMembers]
    public SpriteLocation(string name, Size<int> size) : this(name, new Rectangle<int>(0, 0, size))
    {

    }

    [SetsRequiredMembers]
    public SpriteLocation(string name, Vector2<int> position, Size<int> size) : this(name, new Rectangle<int>(position, size))
    {

    }

    [SetsRequiredMembers]
    public SpriteLocation(string name, Rectangle<int> coordinates)
    {
        Filename = name;
        Coordinates = coordinates;
    }

    public override string ToString() => $"Sprite '{Path.GetFileName(Filename)}' at {Coordinates}";
}