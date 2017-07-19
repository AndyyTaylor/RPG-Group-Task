using System;
using System.Windows.Forms;
using System.Drawing;

public class MainClass {    // OOP ftw
    MainForm mainForm;
    EventHandler eventHandler;
    Map gameMap;
    
    bool closed = false;
    
    public MainClass() {
        mainForm = new MainForm(this);
        eventHandler = new EventHandler(mainForm);
        gameMap = new Map();
    }
    
    public void update() {  /* Performs code logic */
        
    }
    
    public void render() {  /* Adds all rendering to mainForm.renderQueue */
        gameMap.render(mainForm.getRenderQueue());
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
