using System;
using System.Drawing;

public class Water : Tile {
    public Water(int _x, int _y, int _w, int _h) : base(_x, _y, _w, _h) {
        walkable = false;
    }

    public override RenderObject getRenderObject() {
        return new RenderRect(x, y, w, h, Color.Blue);
    }
}
