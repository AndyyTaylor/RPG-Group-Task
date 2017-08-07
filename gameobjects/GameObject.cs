using System;
using System.Drawing;
using System.Collections.Generic;

public abstract class GameObject {
    protected int x, y, w, h;
    public int health = 100;

    public GameObject(int _x, int _y, int _w, int _h) {
        x = _x;
        y = _y;
        w = _w;
        h = _h;
    }

    public abstract void update();
    public abstract void render(List<RenderObject> renderQueue);
    public void moveX(int amt) { x += amt; }
<<<<<<< HEAD

    public int GetX() {
      return x;
    }

    public int GetY() {
      return y;
    }

=======
    public void moveY(int amt) { y += amt; }
    
    public int getX() { return x; }
    public int getY() { return y; }
>>>>>>> 53248468d816bee878cbd2110506fd98f2a5f126
}
