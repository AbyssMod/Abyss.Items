using System.Collections.Generic;
using UnityEngine;

namespace Abyss.Api.Items;

public abstract class FishModItem : HarvestableModItem<FishItemData>
{
    /// <inheritdoc />
    public sealed override ItemType Type => ItemType.GENERAL;

    /// <inheritdoc />
    public sealed override ItemSubtype SubType => ItemSubtype.FISH;

    public virtual float MinSizeCentimeters => 0f;
    public virtual float MaxSizeCentimeters => 0f;
    public virtual List<FishItemData> Aberrations => new();
    public virtual bool IsAberration => false; //todo generic helper class for making aberrations
    public virtual bool Day => true;
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