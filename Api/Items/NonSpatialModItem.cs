namespace Abyss.Api.Items;

/// <summary>
/// A moditem using NonSpatialItemData
/// </summary>
[PublicAPI]
public abstract class NonSpatialModItem<T> : ModItem<T> where T : NonSpatialItemData
{
    /// <summary>
    /// If this item be shown in the cabin
    /// </summary>
    public virtual bool ShowInCabin => true;
    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        Item.showInCabin = ShowInCabin;
    }
}

