using System;
using System.Windows.Forms;

public class EventHandler {
    public Player player;
    
    bool aPressed, dPressed, sPressed, wPressed;
    MainForm mainForm;
    
    public EventHandler(MainForm _mainForm, Player _player) {
        player = _player;
        mainForm = _mainForm;
        
        mainForm.KeyPreview = true;
        mainForm.KeyDown += new KeyEventHandler(keyDown);
        mainForm.KeyUp += new KeyEventHandler(keyUp);
    }
    
    public void keyDown(object sender, KeyEventArgs e) {
        e.Handled = true;
        
        switch (e.KeyCode) {
            case (Keys.Left):
                if (!aPressed) player.toggleMoveLeft();
                aPressed = true;
                break;
            case (Keys.Right):
                if (!dPressed) player.toggleMoveRight();
                dPressed = true;
                break;
            case (Keys.Down):
                if (!sPressed) player.toggleMoveDown();
                sPressed = true;
                break;
            case (Keys.Up):
                if (!wPressed) player.toggleMoveUp();
                wPressed = true;
                break;
            case (Keys.Space):
                player.shoot();
                break;
            case (Keys.R):
                mainForm.reset = true;
                break;
            default:
                e.Handled = false;
                break;
        }
    }
    
    public void keyUp(object sender, KeyEventArgs e) {
        e.Handled = true;
        
        switch (e.KeyCode) {
            case (Keys.Left):
                aPressed = false;
                player.toggleMoveLeft();
                break;
            case (Keys.Right):
                dPressed = false;
                player.toggleMoveRight();
                break;
            case (Keys.Down):
                sPressed = false;
                player.toggleMoveDown();
                break;
            case (Keys.Up):
                wPressed = false;
                player.toggleMoveUp();
                break;
            default:
                e.Handled = false;
                break;
        }
    }
}
