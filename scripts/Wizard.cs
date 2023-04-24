using Godot;

public partial class Wizard : Entity
{

    public override void _Ready()
    {
        base._Ready();

        GetNode<Area2D>("Area2D").AreaEntered += _ => OnAreaEntered();
    }

    private void OnAreaEntered()
    {
        signals.EmitSignal(Signals.SignalName.Killed);
    }
}
