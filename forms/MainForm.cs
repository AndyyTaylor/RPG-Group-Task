using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

public class MainForm : Form {  /* Main display window */
    private List<RenderObject> renderQueue = new List<RenderObject>();
    private float X_OFFSET, Y_OFFSET;
    Label label;

    public MainForm (MainClass mainClass) {
        Text = "RPG Game";
        Size = new Size(900, 700);
        DoubleBuffered  = true;

        label = new Label();
        label.Location = new Point(700, 25);
        label.Text = "SUK MAD DECK";
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
