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

    /// <summary>
    /// The number of days it takes to research this item
    /// </summary>
    public virtual int DaysToResearch => 1;

    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        Item.daysToResearch = DaysToResearch;
        Item.researchBenefitType = ResearchBenefitType;
        Item.researchBenefitValue = ResearchBenefitValue;
        Item.completedDescriptionKey = null;
    }
}