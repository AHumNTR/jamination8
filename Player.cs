using Godot;
using System;

public partial class Player : RigidBody2D
{
	[Export]
	public float jumpForce;

	int swingDirection = 1;

	[Export] private PlayerRaycast playerRaycast;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		Rotate((float)delta * swingDirection);
		if (Input.IsActionJustPressed("ChangeRotation"))
		{
			swingDirection = swingDirection * -1;
		}
		if (Input.IsActionJustPressed("Jump") && playerRaycast.IsColliding())
		{
			ApplyForce(-Transform.Y * jumpForce);
		}
		if (Math.Abs(RotationDegrees % 360) > 60)
		{
			GD.Print("ov");
		}
	}

}
