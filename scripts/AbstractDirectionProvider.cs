using Godot;

public abstract partial class AbstractDirectionProvider : Node
{

    public abstract Vector2 GetNextDirection(Vector2 currentDirection);
}
