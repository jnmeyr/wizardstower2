using Godot;

public partial class InputDirectionProvider : AbstractDirectionProvider
{

    private Signals signals;

    private Vector2 nextDirection;

    public override void _Ready()
    {
        signals = GetNode<Signals>($"/root/{Signals.NAME}");
        signals.PlayerInput += (Vector2 nextDirection) => this.nextDirection = nextDirection;
    }

    public override Vector2 GetNextDirection(Vector2 currentDirection)
    {
        return nextDirection;
    }
}
