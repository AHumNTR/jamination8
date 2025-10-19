using Godot;
using System;
using System.Numerics;

public partial class TileMapGenerator : TileMapLayer
{
    [Export]
    public PackedScene[] items;

    public override void _Ready()
	{
        foreach (Vector2I cell in GetUsedCells())
        {
            if (GetCellSourceId(cell) == 1)
            {
                Vector2I atlasCord = GetCellAtlasCoords(cell);
				GD.Print(atlasCord.Y);
                Node2D node = items[atlasCord.Y].Instantiate<Node2D>();
                AddChild(node);
                node.Position = MapToLocal(cell) - new  Vector2I(140,20);
				if (atlasCord.Y == 3) ((MovingPlatform)node).startingX = node.Position.X;
                EraseCell(cell);
            }
        }
    }

}