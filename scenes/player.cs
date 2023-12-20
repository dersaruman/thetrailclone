using Godot;
using System;

public partial class player : RigidBody3D {
	float mouseSen = 0.01f;
	float twistInput = 0.0f;
	float pitchInput = 0.0f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		Input.MouseMode = Input.MouseModeEnum.Visible;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		if (Input.IsMouseButtonPressed(MouseButton.Right)) {
			Input.MouseMode = Input.MouseModeEnum.Captured;
		} else {
			Input.MouseMode = Input.MouseModeEnum.Visible;
		}
	}

    public override void _UnhandledInput(InputEvent @event) {
        if(@event is InputEventMouseMotion) {
			if(Input.MouseMode == Input.MouseModeEnum.Captured) {
				InputEventMouseMotion mouseEvent = (InputEventMouseMotion)@event;
			}
		}
    }
}
