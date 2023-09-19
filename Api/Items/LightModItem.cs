
namespace Abyss.Api.Items;

/// <summary>
/// A spatial moditem using LightItemData
/// </summary>
public abstract class LightModItem : SpatialModItem<LightItemData>
{
    /// <inheritdoc />
    public sealed override ItemType Type => ItemType.EQUIPMENT;

    /// <inheritdoc />
    public sealed override ItemSubtype SubType => ItemSubtype.LIGHT;

    /// <summary>
    /// The amount of lumens this light adds to the player
    /// </summary>
    public virtual float Lumens => 500f;
    /// <summary>
    /// The range of this light
    /// </summary>
    public virtual float Range => 10f;

    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        Item.lumens = Lumens;
        Item.range = Range;
    }
}