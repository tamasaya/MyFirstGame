using Sandbox;

// TEST PICKUP ITEM
public sealed class PickupItem : Component, IInteractable
{
    [Property]
    public string DisplayName { get; set; } = "Barrel";

    [Property]
    public string InteractionText { get; set; } = "Pick Up";

    public void Interact( GameObject interactor )
    {
        var inventory = interactor.Components.Get<Inventory>();

        if ( inventory == null )
            return;

        inventory.AddItem( DisplayName, 1 );

        GameObject.Destroy();
    }
}