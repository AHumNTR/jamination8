using Godot;
using System;

public partial class RotatingPlatform : PlatformBase
{
	// Called when the node enters the scene tree for the first time.
	[Export]
	public float rotateBackSpeed = 1f;
	public bool rotateBack;
    public override void _Ready()
    {
        base._Ready();
		BodyExited += bodyExit;
		BodyEntered += bodyEnter;
    }
	public void bodyEnter(Node body)
	{
		if (GetCollidingBodies().Count == 1) rotateBack = false;
    }
	public void bodyExit(Node body)
	{
		if (GetCollidingBodies().Count == 1) rotateBack = true;
    }
    public override void _PhysicsProcess(double delta)
    {
			if(rotateBack)AngularVelocity= -Rotation*(float)delta*rotateBackSpeed;
  //      base._PhysicsProcess(delta);
    }


	// Called every frame. 'delta' is the elapsed time since the previous frame.
    
}
