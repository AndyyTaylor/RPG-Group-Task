using System;
using System.Windows.Forms;
using System.Drawing;

public class MainForm : Form {
    public MainForm (MainClass mainClass) {
        Text = "RPG Game";
        Size = new Size(900, 700);
        
        FormClosing += new FormClosingEventHandler(mainClass.exit);
        
        this.Show();
    }
    
    protected override void OnPaint(PaintEventArgs e) {
        SolidBrush blackPen = new SolidBrush(Color.Black);
        e.Graphics.FillRectangle(blackPen, 0, 0, 200, 200);
    }
}