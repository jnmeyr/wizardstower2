using Godot;
using System.Linq;
using System;

public partial class RandomDirectionProvider : AbstractDirectionProvider
{

    private DirectionChecker directionChecker;
    private Random random = new Random();

    public override void _Ready()
    {
        directionChecker = GetNode<DirectionChecker>("DirectionChecker");
    }

    public override Vector2 GetNextDirection(Vector2 currentDirection)
    {
        Vector2[] nextDirections = directions.Where(nextDirection =>
            nextDirection != -currentDirection && directionChecker.IsFree(nextDirection)
        ).ToArray();

        if (nextDirections.IsEmpty())
        {
            return -currentDirection;
        }

        return nextDirections.ElementAt(random.Next(nextDirections.Count()));
    }

    private static readonly Vector2[] directions = new Vector2[] { Vector2.Left, Vector2.Right, Vector2.Up, Vector2.Down };
}
