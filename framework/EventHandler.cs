using System;
using System.Windows.Forms;

public class EventHandler {
    Player player;
    
    public EventHandler(Form mainForm, Player _player) {
        player = _player;
        
        mainForm.KeyPreview = true;
        mainForm.KeyPress += new KeyPressEventHandler(checkEvent);
    }
    
    public void checkEvent(object sender, KeyPressEventArgs e) {
        e.Handled = true;
        switch (Char.ToUpper(e.KeyChar)) {
            case ((char) Keys.A):
                player.moveX(-30);     // TODO: move by booleans, key down / key up
                break;
            case ((char) Keys.D):
                player.moveX(30);
                break;
            default:
                e.Handled = false;
                break;
        }
    }
}
