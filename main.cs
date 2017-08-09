using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

public class MainClass {    // OOP ftw

    // Forms
    MainForm mainForm;
    EventHandler eventHandler;
    Map gameMap;
    Player player;
    Enemy enemy;
    static Stopwatch stopWatch;

    bool closed = false;

    public MainClass() {
        mainForm = new MainForm(this);
        gameMap = new Map();
        player = new Player(Map.SCALE * Map.WIDTH, Map.SCALE * Map.HEIGHT, Map.SCALE, Map.SCALE);
        enemy = new Enemy(50, 400, Map.SCALE, Map.SCALE);

        eventHandler = new EventHandler(mainForm, player);
    }

    public void update() {  /* Performs code logic */
        player.update(gameMap);
        enemy.moveToPlayer(player);
        gameMap.update(player);
        
        mainForm.Invalidate();
    }

    public void render() {  /* Adds all rendering to mainForm.renderQueue */
        mainForm.clearQueue();
        mainForm.setOffsets(gameMap.getXOff(), gameMap.getYOff());
        gameMap.render(mainForm.getRenderQueue());
        player.render(mainForm.getRenderQueue());
        enemy.render(mainForm.getRenderQueue());
    }

    public void exit(Object sender, FormClosingEventArgs e) {  /* When window is closed */
        closed = true;
    }

    public bool checkClosed() {
        return closed;
    }

    static public void Main () {  /* Main game loop */
        MainClass mainClass = new MainClass();
        stopWatch = new Stopwatch();

        while (!mainClass.checkClosed()) {
            stopWatch.Start();
            mainClass.update();
            mainClass.render();

            Application.DoEvents();
            System.Console.WriteLine(stopWatch.Elapsed);
            stopWatch.Restart();
        }

        System.Console.WriteLine("Exiting...");
        Application.Exit();
    }
}
