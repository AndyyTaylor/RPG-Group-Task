using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

public class MainForm : Form {  /* Main display window */
    private List<RenderObject> renderQueue = new List<RenderObject>();
    
    public MainForm (MainClass mainClass) {
        Text = "RPG Game";
        Size = new Size(900, 700);
        
        FormClosing += new FormClosingEventHandler(mainClass.exit);
        
        this.Show();
    }
    
    public void addToRenderQueue(RenderObject o) {
        renderQueue.Add(o);
    }
    
    protected override void OnPaint(PaintEventArgs e) {
        for (int i = 0; i < renderQueue.Count; i++) {
            renderQueue[i].render(e);
        }
        
        renderQueue.Clear();
    }
    
    public List<RenderObject> getRenderQueue() {
        return renderQueue;
    }
}