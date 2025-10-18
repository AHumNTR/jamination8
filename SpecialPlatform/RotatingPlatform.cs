using Godot;
using System;

public partial class RotatingPlatform : Sprite2D
{
	// Called when the node enters the scene tree for the first time.
	[Export]
	public float range;
	[Export]
	public float speed;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
    {
		Rotate(speed);
		if (Math.Abs(RotationDegrees) > range) speed = -speed;
    }
}
