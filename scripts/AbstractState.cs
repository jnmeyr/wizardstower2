using Godot;

public abstract partial class AbstractState : Node
{

    protected string nextState;

    public virtual void EnterState()
    {

    }

    public virtual string MaybeNextState()
    {
        string maybeNextState = nextState;
        nextState = null;
        return maybeNextState;
    }

    public virtual void __Process(double delta)
    {
        
    }

    public virtual void LeaveState()
    {

    }
}
