using Godot;

public partial class Window : Node2D
{

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
        Area2D closed = GetNode<Area2D>("Closed");
        closed.QueueFree();
        RemoveChild(closed);
    }

    private void OnAreaEntered()
    {
        signals.EmitSignal(Signals.SignalName.UsedWindow);
    }

    public override void _ExitTree()
    {
        signals.CollectedAllGold -= OnCollectedAllGold;
    }
}
