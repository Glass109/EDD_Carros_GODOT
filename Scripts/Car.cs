using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Car : RigidBody2D
{
	Dictionary<string, Color> paletaColores = new Dictionary<string, Godot.Color>{
		{"ROJO", Color.FromHtml("cc0000")},
		{"NARANJA", Color.FromHtml("cc7a00")},
		{"PASTO", Color.FromHtml("a3cc00")},
		{"AZUL", Color.FromHtml("1f00cc")},
		{"TURQUESA", Color.FromHtml("00d933")},
		{"CYAN", Color.FromHtml("00cccc")},
		/* SOLO ESTOS 6 SE USAN POR AHORA*/
		{"MOSTAZA", Color.FromHtml("dccc00")},
		{"MORADO", Color.FromHtml("cc0085")},
		{"BLANCO", Color.FromHtml("FFFFFF")}
	};
	Vector2 aceleracionConstante;
	Color ColorNecesario;
	Label etiqueta;
	Area2D area;
	int idxColor;
	SignalBus sb;
	UI UI;

    public override void _Ready()
    {
        sb = GetNode<SignalBus>("/root/SBN");
		area = GetNode<Area2D>("Area");
		UI = GetNode<UI>("/root/Main/UI");
		
		area.AreaEntered += OnAreaEntered;
		etiqueta = GetNode<Label>("Etiqueta");
		etiqueta.Text = paletaColores.ElementAt(idxColor).Key;
		
		aceleracionConstante = new Vector2(-2f - (UI.scoreInt/5f), 0);
    }
    public override void _PhysicsProcess(double delta)
	{

		MoveAndCollide(aceleracionConstante);
	}
	private void OnAreaEntered(Area2D area){
		if (area is Cursor)
		{
			Modulate = area.Modulate;
		}
		
		if(area.Name == "AreaEliminador"){
			QueueFree();
			return;
		}
		if(area.Name == "AreaComprobador"){
			ValidarColor();
		}
	}
	private void ValidarColor(){
		// GD.Print(Modulate.ToHtml() + "..." + paletaColores.ElementAt(idxColor).Value.ToHtml());
		if(Modulate.ToHtml() == paletaColores.ElementAt(idxColor).Value.ToHtml()){	
			sb.EmitSignal(nameof(sb.PointUp));
			// GD.Print("PUNTO");
		}else{
			sb.EmitSignal(nameof(sb.Strike));
			// GD.Print("STRIKE");
		}
	}
	public Car(){
		Random rnd = new Random();
		idxColor = rnd.Next(6);
		Modulate = paletaColores["BLANCO"];
		ColorNecesario = paletaColores.ElementAt(idxColor).Value;
	}
}
