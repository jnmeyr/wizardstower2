using Godot;

public partial class Gold : Area2D
{

    private Signals signals;

    public override void _EnterTree()
    {
        signals = GetNode<Signals>($"/root/{Signals.NAME}");
    }

    public override void _Ready()
    {
        AreaEntered += _ => OnAreaEntered();
    }

    private void OnAreaEntered()
    {
        QueueFree();
        signals.EmitSignal(Signals.SignalName.CollectedGold);
    }
}
