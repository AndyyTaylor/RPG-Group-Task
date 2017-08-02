using System;
using System.Drawing;

public class Water : Tile {
    public Water(int _x, int _y, int _w, int _h, bool walkable) : base(_x, _y, _w, _h) {
      walkable = False;
    }

    public override RenderObject getRenderObject() {
        return new RenderRect(x, y, w, h, Color.Orange);
    }
}