namespace ToolBX.Spritebound.Mapping;

public interface ISpritesheetMap
{
    int Count { get; }
    BundledSpriteLocation this[int index] { get; }
    Result<BundledSpriteLocation> TryGet(int index);
}

public abstract class SpritesheetMap : ISpritesheetMap
{
    public int Count { get; }

    public BundledSpriteLocation this[int index]
    {
        get
        {
            if (index < 1 || index > Count) throw new ArgumentOutOfRangeException(nameof(index), string.Format(Exceptions.IndexOutOfRange, Count, index));

            var fromCache = _cache.SingleOrDefault(x => x.Index == index);
            if (fromCache != null)
                return fromCache;

            var amountPerLine = (_sheetSize / _spriteSize).Width;

            var y = (index - 1) / amountPerLine;
            var x = index - 1 - amountPerLine * y;
            var location = new BundledSpriteLocation(index, _filename, new Rectangle<int>(x * _spriteSize.Width, y * _spriteSize.Height, _spriteSize));
            _cache.Add(location);
            return location;
        }
    }

    public Result<BundledSpriteLocation> TryGet(int index)
    {
        if (index < 0 || index > Count) return Result<BundledSpriteLocation>.Failure();
        return Result<BundledSpriteLocation>.Success(this[index]);
    }

    private readonly IList<BundledSpriteLocation> _cache = new List<BundledSpriteLocation>();

    private readonly string _filename;
    private readonly Size<int> _sheetSize;
    private readonly Size<int> _spriteSize;

    protected SpritesheetMap(string filename, Size<int> sheetSize, Size<int> spriteSize)
    {
        if (string.IsNullOrWhiteSpace(filename)) throw new ArgumentNullException(nameof(filename));

        _filename = filename;
        _sheetSize = sheetSize;
        _spriteSize = spriteSize;

        var divided = sheetSize / spriteSize;
        Count = divided.Width * divided.Height;
    }
}