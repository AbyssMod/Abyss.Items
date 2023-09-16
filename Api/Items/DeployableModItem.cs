namespace Abyss.Api.Items;

public abstract class DeployableModItem : HarvesterModItem<DeployableItemData>
{
    public virtual float CatchRate => 1;
    public virtual float MaxDurabilityDays => 1;
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