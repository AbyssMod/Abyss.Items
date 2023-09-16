namespace Abyss.Api.Items;

public abstract class MessageModItem : NonSpatialModItem<MessageItemData>
{

    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        Item.chronologicalOrder = 0;
        Item.messageBodyKey = null;
    }
}