
using Godot;

public partial class FailureState : AbstractState
{

    public const string StateName = "Failure";

    private Signals signals;
    private Game game;

    private Sprite2D failureImage;
    private AudioStreamPlayer failureSound;

    public override void _Ready()
    {
        signals = GetNode<Signals>($"/root/{Signals.NAME}");
        game = (Game)(GetParent().GetParent());
        failureImage = game.GetNode<Sprite2D>("FailureImage");
        failureSound = game.GetNode<AudioStreamPlayer>("FailureSound");
    }

    public override void EnterState()
    {
        failureSound.Play();
        failureImage.Visible = true;
        signals.Input += OnInput;
    }

    public override void LeaveState()
    {
        game.CallDeferred("ReplaceLevel", 1);
        failureImage.Visible = false;
        signals.Input -= OnInput;
    }

    private void OnInput(Vector2 input)
    {
        signals.EmitSignal(Signals.SignalName.PlayerInput, input);
        nextState = LevelState.StateName;
    }
}
