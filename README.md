![Spritebound](https://github.com/Moreault/Spritebound/blob/master/spritebound.png)

# Spritebound
Spritesheet and animation management for sprite-based projects.

The base package for Sprites is kept as generic as possible to be allowed to be used with any .NET engine or framework. Specific implementations will likely come eventually.

For now, this base package only includes container classes meant to be used as part of a larger animation system.

## Static vs Animated spritesheet
StaticSpritesheets are used for inanimate sprite elements that are bundled under a single file. This could be tilesets, posters, items or UI elements.

AnimatedSpritesheets are used for animated sprite elements such as a character or a special effect.

## Spritesheets have an ID property! What do I do with that??
It's up to you and your engine/framework. Jackal uses the ID internally because they are part of a collection and it's faster to look for a numeric ID than compare strings.

It's not ideal (and not very ToolBX-like, I admit) but you could just ignore it.

However, if you do want to use the ID property, the Spritesheet base class implements IAutoIncremented<int> which is part of the ToolBX.Unicity library. That library has an extension method to automatically "get the next available ID" in an IEnumerable<T> where T implements IAutoIncremented<int>.

## SpritesheetMap
A map to a static spritesheet made up of sprites of equal size. Maps are automatically indexed by row from left to right. 

Rough Trigger uses this for country flags and weapon icons among other things.

## Events
Sometimes, you might need events to be triggered when a specific frame plays. This is what the FrameEvent class is there to achieve. 

FrameEvent.Name is used to identify the event in-game. In other words; that name must be the exact same on both ends for it to be recognized.

FrameEvent.Origin is optionally used when your event also needs a position. This is usually reserved for things like when a gun is fired so that the game knows exactly where it's fired from.

## Serialization
Both Newtonsoft.Json and System.Text are tested and supported but XML isn't. 

## Sprites.Jackal
Coming soon-ish : Complete animation system used in the Jackal 2D game engine.