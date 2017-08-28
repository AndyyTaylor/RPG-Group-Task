using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

public class MainForm : Form {  /* Main display window */
    private List<RenderObject> renderQueue = new List<RenderObject>();
    private float X_OFFSET, Y_OFFSET;
    Label label;
    Label label1;
    Label label2;
    Label label3;
    Label label4;
    ProgressBar healthBar;

    PictureBox picturebox;
    
    public bool reset = false;     // Pretend this isnt here - Andy
                                   // Can do - Alcott

    public MainForm (MainClass mainClass) {
        Text = "RPG Game";
        Size = new Size(900, 700);
        DoubleBuffered  = true;

        //picturebox = new PictureBox();
        //picturebox.Location = new Point(650,0);
        //picturebox.Text = "Abilities:";
        //picturebox.Size = new Size(400,800);
        //picturebox.Visible = true;
        //picturebox.BackColor = Color.Red;
        //Controls.Add(picturebox);

        label = new Label();
        label.Location = new Point(700, 10);
        label.Size = new Size(150,25);
        label.Text = "Character Name";
        //label2.AutoSize = false;
        //label2.TextAlign = ContentAlignment.MiddleCenter;
        label.Visible = true;
        Controls.Add(label);
        
        label1 = new Label();
        label1.Location = new Point(700, 50);
        label1.Text = "Health:";
        label1.Visible = true;
        Controls.Add(label1);
        
        healthBar = new ProgressBar();
        healthBar.Location = new System.Drawing.Point(700, 20);
        healthBar.Name = "Health";
        healthBar.Width = 200;
        healthBar.Height = 30;
        Controls.Add(healthBar);
        
        label2 = new Label();
        label2.Location = new Point(700, 200);
        label2.Text = "Abilities:";
        label2.Visible = true;
        Controls.Add(label2);
        
        label3 = new Label();
        label3.Location = new Point(700, 250);
        label3.Text = "Abilities";
        label3.Visible = true;
        Controls.Add(label3);
        
        label4 = new Label();
        label4.Location = new Point(700, 125);
        label4.Text = "Abilities";
        label4.Visible = true;
        Controls.Add(label4);

        SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.UserPaint,
            true);

        FormClosing += new FormClosingEventHandler(mainClass.exit);

        this.Show();
    }

    public void addToRenderQueue(RenderObject o) {
        renderQueue.Add(o);
    }

    protected override void OnPaint(PaintEventArgs e) {
        e.Graphics.Clear(Color.White);

        e.Graphics.TranslateTransform(-X_OFFSET, -Y_OFFSET);
        foreach (RenderObject renderObject in renderQueue) {
            renderObject.render(e);
        }

        renderQueue.Clear();

    }

    public List<RenderObject> getRenderQueue() {
        return renderQueue;
    }

    public void clearQueue() {
        renderQueue.Clear();
    }

    public void setOffsets(float _X_OFF, float _Y_OFF) {
        X_OFFSET = _X_OFF;
        Y_OFFSET = _Y_OFF;
    }
}
