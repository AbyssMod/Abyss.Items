namespace Abyss.Api.Items;

public abstract class EngineModItem : SpatialModItem<EngineItemData>
{
    /// <inheritdoc />
    public sealed override ItemType Type => ItemType.EQUIPMENT;

    /// <inheritdoc />
    public sealed override ItemSubtype SubType => ItemSubtype.ENGINE;

    public virtual float SpeedBonus => 6f;

    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        Item.speedBonus = SpeedBonus;
    }
}