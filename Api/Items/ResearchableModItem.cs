namespace Abyss.Api.Items;

/// <summary>
/// A non-spatial moditem using ResearchableItemData
/// </summary>
[PublicAPI]
public abstract class ResearchableModItem : NonSpatialModItem<ResearchableItemData>
{
    /// <summary>
    /// The benefit this item provides
    /// </summary>
    public virtual ResearchBenefitType ResearchBenefitType => ResearchBenefitType.MOVEMENT_SPEED;
    /// <summary>
    /// The value of the benefit this item provides
    /// </summary>
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