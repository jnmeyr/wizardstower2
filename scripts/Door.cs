using Godot;

public partial class Door : Node2D
{

    [Export]
    private int nextLevel;

    private Signals signals;

    public override void _EnterTree()
    {
        signals = GetNode<Signals>($"/root/{Signals.NAME}");
        signals.CollectedAllGold += OnCollectedAllGold;
    }

    public override void _Ready()
    {
        GetNode<Area2D>("Open").AreaEntered += _ => OnAreaEntered();
    }

    private void OnCollectedAllGold()
    {
        Area2D closedDoor = GetNode<Area2D>("Closed");
        closedDoor.QueueFree();
        RemoveChild(closedDoor);
    }

    private void OnAreaEntered()
    {
        signals.EmitSignal(Signals.SignalName.UsedStairs, nextLevel);
    }

    public override void _ExitTree()
    {
        signals.CollectedAllGold -= OnCollectedAllGold;
    }
}
