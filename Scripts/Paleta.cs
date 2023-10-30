using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Paleta : Control
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
	};

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Godot.Collections.Array<Node> a = GetChildren();
		int i = 0;
		foreach (Control item in a)
		{
			
			item.Modulate = paletaColores.ElementAt(i++).Value;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
