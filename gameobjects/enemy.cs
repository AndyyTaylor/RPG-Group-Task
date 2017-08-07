using System;
using System.Drawing;
using System.Collections.Generic;

public class Enemy : GameObject {
    public Enemy(int _x, int _y, int _w, int _h) : base(_x, _y, _w, _h) {

    }
    public override void update() {

    }

    public void moveToPlayer() {
      
    }

    public override void render(List<RenderObject> renderQueue) {
          renderQueue.Add(new RenderRect(x, y, w, h, Color.Black));
    }
}
