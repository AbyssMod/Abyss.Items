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

    /// <summary>
    /// The y-value for the harvest particle system's position, only used if <see cref="OverrideHarvestParticleDepth"/> is true
    /// </summary>
    /// <remarks>Ingame default value is -3</remarks>
    public virtual int HarvestParticleDepthOffset => -3;

    /// <summary>
    /// The color of the tooltip text
    /// </summary>
    public virtual Color TooltipTextColor => Color.white;

    /// <summary>
    /// The color of the tooltip notes text
    /// </summary>
    public virtual Color TooltipNotesColor => Color.white;

    public virtual bool flattenParticleShape => false;

    /// <summary>
    /// Whether or not to override the harvest particle depth
    /// </summary>
    public virtual bool OverrideHarvestParticleDepth => false;

    /// <summary>
    /// The particle prefab to use for POIs
    /// </summary>
    public virtual GameObject? HarvestParticlePrefab => null;

    /// <summary>
    /// If this is not "", the name of the node that will set the description to <see cref="DialogueNodeSpecificDescription"/>
    /// </summary>
    /// <remarks>Checked ingame using <code>GameManager.Instance.DialogueRunner.GetHasVisitedNode(itemData.linkedDialogueNode)</code></remarks>
    public virtual string LinkedDialogueNode => "";

    /// <summary>
    /// The description to use if the player has visited <see cref="LinkedDialogueNode"/>
    /// </summary>
    public virtual string DialogueNodeSpecificDescription => "";

    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        Item.id = Id;
        Item.itemNameKey = LocalizationManager.CreateLocalizedString(Id, DisplayName);
        Item.itemDescriptionKey = LocalizationManager.CreateLocalizedString(Id + "_Description", Description);
        Item.itemInsaneTitleKey = Item.itemNameKey;
        Item.itemInsaneDescriptionKey = Item.itemDescriptionKey;
        Item.linkedDialogueNode = LinkedDialogueNode;
        Item.dialogueNodeSpecificDescription = LocalizationManager.CreateLocalizedString(Id + "_DialogueDescription", DialogueNodeSpecificDescription);
        Item.itemType = Type;
        Item.itemSubtype = SubType;
        Item.tooltipTextColor = TooltipTextColor;
        Item.tooltipNotesColor = TooltipNotesColor;
        Item.itemTypeIcon = ItemTypeImage;
        Item.harvestParticlePrefab = HarvestParticlePrefab;
        Item.overrideHarvestParticleDepth = OverrideHarvestParticleDepth;
        Item.harvestParticleDepthOffset = HarvestParticleDepthOffset;
        Item.flattenParticleShape = flattenParticleShape;
        Item.availableInDemo = false; //doesnt need to be exposed

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