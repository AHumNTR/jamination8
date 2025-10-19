using Godot;
using System;
using System.Diagnostics;

public partial class BreakingBlock : PlatformBase
{
	// Called when the node enters the scene tree for the first time.
	[Export]
	public Texture2D[] textures;
	Sprite2D sprite;
	CollisionShape2D col;
	Timer timer;
	AudioStreamPlayer2D breakSound;
	int stage=0;
	public override void _Ready()
    {
		BodyEntered += bodyEnter;
		sprite = GetNode<Sprite2D>("Sprite2D");
		col = GetNode<CollisionShape2D>("CollisionShape2D");
		timer = GetNode<Timer>("Timer");
		timer.Timeout += timeout;
		breakSound=GetNode<AudioStreamPlayer2D>("BreakingSound");
    }
	public void timeout()
	{
		GD.Print(stage);
		if (GetCollidingBodies().Count > 0)
		{
			if (stage < 2)
			{
				timer.Start();
			}
			else
			{
				col.Disabled = true;
				sprite.Visible = false;
				breakSound.Play();
			}
		}
		else
		{
			sprite.Visible = true;
			col.Disabled = false;
			stage = 0;
		}
		sprite.Texture = textures[stage];
		stage++;
    }
	public void bodyEnter(Node body)
    {
		if (timer.TimeLeft == 0) 
		timer.Start();			
    }
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	
}
