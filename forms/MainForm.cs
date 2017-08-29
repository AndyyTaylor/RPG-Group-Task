using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.IO;

public class MainForm : Form {  /* Main display window */
    private List<RenderObject> renderQueue = new List<RenderObject>();
    private float X_OFFSET, Y_OFFSET;
    public Player player = null;
    public Label label;
    Label label2;
    Label label3;
    Label label4;
    Label label5;
    ProgressBar healthBar;
    Button button;
    Button button2;
    Button button3;
    Button button4;
    Button button5;
    Button button6;
    Button button7;

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
        label.Size = new Size(175,25);
        label.BackColor = Color.Black;
        label.ForeColor = Color.White;
        label.Text = "Character Name";
        //label2.AutoSize = false;
        
        label.TextAlign = ContentAlignment.MiddleCenter;
        label.Visible = true;
        Controls.Add(label);
        
        healthBar = new ProgressBar();
        healthBar.Location = new System.Drawing.Point(700, 100);
        healthBar.Name = "Health";
        healthBar.BackColor = Color.Red;
        healthBar.Width = 140;
        healthBar.Height = 20;
        Controls.Add(healthBar);
        
        button = new Button();
        button.Location = new System.Drawing.Point(850, 100);
        button.Width = 25;
        button.Height = 25;
        button.Text = "+";
        button.Click += new System.EventHandler(addHealth);
        Controls.Add(button);
        
        label2 = new Label();
        label2.Location = new Point(700, 200);
        label2.Text = "God Mode biotch";
        label2.Width = 140;
        label2.Visible = true;
        Controls.Add(label2);
        
        button3 = new Button();
        button3.Location = new System.Drawing.Point(850,200);
        button3.Width = 25;
        button3.Height = 25;
        button3.Text = "+";
        button3.Click += new System.EventHandler(addGodMode);
        Controls.Add(button3);
        
        label3 = new Label();
        label3.Location = new Point(700, 150);
        label3.Width = 140;
        label3.Text = "Bullet Power";
        label3.Visible = true;
        Controls.Add(label3);
        
        button2 = new Button();
        button2.Location = new System.Drawing.Point(850, 150);
        button2.Width = 25;
        button2.Height = 25;
        button2.Text = "+";
        button2.Click += new System.EventHandler(addBulletPower);
        Controls.Add(button2);
        
        label4 = new Label();
        label4.Location = new Point(700, 50);
        label4.Size = new Size(175,25);
        label4.BackColor = Color.Green;
        label4.Text = "Money: ";
        label4.Visible = true;
        Controls.Add(label4);
        
        label5 = new Label();
        label5.Location = new Point(700,250);
        label5.BackColor = Color.Black;
        label5.ForeColor = Color.White;
        label5.Size = new Size(175,25);
        label5.Text = "LOAD CHARACTER";
        label5.TextAlign = ContentAlignment.MiddleCenter;
        label5.Visible = true;
        Controls.Add(label5);
        
        button3 = new Button();
        button3.Location = new System.Drawing.Point(800, 300);
        button3.Width = 25;
        button3.Height = 25;
        button3.Text = "3";
        button3.Click += new System.EventHandler(char2Load);
        Controls.Add(button3);
        
        button4 = new Button();
        button4.Location = new System.Drawing.Point(850, 300);
        button4.Width = 25;
        button4.Height = 25;
        button4.Text = "4";
        button4.Click += new System.EventHandler(char3Load);
        Controls.Add(button4);
        
        button5 = new Button();
        button5.Location = new System.Drawing.Point(750, 300);
        button5.Width = 25;
        button5.Height = 25;
        button5.Text = "2";
        button5.Click += new System.EventHandler(char1Load);
        Controls.Add(button5);
        
        button6 = new Button();
        button6.Location = new System.Drawing.Point(700, 300);
        button6.Width = 25;
        button6.Height = 25;
        button6.Text = "1";
        button6.Click += new System.EventHandler(char0Load);
        Controls.Add(button6);

        SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.UserPaint,
            true);

        FormClosing += new FormClosingEventHandler(mainClass.exit);

        this.Show();
    }
    
    public void updateUI(Player _player) {
        player = _player;
        label.Text = "Character Number " + (player.id + 1).ToString();
        label4.Text = "Money: " + player.money.ToString();
        label3.Text = "Bullet Power ($100): " + player.bulletPower.ToString();
        label2.Text = "God Mode ($100): " + player.godmode.ToString();
        healthBar.Value = Math.Max(player.health, 0);
    }
    
    public Player loadPlayer(int num) {
        if (num < 0 || num > 3) return null;
        
        if (player != null) savePlayer(player);
        
        foreach (string line in File.ReadLines("data/char" + num.ToString() + ".txt")) {
            string[] args = line.Split('|');
            player = new Player(Int32.Parse(args[0]), Int32.Parse(args[1]), Map.SCALE, Map.SCALE);
            player.health = Int32.Parse(args[2]);
            player.bulletPower = Int32.Parse(args[3]);
            player.money = Int32.Parse(args[4]);
            player.godmode = Int32.Parse(args[5]);
            player.id = num;
            player.wave = Int32.Parse(args[6])-1;
            return player;
        }
        return null;
    }
    
    public void savePlayer(Player p) {
        string text = p.getX().ToString() + "|" + p.getY().ToString() + "|" + p.health.ToString() + "|" + p.bulletPower.ToString() + "|" + p.money.ToString() + "|" + p.godmode.ToString() + "|" + p.wave.ToString();
        System.IO.File.WriteAllText("data/char" + p.id.ToString() + ".txt", text);
    }
    
    public void char0Load(object sender, EventArgs e) {
        player = loadPlayer(0);
    }
    
    public void char1Load(object sender, EventArgs e) {
        player = loadPlayer(1);
    }
    
    public void char2Load(object sender, EventArgs e) {
        player = loadPlayer(2);
    }
    
    public void char3Load(object sender, EventArgs e) {
        player = loadPlayer(3);
    }
    
    public void addHealth(object sender, EventArgs e) {
        if (player.money >= 10 && player.health < 100) {
            player.health += 1;
            player.money -= 10;
        }
    }
    
    public void addGodMode(object sender, EventArgs e) {
        if (player.money >= 100) {
            player.godmode += 100;
            player.money -= 100;
        }
    }
    
    public void addBulletPower(object sender, EventArgs e) {
        if (player.money >= 100) {
            player.bulletPower += 1;
            player.money -= 100;
        }
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
