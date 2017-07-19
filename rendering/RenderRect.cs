using System;
using System.Drawing;
using System.Windows.Forms;

public class RenderRect : RenderObject {
    private int w, h;
    
    public RenderRect(int _x, int _y, int _w, int _h, Color _color)
    : base(_x, _y, _color) {
        w = _w;
        h = _h;
    }
    
    public override void render(PaintEventArgs e) {
        e.Graphics.FillRectangle(new SolidBrush(color), x, y, w, h);
    }
}