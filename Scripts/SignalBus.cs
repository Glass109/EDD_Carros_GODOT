using Godot;
using System;

public partial class SignalBus : Node
{
	[Signal]
	public delegate void ColorBoxClickedEventHandler();
	[Signal]
	public delegate void StrikeEventHandler();
	[Signal]
	public delegate void PointUpEventHandler();

}
