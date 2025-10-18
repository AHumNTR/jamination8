using Godot;
using System;

public partial class MainMenuButton : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Pressed += buttonPressed;

	}
	public void buttonPressed()
    {
		GetTree().ChangeSceneToFile("res://mainscene.tscn");
  
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
}
