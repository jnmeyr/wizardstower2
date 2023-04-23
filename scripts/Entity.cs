using Godot;

public abstract partial class Entity : Area2D
{

    protected Signals signals;

    protected DirectionChecker directionChecker;
    protected AbstractDirectionProvider directionProvider;

    protected Vector2 currentPosition;
    protected Vector2 currentDirection;

    public override void _Ready()
    {
        signals = GetNode<Signals>($"/root/{Signals.NAME}");
        signals.Update += Update;
        signals.Refresh += Refresh;

        directionChecker = GetNode<DirectionChecker>("DirectionChecker");
        directionProvider = GetNode<AbstractDirectionProvider>("DirectionProvider");

        int x = (int)(Position.X / 32);
        int y = (int)(Position.Y / 32);
        currentPosition = new Vector2(x, y);
    }

    private void Update()
    {
        Vector2 nextDirection = directionProvider.GetNextDirection(currentDirection);
        currentDirection =
            directionChecker.IsFree(nextDirection) ? nextDirection :
            directionChecker.IsFree(currentDirection) ? currentDirection :
            Vector2.Zero;
        currentPosition += currentDirection;
    }

    private void Refresh(double fraction)
    {
        float dx =
            currentDirection.X < 0 ? 1 :
            currentDirection.X > 0 ? -1 :
            0;
        float dy =
            currentDirection.Y < 0 ? 1 :
            currentDirection.Y > 0 ? -1 :
            0;
        Position = new Vector2(
            (float)(32 * currentPosition.X + 16 + 32 * dx * (1f - fraction)),
            (float)(32 * currentPosition.Y + 16 + 32 * dy * (1f - fraction))
        );
    }

    public override void _ExitTree()
    {
        signals.Update -= Update;
        signals.Refresh -= Refresh;
    }
}
