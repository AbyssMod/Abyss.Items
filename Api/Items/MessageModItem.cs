namespace Abyss.Api.Items;

/// <summary>
/// A non-spatial moditem using MessageItemData
/// </summary>
public abstract class MessageModItem : NonSpatialModItem<MessageItemData>
{
    /// <summary>
    /// The message to display
    /// </summary>
    public virtual string MessageBody => "";

    /// <summary>
    /// The chronological order of this message, only affects ordering when displaying messages
    /// </summary>
    public virtual int ChronologicalOrder => 0;

    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        Item.messageBodyKey = LocalizationManager.CreateLocalizedString(Id + "_MessageBody", MessageBody);
        Item.chronologicalOrder = ChronologicalOrder;
    }
}