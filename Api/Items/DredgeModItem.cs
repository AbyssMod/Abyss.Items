using System.Collections.Generic;

namespace Abyss.Api.Items;

/// <summary>
/// A harvester moditem using DredgeItemData
/// </summary>
public abstract class DredgeModItem : HarvesterModItem<DredgeItemData>
{
    /// <inheritdoc />
    public sealed override ItemSubtype SubType => ItemSubtype.DREDGE;

    /// <inheritdoc />
    public sealed override IEnumerable<HarvestableType> HarvestableTypes => new[] { HarvestableType.DREDGE };
}