
namespace Abyss.Api.Items;

public abstract class LightModItem : SpatialModItem<LightItemData>
{
    /// <inheritdoc />
    public sealed override ItemType Type => ItemType.EQUIPMENT;

    /// <inheritdoc />
    public sealed override ItemSubtype SubType => ItemSubtype.LIGHT;

    public virtual float Lumens => 500f;
    public virtual float Range => 10f;

    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        Item.lumens = Lumens;
        Item.range = Range;
    }
}