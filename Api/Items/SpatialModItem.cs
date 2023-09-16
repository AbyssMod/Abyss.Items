using System.Collections.Generic;
using UnityEngine;

namespace Abyss.Api.Items;

[PublicAPI]
public abstract class SpatialModItem<T> : ModItem<T> where T : SpatialItemData
{
    public virtual List<Vector2Int> Dimensions => new()
    {
        new(0, 0)
    };

    public abstract decimal Value { get; }

    public virtual string SpriteIcon => GetType().Name + "-Sprite";

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

[PublicAPI]
public abstract class SpatialModItem : SpatialModItem<SpatialItemData>
{
}