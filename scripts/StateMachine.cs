using Godot;

public partial class StateMachine : Node
{

    private AbstractState currentState;

    public override void _Ready()
    {
        ReplaceState("Title");
    }

    public override void _Process(double delta)
    {
        string maybeNextState = currentState?.MaybeNextState();
        if (maybeNextState != null)
        {
            ReplaceState(maybeNextState);
        }
        currentState?.__Process(delta);
    }

    private void ReplaceState(string nextState)
    {
        currentState?.LeaveState();
        currentState = GetNode<AbstractState>(nextState);
        currentState?.EnterState();
    }
}
