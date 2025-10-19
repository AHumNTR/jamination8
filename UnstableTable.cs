using Godot;
using System;

public partial class UnstableTable : RigidBody2D
{
	// Called when the node enters the scene tree for the first time.
	AnimationPlayer ap;
	public override void _Ready()
    {
		BodyEntered += playerEntered;
		ap = GetNode<AnimationPlayer>("/root/Node2D/AnimationPlayer");
    }

    private void playerEntered(Node body)
    {
        if (body.Name == "Player"&&!ap.IsPlaying())
        {
			    ap.Play("fallingDown");
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
}
