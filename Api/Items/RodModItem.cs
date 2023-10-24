namespace Abyss.Api.Items;

/// <summary>
/// A harvester moditem using RodItemData
/// </summary>
[PublicAPI]
public abstract class RodModItem : HarvesterModItem<RodItemData>
{
    /// <inheritdoc />
    public sealed override ItemSubtype SubType => ItemSubtype.ROD;

    /// <summary>
    /// The bonus to the player's fishing speed
    /// </summary>
    public virtual float FishingSpeedModifier => 1f;

    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        Item.fishingSpeedModifier = FishingSpeedModifier;
        Item.canBeDiscardedByPlayer = true;
    }
}