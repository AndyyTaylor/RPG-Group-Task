using System;
using System.Windows.Forms;
using System.Drawing;

public class MainClass {    // OOP ftw
    MainForm mainForm;
    EventHandler eventHandler;
    Map gameMap;
    Player player;
    
    bool closed = false;
    
    public MainClass() {
        mainForm = new MainForm(this);
        gameMap = new Map();
        player = new Player(1, 1, Map.SCALE, Map.SCALE);
        
        eventHandler = new EventHandler(mainForm, player);
    }
    
    public void update() {  /* Performs code logic */
        // player.update();
    }
    
    public void render() {  /* Adds all rendering to mainForm.renderQueue */
        gameMap.render(mainForm.getRenderQueue());
        // player.render(mainForm.getRenderQueue());
    }
    
    public void exit(Object sender, FormClosingEventArgs e) {  /* When window is closed */
        closed = true;
    }
    
    public bool checkClosed() {
        return closed;
    }
    
    static public void Main () {  /* Main game loop */
        MainClass mainClass = new MainClass();
        
        while (!mainClass.checkClosed()) {
            mainClass.update();
            mainClass.render();
            
            Application.DoEvents();
        }
        
        System.Console.WriteLine("Exiting...");
        Application.Exit();
    }
}
