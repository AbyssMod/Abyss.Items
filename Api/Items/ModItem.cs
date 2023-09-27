using UnityEngine;

namespace Abyss.Api.Items;

/// <summary>
/// Base class for all modded items
/// </summary>
/// <typeparam name="T"></typeparam>
[PublicAPI]
public abstract class ModItem<T> : ScriptableObjectModContent<T> where T : ItemData
{
    /// <summary>
    /// The type of item this is
    /// </summary>
    public virtual ItemType Type => ItemType.GENERAL;
    /// <summary>
    /// The subtype of item this is
    /// </summary>
    public virtual ItemSubtype SubType => ItemSubtype.GENERAL;
    /// <summary>
    /// The icon to use for this item, set this to the name of the image file without the extension
    /// </summary>
    public virtual string ItemTypeIcon => GetType().Name + "-ItemType";

    /// <summary>
    /// The icon to use for this item, override this if you dont want to use <see cref="ItemTypeIcon"/>
    /// </summary>
    public virtual Sprite? ItemTypeImage => GetSprite(ItemTypeIcon);

    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        Item.id = Id;
        Item.itemNameKey = LocalizationManager.CreateLocalizedString(Id, DisplayName);
        Item.itemDescriptionKey = LocalizationManager.CreateLocalizedString(Id + "_Description", Description);
        Item.itemInsaneTitleKey = Item.itemNameKey;
        Item.itemInsaneDescriptionKey = Item.itemDescriptionKey;
        Item.linkedDialogueNode = null;
        Item.dialogueNodeSpecificDescription = null;
        Item.itemType = Type;
        Item.itemSubtype = SubType;
        Item.tooltipTextColor = Color.white;
        Item.tooltipNotesColor = Color.white;
        Item.itemTypeIcon = ItemTypeImage;
        Item.harvestParticlePrefab = null;
        Item.overrideHarvestParticleDepth = false;
        Item.harvestParticleDepthOffset = -3;
        Item.flattenParticleShape = false;
        Item.availableInDemo = false;


        Edit(Item);

        GameManager.Instance.ItemManager.allItems.Add(Item);
    }
}

/// <summary>
/// A generic moditem using ItemData
/// </summary>
[PublicAPI]
public abstract class ModItem : ModItem<ItemData>
{
}