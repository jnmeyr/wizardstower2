using Godot;

public partial class Game : Node
{

    [Export]
    private PackedScene level1;

    [Export]
    private PackedScene level2;

    [Export]
    private PackedScene level3;


    public override void _Ready()
    {
        AddLevel(1);
    }

    public void ReplaceLevel(int nextLevel)
    {
        RemoveLevel();
        AddLevel(nextLevel);
    }

    private void RemoveLevel()
    {
        Node node = GetNode("Level");
        if (node != null)
        {
            node.QueueFree();
            RemoveChild(node);
        }
    }

    private void AddLevel(int nextLevel)
    {
        PackedScene levelScene =
            nextLevel == 1 ? level1 :
            nextLevel == 2 ? level2 :
            nextLevel == 3 ? level3 :
            null;
        Node levelNode = levelScene.Instantiate();
        levelNode.Name = "Level";
        AddChild(levelNode);
    }
}
