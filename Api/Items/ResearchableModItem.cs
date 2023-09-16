namespace Abyss.Api.Items;

[PublicAPI]
public abstract class ResearchableModItem : NonSpatialModItem<ResearchableItemData>
{
    public virtual ResearchBenefitType ResearchBenefitType => ResearchBenefitType.MOVEMENT_SPEED;
    public virtual float ResearchBenefitValue => 0.05f;
    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        Item.completedDescriptionKey = null;
        Item.daysToResearch = 1f;
        Item.researchBenefitType = ResearchBenefitType;
        Item.researchBenefitValue = ResearchBenefitValue;
    }
}