using Godot;
using System;

public partial class TileMapGenerator : TileMapLayer
{
    [Export]
    public PackedScene[] items;

    public override void _Ready()
    {
        foreach (Vector2I cell in GetUsedCells())
        {
            if (GetCellSourceId(cell) != 0)
            {
                Vector2I atlasCord = GetCellAtlasCoords(cell);
                Node node = items[GetCellSourceId(cell) - 1].Instantiate<Node>();
                AddChild(node);
                EraseCell(cell);
            }
        }
    }

}