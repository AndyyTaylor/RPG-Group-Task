using System;
using System.Drawing;
using System.Collections.Generic;

public class Enemy : GameObject {
    public Enemy(int _x, int _y, int _w, int _h) : base(_x, _y, _w, _h) {

    }
    public override void update(Map gameMap) {

    }

    public void moveToPlayer(Player player) {
      //if (Math.Abs(Player.GetX()- x))
      if (player.getX() < x) x -= 2;
      else if (player.getX() > x) x += 2;

      if (player.getY() < y) y -= 2;
      else if (player.getY() > y) y += 2;

      if (Math.Sqrt((player.getX() + w/2) - (x + w/2))*((player.getX() + w/2)- (x + w/2))+((player.getY() + h/2)- (y + h/2))*((player.getY() + h/2 ) - (y + h/2)) < 200) {
        player.health -= 1;
        Console.WriteLine(player.health);
      }



    }

    public override void render(List<RenderObject> renderQueue) {
          renderQueue.Add(new RenderRect(x, y, w, h, Color.Black));
    }
}
