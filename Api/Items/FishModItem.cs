using System.Collections.Generic;
using UnityEngine;

namespace Abyss.Api.Items;

/// <summary>
/// A harvestable moditem using FishItemData
/// </summary>
public abstract class FishModItem : HarvestableModItem<FishItemData>
{
    /// <inheritdoc />
    public sealed override ItemType Type => ItemType.GENERAL;

    /// <inheritdoc />
    public sealed override ItemSubtype SubType => ItemSubtype.FISH;

    /// <summary>
    /// The minimum size of the fish in centimeters
    /// </summary>
    public virtual float MinSizeCentimeters => 0f;
    /// <summary>
    /// The maximum size of the fish in centimeters
    /// </summary>
    public virtual float MaxSizeCentimeters => 0f;
    /// <summary>
    /// The aberrations that are linked to this fish
    /// </summary>
    public virtual List<FishItemData> Aberrations => new();
    /// <summary>
    /// Whether this fish is an aberration
    /// </summary>
    public virtual bool IsAberration => false; //todo generic helper class for making aberrations
    /// <summary>
    /// Whether this fish can be caught during the day
    /// </summary>
    public virtual bool Day => true;
    /// <summary>
    /// Whether this fish can be caught during the night
    /// </summary>
    public virtual bool Night => true;

    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        Item.minSizeCentimeters = MinSizeCentimeters;
        Item.maxSizeCentimeters = MaxSizeCentimeters;
        Item.aberrations = Aberrations;
        Item.isAberration = IsAberration;
        Item.nonAberrationParent = null;
        Item.minWorldPhaseRequired = 0;
        Item.locationHiddenUntilCaught = false;
        Item.day = Day;
        Item.night = Night;
        Item.canAppearInBaitBalls = true;
        Item.canBeInfected = true;
        Item.cellsExcludedFromDisplayingInfection = new List<Vector2Int>();
    }
}