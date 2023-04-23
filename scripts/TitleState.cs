
using Godot;

public partial class TitleState : AbstractState
{

    public const string StateName = "Title";

    private Signals signals;
    private Game game;

    private Sprite2D titleImage;

    public override void _Ready()
    {
        signals = GetNode<Signals>($"/root/{Signals.NAME}");
        game = (Game)(GetParent().GetParent());
        titleImage = game.GetNode<Sprite2D>("TitleImage");
    }

    public override void EnterState()
    {
        titleImage.Visible = true;
        signals.Input += OnInput;
    }

    public override void LeaveState()
    {
        titleImage.Visible = false;
        signals.Input -= OnInput;
    }

    private void OnInput(Vector2 input)
    {
        signals.EmitSignal(Signals.SignalName.PlayerInput, input);
        nextState = LevelState.StateName;
    }
}
