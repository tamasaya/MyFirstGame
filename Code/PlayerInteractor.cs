using Sandbox;

public sealed class PlayerInteractor : Component
{
    [Property]
    public CameraComponent Camera { get; set; }

    [Property]
    public InteractionPrompt InteractionPrompt { get; set; }

    [Property]
    public float Distance { get; set; } = 300f;

    private IInteractable CurrentTarget;

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
        var start = Camera.WorldPosition;
        var end = start + Camera.Transform.World.Forward * Distance;

        var trace = Scene.Trace
            .Ray( start, end )
            .Run();

        if ( !trace.Hit )
        {
            SetTarget( null, null );
            return;
        }

        var interactable =
            trace.GameObject.Components.Get<IInteractable>();

        SetTarget( interactable, trace.GameObject );
    }

    private void SetTarget( IInteractable newTarget, GameObject targetObject )
    {
        if ( CurrentTarget == newTarget )
            return;

        CurrentTarget = newTarget;

        if ( CurrentTarget == null )
        {
            InteractionPrompt?.Hide();
            return;
        }

        InteractionPrompt?.Show( CurrentTarget, targetObject );
    }

    private void TryInteract()
    {
        if ( CurrentTarget == null )
            return;

        CurrentTarget.Interact();
    }
}