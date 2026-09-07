using Sandbox;

// TEST PICKUP ITEM
public sealed class PickupItem : Component, IInteractable
{
    [Property]
    public string DisplayName { get; set; } = "Barrel";

    [Property]
    public string InteractionText { get; set; } = "Pick Up";

    public void Interact()
    {
        Log.Info( $"Picked up: {DisplayName}" );
    }
}