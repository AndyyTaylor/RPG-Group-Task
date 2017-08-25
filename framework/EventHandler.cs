using System;
using System.Windows.Forms;

public class EventHandler {
    Player player;
    
    bool aPressed, dPressed, sPressed, wPressed;
    
    public EventHandler(Form mainForm, Player _player) {
        player = _player;
        
        mainForm.KeyPreview = true;
        mainForm.KeyDown += new KeyEventHandler(keyDown);
        mainForm.KeyUp += new KeyEventHandler(keyUp);
    }
    
    public void keyDown(object sender, KeyEventArgs e) {
        e.Handled = true;
        
        switch (e.KeyCode) {
            case (Keys.A):
                if (!aPressed) player.toggleMoveLeft();
                aPressed = true;
                break;
            case (Keys.D):
                if (!dPressed) player.toggleMoveRight();
                dPressed = true;
                break;
            case (Keys.S):
                if (!sPressed) player.toggleMoveDown();
                sPressed = true;
                break;
            case (Keys.W):
                if (!wPressed) player.toggleMoveUp();
                wPressed = true;
                break;
            case (Keys.Space):
                player.shoot();
                break;
            default:
                e.Handled = false;
                break;
        }
    }
    
    public void keyUp(object sender, KeyEventArgs e) {
        e.Handled = true;
        
        switch (e.KeyCode) {
            case (Keys.A):
                aPressed = false;
                player.toggleMoveLeft();
                break;
            case (Keys.D):
                dPressed = false;
                player.toggleMoveRight();
                break;
            case (Keys.S):
                sPressed = false;
                player.toggleMoveDown();
                break;
            case (Keys.W):
                wPressed = false;
                player.toggleMoveUp();
                break;
            default:
                e.Handled = false;
                break;
        }
    }
}
