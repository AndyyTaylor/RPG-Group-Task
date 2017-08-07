using System;
using System.Drawing;
using System.Collections.Generic;

public class Enemy : GameObject {
    public Enemy(int _x, int _y, int _w, int _h) : base(_x, _y, _w, _h) {

    }
    public override void update() {

    }

    public void moveToPlayer(Player player) {
      //if (Math.Abs(Player.GetX()- x))
      if (player.GetX() < x) x -= 2;
      else if (player.GetX() > x) x += 2;

      if (player.GetY() < y) y -= 2;
      else if (player.GetY() > y) y += 2;

      if (Math.Sqrt((player.GetX() + w/2) - (x + w/2))*((player.GetX() + w/2)- (x + w/2))+((player.GetY() + h/2)- (y + h/2))*((player.GetY() + h/2 ) - (y + h/2)) < 200) {
        player.health -= 1;
        Console.WriteLine(player.health);
      }



    }

    public override void render(List<RenderObject> renderQueue) {
          renderQueue.Add(new RenderRect(x, y, w, h, Color.Black));
    }
}
