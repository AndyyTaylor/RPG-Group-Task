using System;
using System.Drawing;

public abstract class Tile {
    protected int x, y, w, h;

    // Is that right?
    protected bool walkable;
    //^^^^^^^^^^^^^^^^^^^

    public Tile(int _x, int _y, int _w, int _h) {
        x = _x;
        y = _y;
        w = _w;
        h = _h;
    }

    public abstract RenderObject getRenderObject();
}
