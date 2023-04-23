using Godot;
using System.Linq;

public partial class LevelState : AbstractState
{

    public const string StateName = "Level";

    private Signals signals;
    private Game game;

    private AudioStreamPlayer music;
    private AudioStreamPlayer goldSound;
    private AudioStreamPlayer doorSound;

    private const double MaxTime = 0.2d;

    private double currentTime;

    public override void _Ready()
    {
        signals = GetNode<Signals>($"/root/{Signals.NAME}");
        game = (Game)(GetParent().GetParent());
        music = game.GetNode<AudioStreamPlayer>("Music");
        goldSound = game.GetNode<AudioStreamPlayer>("GoldSound");
        doorSound = game.GetNode<AudioStreamPlayer>("DoorSound");
    }

    public override void __Process(double deltaTime)
    {
        currentTime += deltaTime;
        if (currentTime >= MaxTime)
        {
            currentTime %= MaxTime;
            signals.EmitSignal(Signals.SignalName.Update);
        }
        signals.EmitSignal(Signals.SignalName.Refresh, currentTime / MaxTime);
    }

    public override void EnterState()
    {
        signals.Input += OnInput;
        signals.CollectedGold += OnCollectedGold;
        signals.Killed += OnKilled;
        signals.UsedStairs += OnUsedStairs;
        signals.UsedWindow += OnUsedWindow;
        if (!music.Playing) music.Play();
    }

    public override void LeaveState()
    {
        signals.Input -= OnInput;
        signals.CollectedGold -= OnCollectedGold;
        signals.Killed -= OnKilled;
        signals.UsedStairs -= OnUsedStairs;
        signals.UsedWindow -= OnUsedWindow;
        music.Stop();
    }

    private void OnTicked()
    {
        signals.EmitSignal(Signals.SignalName.Update);
    }

    private void OnNotTicked(double fraction)
    {
        signals.EmitSignal(Signals.SignalName.Refresh, fraction);
    }

    private void OnInput(Vector2 input)
    {
        signals.EmitSignal(Signals.SignalName.PlayerInput, input);
    }

    private void OnCollectedGold()
    {
        goldSound.Play();
        if (GetTree()
            .GetNodesInGroup("gold")
            .Where(node => !node.IsQueuedForDeletion())
            .Count() == 0)
        {
            doorSound.Play();
            signals.EmitSignal(Signals.SignalName.CollectedAllGold);
        }
    }

    private void OnKilled()
    {
        nextState = FailureState.StateName;
    }

    private void OnUsedStairs(int nextLevel)
    {
        game.CallDeferred("ReplaceLevel", nextLevel);
    }

    private void OnUsedWindow()
    {
        nextState = SuccessState.StateName;
    }
}
