using Godot;
using System;
using System.Diagnostics;

public partial class Player : RigidBody2D
{
	[Export]
	public PackedScene grassParticle;
	[Export]
	public float jumpForce;
	Area2D area2D;
	int swingDirection = 1;
    public override void _Ready()
    {
        base._Ready();
		area2D=GetNode<Area2D>("Area2D");
    }

	public void _on_area_2d_body_entered(Node body)
    {
		PackedScene particleScene;
		if (body.GetType().IsAssignableTo(typeof(PlatformBase))) particleScene=((PlatformBase)body).particle;
		else particleScene = grassParticle;
		GpuParticles2D particle = particleScene.Instantiate<GpuParticles2D>();
		AddSibling(particle);
		particle.GlobalPosition = area2D.GlobalPosition;
    }


    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(double delta)
	{
		Rotate((float)delta * swingDirection);
		if (Input.IsActionJustPressed("ChangeRotation"))
		{
			swingDirection = swingDirection * -1;
		}
		if (Input.IsActionJustPressed("Jump") && area2D.GetOverlappingBodies().Count > 1)
		{
			GD.Print("jumping");
			ApplyForce(-Transform.Y * jumpForce);
		}
		if (Math.Abs(RotationDegrees % 360) > 60)
		{
			swingDirection=swingDirection * -1;//should kill you instead

		}
	}
	bool isOnFloor;
    public override void _IntegrateForces(PhysicsDirectBodyState2D state)
    {
        base._IntegrateForces(state);
		int i = 0;
		isOnFloor = false;
		while (i < state.GetContactCount())
        {
			Vector2 normal=state.GetContactLocalNormal(i);
			if (normal.Dot(Vector2.Up) > 0.8) isOnFloor = true;
			i++;
        }
    }


}