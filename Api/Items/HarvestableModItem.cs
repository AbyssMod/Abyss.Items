namespace Abyss.Api.Items;

/// <summary>
/// A spatial moditem using HarvestableItemData
/// </summary>
/// <typeparam name="T"></typeparam>
[PublicAPI]
public abstract class HarvestableModItem<T> : SpatialModItem<T> where T : HarvestableItemData
{
    /// <summary>
    /// The type of minigame to use for this harvestable
    /// </summary>
    public virtual HarvestMinigameType HarvestMinigameType => HarvestMinigameType.DREDGE_RADIAL;
    /// <summary>
    /// The minimum amount of items to get per spot
    /// </summary>
    public virtual int PerSpotMin => 3;
    /// <summary>
    /// The maximum amount of items to get per spot
    /// </summary>
    public virtual int PerSpotMax => 3;
    /// <summary>
    /// The category of the harvestable
    /// </summary>
    public virtual HarvestPOICategory HarvestPoiCategory => HarvestPOICategory.FISH_SMALL;
    /// <summary>
    /// The depth of this harvestable
    /// </summary>
    public virtual HarvestableType HarvestableType => HarvestableType.SHALLOW;
    /// <summary>
    /// The difficulty of this harvestable's minigame
    /// </summary>
    public virtual HarvestDifficulty HarvestDifficulty => HarvestDifficulty.EASY;
    /// <summary>
    /// Whether or not this harvestable can be caught by a rod
    /// </summary>
    public virtual bool CanBeCaughtByRod => true;
    /// <summary>
    /// Whether or not this harvestable can be caught by a pot
    /// </summary>
    public virtual bool CanBeCaughtByPot => false;
    /// <summary>
    /// Whether or not this harvestable can be caught by a net
    /// </summary>
    public virtual bool CanBeCaughtByNet => false;
    /// <summary>
    /// The minimum depth this harvestable can be found at
    /// </summary>
    public virtual DepthEnum MinDepth => DepthEnum.VERY_SHALLOW;
    /// <summary>
    /// The maximum depth this harvestable can be found at
    /// </summary>
    public virtual DepthEnum MaxDepth => DepthEnum.VERY_DEEP;
    /// <summary>
    /// The locations this harvestable can be found in
    /// </summary>
    public virtual ZoneEnum ZonesFoundIn => ZoneEnum.ALL;

    /// <summary>
    /// The weight of this harvestable, used to control how often it spawns
    /// </summary>
    public virtual int HarvestableItemWeight => 1;

    /// <summary>
    /// Whether or not to regenerate the harvest spot when this harvestable is destroyed, mainly used for critical items for quests or other special, non-replaceable items
    /// </summary>
    public virtual bool RegenHarvestSpotOnDestroy => false;

    /// <summary>
    /// Whether or not this harvestable can be replaced with a research item, only used in dredging and crab pots
    /// </summary>
    public virtual bool CanBeReplacedWithResearchItem => false;



    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        Item.harvestMinigameType = HarvestMinigameType;
        Item.perSpotMin = PerSpotMin;
        Item.perSpotMax = PerSpotMax;
        Item.harvestItemWeight = HarvestableItemWeight;
        Item.regenHarvestSpotOnDestroy = RegenHarvestSpotOnDestroy;
        Item.harvestPOICategory = HarvestPoiCategory;
        Item.harvestableType = HarvestableType;
        Item.harvestDifficulty = HarvestDifficulty;
        Item.canBeReplacedWithResearchItem = false;
        Item.canBeCaughtByRod = CanBeCaughtByRod;
        Item.canBeCaughtByPot = CanBeCaughtByPot;
        Item.canBeCaughtByNet = CanBeCaughtByNet;
        Item.affectedByFishingSustain = true;
        Item.hasMinDepth = false;
        Item.minDepth = MinDepth;
        Item.hasMaxDepth = false;
        Item.maxDepth = MaxDepth;
        Item.zonesFoundIn = ZonesFoundIn;
    }
}