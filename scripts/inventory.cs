using Godot;

public partial class inventory : Control {
	player player;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		Panel panel = GetNode<Panel>("Panel"); panel.Visible = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		if(player.isInventoryOpen == false) {
			OpenInventory(); 
		}
		else {
			CloseInventory();
		}
	}

	public void OpenInventory() {
		player.isInventoryOpen = true;
		Panel panel = GetNode<Panel>("Panel");
		panel.Visible = true;
	}
	public void CloseInventory() {
		player.isInventoryOpen = false;
		Panel panel = GetNode<Panel>("Panel");
		panel.Visible = false;
	}
}
