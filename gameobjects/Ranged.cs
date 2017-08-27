using System;
using System.Drawing;
using System.Collections.Generic;

public class Ranged : Enemy {
    int tick = 0;
    
    public Ranged(int _x, int _y, int _w, int _h) : base(_x, _y, _w, _h) {
        health = 2;
    }

    public override void update(Player player, List<Projectile> projectiles) {
        tick++;
        int dx = 0;
        int dy = 0;
        if (player.getX() < x) dx -= 2;
        else if (player.getX() > x) dx += 2;

        if (player.getY() < y) dy -= 2;
        else if (player.getY() > y) dy += 2;

        if (Math.Sqrt(Math.Pow(x-player.getX(), 2) + Math.Pow(y-player.getY(), 2)) < Map.SCALE * 10) {
            dx *= -1;
            dy *= -1;
        }
        
        if (tick > 50) {
            tick = 0;
            double theta = Math.Atan2(y - player.getY(), x - player.getX());
            projectiles.Add(new Projectile(x + w/2, y + h/2, 5, 5, (int) -(Math.Cos(theta)*5), (int) -(Math.Sin(theta)*5), 1, false));
        }
        
        x += dx;
        y += dy;
    }

    public override void render(List<RenderObject> renderQueue) {
        if (isDead()) return;
        renderQueue.Add(new RenderRect(x, y, w, h, Color.Blue));
    }
}
