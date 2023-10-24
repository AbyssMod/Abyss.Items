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

    /// <summary>
    /// Whether or not this item can be sold
    /// </summary>
    public virtual bool CanBeSoldByPlayer => true;

    /// <summary>
    /// Whether or not this item can be sold in bulk sell actions
    /// </summary>
    public virtual bool CanBeSoldInBulkAction => true;

    /// <summary>
    /// Whether or not this item can be discarded by the player
    /// </summary>
    public virtual bool CanBeDiscardedByPlayer => true;

    public virtual bool canBeDiscardedDuringQuestPickup => true;

    /// <summary>
    /// Whether or not this item has a custom sell value
    /// </summary>
    public virtual bool HasSellOverride => false;

    /// <summary>
    /// if <see cref="HasSellOverride"/> is true, this is the value to sell the item for
    /// </summary>
    public virtual decimal SellOverrideValue => decimal.Zero;

    /// <summary>
    /// The number of research points required to have this item, used in researchable items (engines, nets, lights, etc)
    /// </summary>
    public virtual int researchPointsRequired => 0;

    /// <summary>
    /// Whether or not this item can be bought without needing to research it
    /// </summary>
    public virtual bool buyableWithoutResearch => researchPointsRequired == 0;

    /// <summary>
    /// The background color of the item
    /// </summary>
    public virtual Color ItemColor => new(65f, 65f, 65f, byte.MaxValue);

    public virtual int squishFactor => 0;

    /// <summary>
    /// The move behavior of the item
    /// </summary>
    public virtual MoveMode moveMode => MoveMode.FREE;

    /// <summary>
    /// The damaged behavior of the item
    /// </summary>
    public virtual DamageMode damageMode => DamageMode.DESTROY;

    /// <summary>
    /// The item prerequisites for this item
    /// </summary>
    public virtual List<OwnedItemResearchablePrerequisite> itemOwnPrerequisites => new();

    /// <summary>
    /// The research prerequisites for this item
    /// </summary>
    public virtual List<ResearchedItemResearchablePrerequisite> researchPrerequisites => new();

    /// <summary>
    /// Whether or not this item ignores damaged squares when placing, used ingame for equipment to allow new equipment to be installed over damaged equipment
    /// </summary>
    public virtual bool IgnoreDamageWhenPlacing => false;

    /// <summary>
    /// Whether this item is displayed underneath other items, only used ingame for the damage item
    /// </summary>
    public virtual bool IsUnderlayItem => false;

    /// <summary>
    /// WHether this item can go into storagwe
    /// </summary>
    public virtual bool ForbidStorageTray => false;

    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        Item.canBeSoldByPlayer = CanBeSoldByPlayer;
        Item.canBeSoldInBulkAction = CanBeSoldInBulkAction;
        Item.value = Value;
        Item.hasSellOverride = HasSellOverride;
        Item.sellOverrideValue = SellOverrideValue;
        Item.sprite = SpriteImage;
        Item.platformSpecificSpriteOverrides = null; //probably doesnt need to be exposed
        Item.itemColor = ItemColor;
        Item.canBeDiscardedByPlayer = CanBeDiscardedByPlayer;
        Item.canBeDiscardedDuringQuestPickup = canBeDiscardedDuringQuestPickup;
        Item.damageMode = damageMode;
        Item.moveMode = moveMode;
        Item.ignoreDamageWhenPlacing = IgnoreDamageWhenPlacing;
        Item.isUnderlayItem = IsUnderlayItem;
        Item.forbidStorageTray = ForbidStorageTray;
        Item.dimensions = Dimensions;
        Item.squishFactor = squishFactor;
        Item.itemOwnPrerequisites = itemOwnPrerequisites;
        Item.researchPrerequisites = researchPrerequisites;
        Item.researchPointsRequired = researchPointsRequired;
        Item.buyableWithoutResearch = buyableWithoutResearch;
    }
}

/// <summary>
/// A generic moditem using SpatialItemData
/// </summary>
[PublicAPI]
public abstract class SpatialModItem : SpatialModItem<SpatialItemData>
{
}