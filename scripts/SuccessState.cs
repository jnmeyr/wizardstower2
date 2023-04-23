
using Godot;

public partial class SuccessState : AbstractState
{

    public const string StateName = "Success";

    private Signals signals;
    private Game game;

    private Sprite2D successImage;
    private AudioStreamPlayer successSound;

    public override void _Ready()
    {
        signals = GetNode<Signals>($"/root/{Signals.NAME}");
        game = (Game)(GetParent().GetParent());
        successImage = game.GetNode<Sprite2D>("SuccessImage");
        successSound = game.GetNode<AudioStreamPlayer>("SuccessSound");
    }

    public override void EnterState()
    {
        successSound.Play();
        successImage.Visible = true;
        signals.Input += OnInput;
    }

    public override void LeaveState()
    {
        game.CallDeferred("ReplaceLevel", 1);
        successImage.Visible = false;
        signals.Input -= OnInput;
    }

    private void OnInput(Vector2 input)
    {
        signals.EmitSignal(Signals.SignalName.PlayerInput, input);
        nextState = TitleState.StateName;
    }
}
