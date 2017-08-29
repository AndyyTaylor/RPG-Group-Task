using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

public class MainClass {    // OOP ftw
    MainForm mainForm;
    EventHandler eventHandler;
    Map gameMap;
    Player player;
    List<Enemy> enemies;
    List<Projectile> projectiles;
    static Stopwatch stopWatch;
    Random rnd;
    int prevPlayerId;

    bool closed = false;

    public MainClass() {
        mainForm = new MainForm(this);
        gameMap = new Map();
        rnd = new Random();
        enemies = new List<Enemy>();
        projectiles = new List<Projectile>();
        
        player = mainForm.loadPlayer(0);
        prevPlayerId = 0;

        eventHandler = new EventHandler(mainForm, player);
    }

    public void update() {  /* Performs code logic */
        if (prevPlayerId != mainForm.player.id) {
            player = mainForm.player;
            eventHandler.player = player;
            prevPlayerId = player.id;
            enemies.Clear();
            projectiles.Clear();
        }
        
        if (player.health <= 0) {
            if (mainForm.reset) {
                reset();
            }
            return;
        }

        gameMap.update(player);
        player.update(gameMap, projectiles);
        foreach(Projectile proj in projectiles) { proj.update(player, enemies); }
        foreach(Enemy enemy in enemies) {
            enemy.update(player, projectiles);
            if (enemy.isDead()) {
                player.money += enemy.reward;
            }
        }
        
        
        mainForm.updateUI(player);
        
        enemies = enemies.Where(e => !e.isDead()).ToList();
        projectiles = projectiles.Where(p => !p.isDead()).ToList();
        
        if (enemies.Count == 0) {
            spawnWave();
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
    
    public void spawnWave() {
        player.wave++;
        int num_enemies = (int) (Math.Pow(player.wave, 2) / 5);
        int num_ranged = (int) (num_enemies / 5);
        int num_bosses = (int) (num_ranged / 10);
        
        for (int i = 0; i < num_enemies; i++) { enemies.Add(new Enemy(rnd.Next(0, Map.TWIDTH * Map.SCALE), rnd.Next(0, Map.THEIGHT * Map.SCALE), Map.SCALE, Map.SCALE)); }
        for (int i = 0; i < num_ranged; i++) { enemies.Add(new Ranged(rnd.Next(0, Map.TWIDTH * Map.SCALE), rnd.Next(0, Map.THEIGHT * Map.SCALE), Map.SCALE, Map.SCALE)); }
        for (int i = 0; i < num_bosses; i++) { enemies.Add(new Boss(rnd.Next(0, Map.TWIDTH * Map.SCALE), rnd.Next(0, Map.THEIGHT * Map.SCALE), Map.SCALE*2, Map.SCALE*2)); }
        
        System.Console.WriteLine(num_ranged.ToString() + " spawned");
    }
    
    public void reset() {
        mainForm.reset = false;
        player = new Player(Map.SCALE * Map.TWIDTH / 2, Map.SCALE * Map.THEIGHT / 2, Map.SCALE, Map.SCALE);
        eventHandler.player = player;
        enemies.Clear();
        projectiles.Clear();
    }

    public void exit(Object sender, FormClosingEventArgs e) {  /* When window is closed */
        closed = true;
        mainForm.savePlayer(player);
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
