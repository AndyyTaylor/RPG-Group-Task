using System;
using System.Windows.Forms;

public class MainClass {    // OOP ftw
    MainForm mainForm;
    EventHandler eventHandler;
    Map gameMap;
    
    bool closed = false;
    
    public MainClass() {
        mainForm = new MainForm(this);
        eventHandler = new EventHandler(mainForm);
        gameMap = new Map();
        
        Application.Run(mainForm);  // Seems to handle quit events etc
    }
    
    public void update() {
        
    }
    
    public void render() {
        
    }
    
    public void exit(Object sender, FormClosingEventArgs e) {
        closed = true;
    }
    
    public bool checkClosed() {
        return closed;
    }
    
    static public void Main () {
        MainClass mainClass = new MainClass();
        
        while (!mainClass.checkClosed()) {
            mainClass.update();
            mainClass.render();
        }
        
        System.Console.WriteLine("Exiting...");
        Application.Exit();
    }
}
