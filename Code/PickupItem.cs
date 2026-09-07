using Sandbox;

// TEST PICKUP ITEM
public sealed class PickupItem : Component, IInteractable
{
    [Property]
    public string DisplayName { get; set; } = "Barrel";

    public void Interact()
    {
        Log.Info( $"Picked up: {DisplayName}" );
    }
}