namespace Spritebound.Tests.GarbageTypes;

public sealed class InstancedGarbageSpritesheetMap(string filename, Size<int> sheetSize, Size<int> spriteSize) : SpritesheetMap(filename, sheetSize, spriteSize);