using System;
using System.Windows.Forms;

public class EventHandler {
    public EventHandler(Form mainForm) {
        mainForm.KeyPreview = true;
        
        mainForm.KeyPress += new KeyPressEventHandler(checkEvent);
    }
    
    public void checkEvent(object sender, KeyPressEventArgs e) {
        e.Handled = true;
        
        switch (Char.ToUpper(e.KeyChar)) {
            case ((char) Keys.A):
                System.Console.WriteLine("a pressed");
                break;
            default:
                e.Handled = false;
                break;
        }
    }
}
