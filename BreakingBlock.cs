using Godot;
using System;

public partial class BreakingBlock : RigidBody2D
{
	// Called when the node enters the scene tree for the first time.
	Sprite2D sprite;
	CollisionObject2D col;
	public override void _Ready()
    {
		BodyEntered += bodyEnter;
		sprite = GetNode<Sprite2D>("Sprite2D");
		col = GetNode<CollisionObject2D>("CollisionObject2D");
    }

public void bodyEnter(Node body)
    {
		
    }
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
}
