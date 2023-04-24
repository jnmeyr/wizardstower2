using Godot;

public partial class Gold : Node2D
{

    private Signals signals;

    public override void _EnterTree()
    {
        signals = GetNode<Signals>($"/root/{Signals.NAME}");
    }

    public override void _Ready()
    {
        GetNode<Area2D>("Area2D").AreaEntered += _ => OnAreaEntered();
    }

    private void OnAreaEntered()
    {
        QueueFree();
        signals.EmitSignal(Signals.SignalName.CollectedGold);
    }
}
