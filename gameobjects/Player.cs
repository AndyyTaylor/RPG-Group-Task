using System;
using System.Drawing;
using System.Collections.Generic;

public class Player : GameObject {
    private bool movingRight, movingLeft, movingUp, movingDown;
    public Player(int _x, int _y, int _w, int _h) : base(_x, _y, _w, _h) {

    }

    public override void update(Map gameMap) {
        int dx = 10, dy = 10;
        if (movingRight) {
            dx = 10;
        }
        if (movingLeft) {
            dx = -10;
        }
        if (movingDown) {
            dy = 10;
        }
        if (movingUp) {
            dy = -10;
        }
    }

    public override void render(List<RenderObject> renderQueue) {
        renderQueue.Add(new RenderRect(x, y, w, h, Color.Red));
    }

    public void toggleMoveRight() {
        if (movingRight) movingRight = false;
        else movingRight = true;
    }

    public void toggleMoveLeft() {
        if (movingLeft) movingLeft = false;
        else movingLeft = true;
    }

    public void toggleMoveUp() {
        if (movingUp) movingUp = false;
        else movingUp = true;
    }

    public void toggleMoveDown() {
        if (movingDown) movingDown = false;
        else movingDown = true;
    }
}
