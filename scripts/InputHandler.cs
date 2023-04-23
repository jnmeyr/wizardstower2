using Godot;

public partial class InputHandler : Node
{

    private Signals signals;

    public override void _Ready()
    {
        signals = GetNode<Signals>($"/root/{Signals.NAME}");
    }

    public override void _Process(double delta)
    {
		Vector2? maybeInput = 
			Input.IsActionJustPressed("move_left") ? Vector2.Left :
			Input.IsActionJustPressed("move_right") ? Vector2.Right :
			Input.IsActionJustPressed("move_up") ? Vector2.Up :
			Input.IsActionJustPressed("move_down") ? Vector2.Down :
			null;
		if (maybeInput is Vector2 input)
		{
			signals.EmitSignal(Signals.SignalName.Input, input);
		}
    }
}
