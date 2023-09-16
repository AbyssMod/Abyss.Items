namespace Abyss.Api.Items;

public abstract class NonSpatialModItem<T> : ModItem<T> where T : NonSpatialItemData
{
    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        Item.showInCabin = true;
    }
}

