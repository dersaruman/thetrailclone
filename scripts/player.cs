using Godot;

public partial class player : CharacterBody3D {
	inventory inv;
	float moveSpd = 14.0f;
	float mouseSen = 0.5f;
	public bool isInventoryOpen = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		isInventoryOpen = false;
		Input.MouseMode = Input.MouseModeEnum.Captured;
	}

	private float mouseDeltaX = 0.0f;
	private float mouseDeltaY = 0.0f;

	public override void _Input(InputEvent @event) {
		if (@event is InputEventMouseMotion mouseEvent && !isInventoryOpen) {
			mouseDeltaX = mouseEvent.Relative.X;
			mouseDeltaY = mouseEvent.Relative.Y;
		}
		if(Input.IsActionJustPressed("triggerInv")) {
			if(isInventoryOpen == false) {
				inv.OpenInventory();
				isInventoryOpen = true;
			}
			else {
				inv.CloseInventory();
				isInventoryOpen = false;
			}
		}
	}

	public override void _PhysicsProcess(double delta) {
		RotateY(Mathf.DegToRad(-mouseDeltaX * mouseSen));
		Node3D head = GetNode<Node3D>("head");
		head.RotateX(Mathf.DegToRad(-mouseDeltaY * mouseSen));
		var rotation = head.Rotation;
		rotation.X = Mathf.Clamp(head.Rotation.X, Mathf.DegToRad(-80), Mathf.DegToRad(80));
		head.Rotation = rotation;

		mouseDeltaX = 0.0f;
		mouseDeltaY = 0.0f;
	}
}
