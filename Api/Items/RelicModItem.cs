using UnityEngine;

namespace Abyss.Api.Items;

/// <summary>
/// A harvestable moditem using RelicItemData
/// </summary>
[PublicAPI]
public abstract class RelicModItem : HarvestableModItem<RelicItemData>
{
    /// <inheritdoc />
    public sealed override ItemType Type => ItemType.GENERAL;

    /// <inheritdoc />
    public sealed override ItemSubtype SubType => ItemSubtype.RELIC;

    /// <inheritdoc />
    public override HarvestableType HarvestableType => HarvestableType.DREDGE;

    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        Item.canBeDiscardedByPlayer = false;
        Item.itemColor = new Color(0.5294f, 0.1137f, 0.3451f, 255f);
    }
}