using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;

public class MainClass {    // OOP ftw

    // Forms
    MainForm mainForm;
    EventHandler eventHandler;
    Map gameMap;
    Player player;
    List<Enemy> enemies;
    List<Projectile> projectiles;
    static Stopwatch stopWatch;

    bool closed = false;

    public MainClass() {
        mainForm = new MainForm(this);
        gameMap = new Map();
        enemies = new List<Enemy>();
        projectiles = new List<Projectile>();
        
        player = new Player(Map.SCALE * Map.WIDTH, Map.SCALE * Map.HEIGHT, Map.SCALE, Map.SCALE);
        enemies.Add(new Enemy(50, 400, Map.SCALE, Map.SCALE));

        eventHandler = new EventHandler(mainForm, player);
    }

    public void update() {  /* Performs code logic */
        gameMap.update(player);
        player.update(gameMap, projectiles);
        foreach(Enemy enemy in enemies) { enemy.update(player); }
        foreach(Projectile proj in projectiles) { proj.update(player, enemies); }
        
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
