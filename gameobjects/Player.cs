using System;
using System.Drawing;
using System.Collections.Generic;

public class Player : GameObject {
    private bool movingRight, movingLeft, movingUp, movingDown;
    public Player(int _x, int _y, int _w, int _h) : base(_x, _y, _w, _h) {

    }

    public override void update(Map gameMap) {
        int dx = 0, dy = 0;
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
        
        x += dx;
        y += dy;
        
        List<Tile> tilesUnder = gameMap.tileAtPos(this);
        bool walkable = false;
        float speed = 1;
        foreach (Tile tile in tilesUnder) {
            walkable = tile.walkable || walkable;
            speed = Math.Min(tile.speed, speed);
        }
        
        if (!walkable) {
            x -= dx;
            y -= dy;
        } else if (speed < 1) {
            x -= dx;
            y -= dy;
            
            x += (int) (dx * speed);
            y += (int) (dy * speed);
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
