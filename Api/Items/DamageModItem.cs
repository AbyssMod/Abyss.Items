namespace Abyss.Api.Items;

public abstract class DamageModItem : SpatialModItem<DamageItemData>
{
    /// <inheritdoc />
    public sealed override ItemType Type => ItemType.DAMAGE;

    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        Item.id = "dmg";
        Item.canBeDiscardedByPlayer = false;
    }
}