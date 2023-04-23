using Godot;

public partial class DirectionChecker : RayCast2D
{

    public bool IsFree(Vector2 direction)
    {
        return !IsBlocked(direction);
    }

    public bool IsBlocked(Vector2 direction)
    {
        TargetPosition = direction * 32;
        ForceUpdateTransform();
        ForceRaycastUpdate();
        return IsColliding();
    }
}
