using System;
using System.Drawing;
using System.Windows.Forms;

public abstract class RenderObject {
    protected int x, y;
    protected Color color;
    
    protected RenderObject(int _x, int _y, Color _color) {
        x = _x;
        y = _y;
        color = _color;
    }
    
    public abstract void render(PaintEventArgs e);
}