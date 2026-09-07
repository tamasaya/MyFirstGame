using Sandbox;

public sealed class PlayerInteractor : Component
{
    private PickupItem CurrentTarget;

    [Property]
    public CameraComponent Camera { get; set; }

    [Property]
    public float Distance { get; set; } = 150f;

    protected override void OnUpdate()
    {
        CheckTarget();

        if ( Input.Pressed( "use" ) )
        {
            TryInteract();
        }
    }

    private void CheckTarget()
    {
        var start = Camera.Transform.Position;
        var end = start + Camera.Transform.World.Forward * Distance;

        var trace = Scene.Trace
            .Ray( start, end )
            .Run();

        if ( !trace.Hit )
        {
            CurrentTarget = null;
            return;
        }

        var pickup = trace.GameObject.Components.Get<PickupItem>();

        if ( pickup == null )
        {
            CurrentTarget = null;
            return;
        }

        if ( CurrentTarget != pickup )
        {
            CurrentTarget = pickup;
            Log.Info( $"Selected: {CurrentTarget.DisplayName}" );
        }
    }

    private void TryInteract()
    {
        Log.Info( "Trying to interact" );
    }
}