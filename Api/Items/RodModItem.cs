namespace Abyss.Api.Items;

public abstract class RodModItem : HarvesterModItem<RodItemData>
{
    /// <inheritdoc />
    public sealed override ItemSubtype SubType => ItemSubtype.ROD;

    public virtual float FishingSpeedModifier => 1f;

    public virtual float AberrationCatchBonus => 0f;

    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        Item.fishingSpeedModifier = FishingSpeedModifier;
        Item.aberrationCatchBonus = AberrationCatchBonus;
    }
}