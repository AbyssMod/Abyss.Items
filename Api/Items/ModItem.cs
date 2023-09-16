using UnityEngine;

namespace Abyss.Api.Items;

[PublicAPI]
public abstract class ModItem<T> : ScriptableObjectModContent<T> where T : ItemData
{
    public virtual ItemType Type => ItemType.GENERAL;
    public virtual ItemSubtype SubType => ItemSubtype.GENERAL;
    public virtual string ItemTypeIcon => GetType().Name + "-ItemType";

    public virtual Sprite? ItemTypeImage => GetSprite(ItemTypeIcon);

    internal const string ItemTableDefinition = "Items";

    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        Item.id = Id;
        Item.itemType = Type;
        Item.itemSubtype = SubType;
        Item.itemNameKey = LocalizationManager.CreateLocalizedString(Id, DisplayName);
        Item.itemDescriptionKey = LocalizationManager.CreateLocalizedString(Id + "_Description", Description);
        Item.itemInsaneTitleKey = Item.itemNameKey;
        Item.itemInsaneDescriptionKey = Item.itemDescriptionKey;
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

[PublicAPI]
public abstract class ModItem : ModItem<ItemData>
{
}