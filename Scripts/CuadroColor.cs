using Godot;
using System;

public partial class CuadroColor : Control
{
	SignalBus sb;
	Area2D area;
	bool selected;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		sb = GetNode<SignalBus>("/root/SBN");
		area = GetNode<Area2D>("Area2D");
		area.AreaEntered += (area) => { selected = true; };
		area.AreaExited += (area) => { selected = false; };

		
	}
    public override void _Input(InputEvent @event)
    {
        if(@event is InputEventMouseButton && selected){
			sb.EmitSignal("ColorBoxClicked");
		}
    }
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
