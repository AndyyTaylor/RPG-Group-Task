using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

public class MainForm : Form {  /* Main display window */
    private List<RenderObject> renderQueue = new List<RenderObject>();
    private float X_OFFSET, Y_OFFSET;
    Label label;
    PictureBox picturebox;

    public MainForm (MainClass mainClass) {
        Text = "RPG Game";
        Size = new Size(900, 700);
        DoubleBuffered  = true;

        picturebox = new PictureBox();
        picturebox.Location = new Point(650,0);
        picturebox.Text = "Abilities:";
        picturebox.Size = new Size(400,800);
        picturebox.Visible = true;
        picturebox.BackColor = Color.Red;
        Controls.Add(picturebox);

        label = new Label();
        label.Location = new Point(700, 25);
        label.Text = "Abilities:";
        label.Visible = true;
        Controls.Add(label);

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
