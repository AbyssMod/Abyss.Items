using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Abyss.Api.Items;

/// <summary>
/// A harvestable moditem using FishItemData
/// </summary>
[PublicAPI]
public abstract class FishModItem : HarvestableModItem<FishItemData>
{
    /// <inheritdoc />
    public sealed override ItemType Type => ItemType.GENERAL;

    /// <inheritdoc />
    public sealed override ItemSubtype SubType => ItemSubtype.FISH;

    /// <summary>
    /// The minimum size of the fish
    /// </summary>
    public virtual float MinSizeCentimeters => 0f;
    /// <summary>
    /// The maximum size of the fish
    /// </summary>
    public virtual float MaxSizeCentimeters => 0f;
    /// <summary>
    /// The aberrations of this fish
    /// </summary>
    public virtual List<FishItemData> Aberrations => new();
    /// <summary>
    /// Whether this fish is an aberration
    /// </summary>
    public virtual bool IsAberration => false;

    /// <summary>
    /// if this fish is an aberration, the non-aberration parent
    /// </summary>
    public virtual FishItemData? NonAberrationParent => null;

    /// <summary>
    /// Whether this fish can be caught during the day
    /// </summary>
    public virtual bool Day => true;
    /// <summary>
    /// Whether this fish can be caught during the night
    /// </summary>
    public virtual bool Night => true;

    /// <summary>
    /// The minimum world phase required for this fish to spawn (only applies to abberations)
    /// </summary>
    /// <remarks>Only used by <see cref="ItemManager.CreateFishItem"/></remarks>
    public virtual int MinWorldPhaseRequired => 0;

    /// <summary>
    /// Whether this fish can appear in bait fishing spots
    /// </summary>
    public virtual bool CanAppearInBaitBalls => true;

    /// <summary>
    /// Whether this fish can be infected
    /// </summary>
    public virtual bool CanBeInfected => true;

    /// <summary>
    /// The cells excluded from displaying infection bubbles
    /// </summary>
    public virtual List<Vector2Int> CellsExcludedFromDisplayingInfection => new();

    /// <summary>
    /// Whether this fish should be in the exotic category
    /// </summary>
    public virtual bool LocationHiddenUntilCaught => false;

    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        Item.minSizeCentimeters = MinSizeCentimeters;
        Item.maxSizeCentimeters = MaxSizeCentimeters;
        Item.aberrations = Aberrations;
        Item.isAberration = IsAberration;
        (ScriptableObjectInstances.ItemDatas.FirstOrDefault(x => x.id == NonAberrationParent.id) as FishItemData)?.aberrations.Add(Item);
        Item.nonAberrationParent = NonAberrationParent;
        Item.minWorldPhaseRequired = MinWorldPhaseRequired;
        Item.locationHiddenUntilCaught = LocationHiddenUntilCaught;
        Item.day = Day;
        Item.night = Night;
        Item.canAppearInBaitBalls = CanAppearInBaitBalls;
        Item.canBeInfected = CanBeInfected;
        Item.cellsExcludedFromDisplayingInfection = CellsExcludedFromDisplayingInfection;
    }
}