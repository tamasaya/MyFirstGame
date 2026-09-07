using Sandbox;

public sealed class PlayerInteractor : Component
{
    private IInteractable CurrentTarget;

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

        var interactable  = trace.GameObject.Components.Get<IInteractable>();

        if ( interactable == null )
        {
            CurrentTarget = null;
            return;
        }

        if ( CurrentTarget != interactable )
        {
            CurrentTarget = interactable;
            Log.Info( $"Selected: {CurrentTarget.DisplayName}" );
        }
    }

    private void TryInteract()
    {
        if ( CurrentTarget == null )
            return;

        CurrentTarget.Interact();
    }
}