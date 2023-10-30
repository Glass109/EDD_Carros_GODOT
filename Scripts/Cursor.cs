using Godot;
using System;

public partial class Cursor : Area2D
{
		SignalBus sb;
		TextureRect rectText;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		sb = GetNode<SignalBus>("/root/SBN");
		sb.ColorBoxClicked += OnChangeColor;
		rectText = GetNode<TextureRect>("Cursor");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position = GetViewport().GetMousePosition();
		Position -= new Vector2(rectText.Size.X,(rectText.Size.Y)/2);	
	}

	public void OnChangeColor(){
		Image img = GetViewport().GetTexture().GetImage();
		Vector2 pos = GetViewport().GetMousePosition();
		Modulate =  img.GetPixel((int) pos.X, (int) pos.Y);

	}

}
