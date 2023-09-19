namespace Abyss.Api.Items;

/// <summary>
/// A harvester moditem using DeployableItemData
/// </summary>
public abstract class DeployableModItem : HarvesterModItem<DeployableItemData>
{
    /// <summary>
    /// The catch rate of the harvester
    /// </summary>
    public virtual float CatchRate => 1;
    /// <summary>
    /// The number of days the harvester will last
    /// </summary>
    public virtual float MaxDurabilityDays => 1;
    /// <summary>
    /// The time between when the harvester rolls for a catch
    /// </summary>
    public virtual float TimeBetweenCatchRolls => 1;

    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        Item.catchRate = CatchRate;
        Item.gridConfig = null;
        Item.maxDurabilityDays = MaxDurabilityDays;
        Item.timeBetweenCatchRolls = TimeBetweenCatchRolls;
    }
}