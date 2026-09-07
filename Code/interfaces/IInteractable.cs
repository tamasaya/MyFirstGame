using Sandbox;

public interface IInteractable
{
    string DisplayName { get; }
    
    string InteractionText { get; }

    void Interact( GameObject interactor );
}