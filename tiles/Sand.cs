using System;
using System.Drawing;

public class Sand : Tile {
    public Sand(int _x, int _y, int _w, int _h) : base(_x, _y, _w, _h) {
        walkable = true;
    }

    public override RenderObject getRenderObject() {
        return new RenderRect(x, y, w, h, Color.Yellow);
    }
}
