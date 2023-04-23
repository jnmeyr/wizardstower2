using Godot;

public partial class Signals : Node
{

    [Signal]
    public delegate void InputEventHandler(Vector2 input);

    [Signal]
    public delegate void PlayerInputEventHandler(Vector2 input);

    [Signal]
    public delegate void UpdateEventHandler();

    [Signal]
    public delegate void RefreshEventHandler(double fraction);

    [Signal]
    public delegate void CollectedGoldEventHandler();

    [Signal]
    public delegate void CollectedAllGoldEventHandler();

    [Signal]
    public delegate void KilledEventHandler();

    [Signal]
    public delegate void UsedStairsEventHandler(int nextLevel);

    [Signal]
    public delegate void UsedWindowEventHandler();

    public static string NAME = "Signals";
}
