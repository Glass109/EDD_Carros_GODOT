 using Godot;
using System;

public partial class UI : Control
{
	SignalBus sb;
	Label scoreLabel, strikeLabel;
	public int scoreInt, strikesInt;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		sb = GetNode<SignalBus>("/root/SBN");
		scoreLabel = GetNode<Label>("Puntuacion");
		strikeLabel = GetNode<Label>("Strikes");

		sb.PointUp += OnPointsUp;
		sb.Strike += OnStrike;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	void OnPointsUp(){
		scoreLabel.Text = "PUNTOS: " + ++scoreInt;

	}
	void OnStrike(){
		strikeLabel.Text = "STRIKES: " + ++strikesInt;
		if(strikesInt > 2){
			GetTree().Paused = true;
		}
	}
}


