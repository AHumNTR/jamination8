using Godot;
using System;

public partial class MovingPlatform : PlatformBase
{
	[Export]
	public int range;
	[Export]
	public float speed;
	public float startingX;
	int direction=1;
	// Called when the node enters the scene tree for the first time.

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
    {
		Position += new Vector2((float)delta * direction * speed,0);
		if (Math.Abs(Position.X - startingX) > range)
		{
			Position=new Vector2(startingX+direction*range,Position.Y);
			direction = -direction;
		}
    }
}
