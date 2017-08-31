using System;
using System.Drawing;
using System.Collections.Generic;

public abstract class GameObject {
    protected float x, y;
    protected int w, h;
    public int health = 100;

    public GameObject(int _x, int _y, int _w, int _h) {
        x = _x;
        y = _y;
        w = _w;
        h = _h;
    }

    public void update(Map gameMap) {}
    public abstract void render(List<RenderObject> renderQueue);
    public void moveX(int amt) { x += amt; }

    public void moveY(int amt) { y += amt; }
    public virtual void takeDamage(int amt) { health -= amt; }
    
    public bool containsPoint(float px, float py) {
        return px > x && px < x + w && py > y && py < y + h;
    }
    
    public bool isDead() { return health <= 0; }

    public float getX() { return x; }
    public float getY() { return y; }
    public int getW() { return w; }
    public int getH() { return h; }
}
