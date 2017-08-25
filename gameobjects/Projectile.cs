using System;
using System.Drawing;
using System.Collections.Generic;

public class Projectile : GameObject {
    public int dx, dy;
    public Projectile(int _x, int _y, int _w, int _h, int _dx, int _dy) : base(_x, _y, _w, _h) {
        dx = _dx;
        dy = _dy;
    }
    public void update(Player player, List<Enemy> enemies) {
        x += dx;
        y += dy;
        
        for (int i = 0; i < enemies.Count; i++) {
            if (enemies[i].containsPoint(x, y)) {
                enemies[i].takeDamage(10);
            }
        }
    }

    public override void render(List<RenderObject> renderQueue) {
          renderQueue.Add(new RenderRect(x, y, w, h, Color.Red));
    }
}
