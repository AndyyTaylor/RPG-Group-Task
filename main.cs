using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

public class MainClass {    // OOP ftw

    // Forms
    MainForm mainForm;
    EventHandler eventHandler;
    Map gameMap;
    Player player;
    List<Enemy> enemies;
    List<Projectile> projectiles;
    static Stopwatch stopWatch;
    Random rnd;

    bool closed = false;
    int tick = 0;

    public MainClass() {
        mainForm = new MainForm(this);
        gameMap = new Map();
        rnd = new Random();
        enemies = new List<Enemy>();
        projectiles = new List<Projectile>();
        
        player = new Player(Map.SCALE * Map.WIDTH, Map.SCALE * Map.HEIGHT, Map.SCALE, Map.SCALE);

        eventHandler = new EventHandler(mainForm, player);
    }

    public void update() {  /* Performs code logic */
        tick++;
        gameMap.update(player);
        player.update(gameMap, projectiles);
        foreach(Enemy enemy in enemies) { enemy.update(player, projectiles); }
        foreach(Projectile proj in projectiles) { proj.update(player, enemies); }
        
        enemies = enemies.Where(e => !e.isDead()).ToList();
        projectiles = projectiles.Where(p => !p.isDead()).ToList();
        
        if (tick % 400 == 0) {
            int num_enemies = (tick / 200) * 2;
            int num_ranged = 1;
            int num_bosses = 0;
            while (num_enemies - 20 > 3) {
                num_ranged += 1;
                num_enemies -= 3;
            }
            while (num_ranged - 10 > 5) {
                num_ranged -= 5;
                num_bosses += 1;
            }
            
            for (int i = 0; i < num_enemies; i++) { enemies.Add(new Enemy(rnd.Next(0, Map.WIDTH * Map.SCALE), rnd.Next(0, Map.HEIGHT * Map.SCALE), Map.SCALE, Map.SCALE)); }
            for (int i = 0; i < num_ranged; i++) { enemies.Add(new Ranged(rnd.Next(0, Map.WIDTH * Map.SCALE), rnd.Next(0, Map.HEIGHT * Map.SCALE), Map.SCALE, Map.SCALE)); }
            for (int i = 0; i < num_enemies; i++) { enemies.Add(new Enemy(rnd.Next(0, Map.WIDTH * Map.SCALE), rnd.Next(0, Map.HEIGHT * Map.SCALE), Map.SCALE, Map.SCALE)); }
            
            System.Console.WriteLine(num_ranged.ToString() + " spawned");
        }
        
        mainForm.Invalidate();
    }

    public void render() {  /* Adds all rendering to mainForm.renderQueue */
        mainForm.clearQueue();
        mainForm.setOffsets(gameMap.getXOff(), gameMap.getYOff());
        gameMap.render(mainForm.getRenderQueue());
        player.render(mainForm.getRenderQueue());
        foreach(Enemy enemy in enemies) { enemy.render(mainForm.getRenderQueue()); }
        foreach(Projectile proj in projectiles) { proj.render(mainForm.getRenderQueue()); }
    }

    public void exit(Object sender, FormClosingEventArgs e) {  /* When window is closed */
        closed = true;
    }

    public bool checkClosed() {
        return closed;
    }

    public static void Main () {  /* Main game loop */
        MainClass mainClass = new MainClass();
        stopWatch = new Stopwatch();

        while (!mainClass.checkClosed()) {
            stopWatch.Start();
            mainClass.update();
            mainClass.render();

            Application.DoEvents();
            // System.Console.WriteLine(stopWatch.Elapsed);
            stopWatch.Restart();
        }

        System.Console.WriteLine("Exiting...");
        Application.Exit();
    }
}
