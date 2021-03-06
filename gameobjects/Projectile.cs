using System;
using System.Drawing;
using System.Collections.Generic;

public class Projectile : GameObject {
    public int dx, dy;
    public bool playerTeam;
    int tick;
    
    public Projectile(int _x, int _y, int _w, int _h, int _dx, int _dy, int pierc, bool _playerTeam) : base(_x, _y, _w, _h) {
        dx = _dx;
        dy = _dy;
        playerTeam = _playerTeam;
        health = pierc;
        tick = 0;
    }
    public void update(Player player, List<Enemy> enemies, float elapsed) {
        if (tick++ > 300) {
            health = -1;
        }
        x += dx * elapsed;
        y += dy * elapsed;
        
        if (playerTeam) {
            for (int i = 0; i < enemies.Count; i++) {
                if (enemies[i].containsPoint(x, y)) {
                    health -= enemies[i].health;
                    enemies[i].takeDamage(1);
                }
            }
        } else {
            if (player.containsPoint(x, y)) {
                health -= 1;
                player.takeDamage(1);
            }
        }
        
    }

    public override void render(List<RenderObject> renderQueue) {
          renderQueue.Add(new RenderRect((int) x, (int) y, w, h, Color.Red));
    }
}
