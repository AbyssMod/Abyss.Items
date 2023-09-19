﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Abyss.Api.Items;

/// <summary>
/// A spatial moditem using HarvesterItemData
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class HarvesterModItem<T> : SpatialModItem<T> where T : HarvesterItemData
{
    /// <inheritdoc />
    public sealed override ItemType Type => ItemType.EQUIPMENT;
    /// <summary>
    /// The types of harvestables this harvester can harvest
    /// </summary>
    public virtual IEnumerable<HarvestableType> HarvestableTypes => Array.Empty<HarvestableType>();
    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        Item.harvestableTypes = HarvestableTypes.ToArray();
    }
}