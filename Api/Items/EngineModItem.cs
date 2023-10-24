namespace Abyss.Api.Items;

/// <summary>
/// A spatial moditem using EngineItemData
/// </summary>
[PublicAPI]
public abstract class EngineModItem : SpatialModItem<EngineItemData>
{
    /// <inheritdoc />
    public sealed override ItemType Type => ItemType.EQUIPMENT;

    /// <inheritdoc />
    public sealed override ItemSubtype SubType => ItemSubtype.ENGINE;

    /// <summary>
    /// How many knots the engine will add to the player's speed
    /// </summary>
    public virtual float SpeedBonus => 6f;

    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        Item.speedBonus = SpeedBonus;
    }
}