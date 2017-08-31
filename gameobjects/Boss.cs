using System;
using System.Drawing;
using System.Collections.Generic;

public class Boss : Enemy {
    public Boss(int _x, int _y, int _w, int _h) : base(_x, _y, _w, _h) {
        health = 100;
        reward = 50;
    }

    public virtual void update(Player player, List<Projectile> projectiles, float elapsed) {
      if (player.getX() < x) x -= 2 * elapsed;
      else if (player.getX() > x) x += 2 * elapsed;

      if (player.getY() < y) y -= 2 * elapsed;
      else if (player.getY() > y) y += 2 * elapsed;

      if (Math.Sqrt((player.getX() + w/2) - (x + w/2))*((player.getX() + w/2)- (x + w/2))+((player.getY() + h/2)- (y + h/2))*((player.getY() + h/2 ) - (y + h/2)) < 200) {
        player.health -= 1;
        Console.WriteLine(player.health);
      }



    }

    public override void render(List<RenderObject> renderQueue) {
        if (isDead()) return;
        renderQueue.Add(new RenderRect((int) x, (int) y, w, h, Color.Red));
    }
}
