using Godot;
using System;

public partial class KillParticle : GpuParticles2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Emitting = true;
		Finished += finished;
    }

    private void finished()
    {
		GD.Print("finished");
		QueueFree();
    }

}
