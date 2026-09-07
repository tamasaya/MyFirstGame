using Sandbox;

public sealed class PickupItem : Component
{
    [Property] public string DisplayName { get; set; } = "Бочка";

    public void PickUp()
    {
        Log.Info( $"Picked up {DisplayName}" );
    }
}