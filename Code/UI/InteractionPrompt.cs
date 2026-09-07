using Sandbox;

public sealed class InteractionPrompt : Component
{
    [Property]
    public TextRenderer ObjectNameText { get; set; }

    [Property]
    public TextRenderer ActionText { get; set; }

    [Property]
    public CameraComponent Camera { get; set; }

    private GameObject TargetObject;

    protected override void OnStart()
    {
        Hide();
    }

    protected override void OnUpdate()
    {
        if ( TargetObject == null || Camera == null )
            return;

        GameObject.WorldPosition =
            TargetObject.WorldPosition + Vector3.Up * 80f;

        var direction = Camera.WorldPosition - GameObject.WorldPosition;

        GameObject.WorldRotation =
            Rotation.LookAt( direction ) *
            Rotation.FromYaw( 180 );
    }

    public void Show( IInteractable target, GameObject targetObject )
    {
        TargetObject = targetObject;

        ObjectNameText.Text = target.DisplayName;
        ActionText.Text = $"[E] {target.InteractionText}";

        ObjectNameText.Enabled = true;
        ActionText.Enabled = true;
    }

    public void Hide()
    {
        TargetObject = null;

        ObjectNameText.Enabled = false;
        ActionText.Enabled = false;
    }
}