namespace Abyss.Api.Items;

[PublicAPI]
public abstract class HarvestableModItem<T> : SpatialModItem<T> where T : HarvestableItemData
{
    public virtual HarvestMinigameType HarvestMinigameType => HarvestMinigameType.DREDGE_RADIAL;
    public virtual int PerSpotMin => 3;
    public virtual int PerSpotMax => 3;
    public virtual HarvestPOICategory HarvestPoiCategory => HarvestPOICategory.FISH_SMALL;
    public virtual HarvestableType HarvestableType => HarvestableType.SHALLOW;
    public virtual HarvestDifficulty HarvestDifficulty => HarvestDifficulty.EASY;
    public virtual bool CanBeCaughtByRod => true;
    public virtual bool CanBeCaughtByPot => false;
    public virtual bool CanBeCaughtByNet => false;
    public virtual DepthEnum MinDepth => DepthEnum.VERY_SHALLOW;
    public virtual DepthEnum MaxDepth => DepthEnum.VERY_DEEP;
    public virtual ZoneEnum ZonesFoundIn => ZoneEnum.ALL;


    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        Item.harvestMinigameType = HarvestMinigameType;
        Item.perSpotMin = PerSpotMin;
        Item.perSpotMax = PerSpotMax;
        Item.harvestItemWeight = 1f;
        Item.regenHarvestSpotOnDestroy = false;
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