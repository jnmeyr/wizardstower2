public partial class Goblin : Entity
{

    public override void _Ready()
    {
        base._Ready();

        AreaEntered += _ => OnAreaEntered();
    }

    private void OnAreaEntered()
    {
        signals.EmitSignal(Signals.SignalName.Killed);
    }
}
