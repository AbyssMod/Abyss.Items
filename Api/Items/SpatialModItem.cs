using System.Collections.Generic;
using UnityEngine;

namespace Abyss.Api.Items;

/// <summary>
/// A moditem using SpatialItemData
/// </summary>
/// <typeparam name="T"></typeparam>
[PublicAPI]
public abstract class SpatialModItem<T> : ModItem<T> where T : SpatialItemData
{
    /// <summary>
    /// The dimensions of the item
    /// </summary>
    public virtual List<Vector2Int> Dimensions => new()
    {
        new(0, 0)
    };

    /// <summary>
    /// How much the item is worth at the trader
    /// </summary>
    public abstract decimal Value { get; }

    /// <summary>
    /// The sprite to use for the item, set this to the name of the image file without the extension
    /// </summary>
    public virtual string SpriteIcon => GetType().Name + "-Sprite";

    /// <summary>
    /// The sprite to use for the item, override this if you dont want to use <see cref="SpriteIcon"/>
    /// </summary>
    public virtual Sprite? SpriteImage => GetSprite(SpriteIcon);

    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        Item.canBeSoldByPlayer = true;
        Item.canBeSoldInBulkAction = true;
        Item.value = Value;
        Item.hasSellOverride = false;
        Item.sellOverrideValue = decimal.Zero;
        Item.sprite = SpriteImage;
        Item.platformSpecificSpriteOverrides = null;
        Item.itemColor = new Color(0.1922f, 0.1922f, 0.1922f, 255);
        Item.canBeDiscardedByPlayer = true;
        Item.canBeDiscardedDuringQuestPickup = true;
        Item.damageMode = DamageMode.NONE;
        Item.moveMode = MoveMode.FREE;
        Item.ignoreDamageWhenPlacing = false;
        Item.isUnderlayItem = false;
        Item.forbidStorageTray = false;
        Item.dimensions = Dimensions;
        Item.squishFactor = 1f;
        Item.itemOwnPrerequisites = null;
        Item.researchPrerequisites = null;
        Item.researchPointsRequired = 0;
        Item.buyableWithoutResearch = true;
    }
}

/// <summary>
/// A generic moditem using SpatialItemData
/// </summary>
[PublicAPI]
public abstract class SpatialModItem : SpatialModItem<SpatialItemData>
{
}