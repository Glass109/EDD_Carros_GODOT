using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public partial class CarManager : Node2D
{
	[Export]
	int NumeroDeAutos = 10;
	Queue<Node> fila = new Queue<Node>();
	Timer timer;
	Random rnd;
	PackedScene CarScene;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer = GetNode<Timer>("Tempo");
		CarScene = (PackedScene) ResourceLoader.Load("res://Nodes/Car.tscn");
		rnd = new Random();
		LlenarFila();
		timer.Timeout += OnTempoTick;
		// GD.Print(fila.ToArray());

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	void LlenarFila(){
		for (int i = 0; i < NumeroDeAutos; i++)
		{
			fila.Enqueue(CarScene.Instantiate());
			// GD.Print(i);
		}
	}
	void OnTempoTick(){
		AddChild(fila.Dequeue());
		if(fila.Count <= 0) LlenarFila();
	}
	
}
