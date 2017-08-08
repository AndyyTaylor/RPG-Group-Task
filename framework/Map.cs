using System;
using System.IO;
using System.Collections.Generic;

public class Map {
    // WIDTH AND HEIGHT OF EACH TILE
    private const int WIDTH = 20;
    private const int HEIGHT = 20;
    public const int SCALE = 700/(HEIGHT+1);
    
    private float X_OFFSET = 0;
    private float Y_OFFSET = 0;

    private List<Tile> field = new List<Tile>();

    public Map() {
        foreach (string line in File.ReadLines("maptest.txt")) {
            string[] args = line.Split('|');
            Console.WriteLine(typeToInt(args[2]));
            createTile(typeToInt(args[2]), Int32.Parse(args[0]), Int32.Parse(args[1]), SCALE, SCALE);
        }
        
        /* for (int x = 0; x < WIDTH; x++) {
            for (int y = 0; y < HEIGHT; y++) {
                if (Math.Abs(x - WIDTH/2) < 2) field.Add(new Water(x*SCALE, y*SCALE, SCALE, SCALE));
                else if (Math.Abs(x - WIDTH/2) < 5) field.Add(new Sand(x*SCALE, y*SCALE, SCALE, SCALE));
                else field.Add(new Grass(x*SCALE, y*SCALE, SCALE, SCALE));
            }
        } */
    }
    
    public void update(Player player) {
        int bound = 100;
        if (player.getX() - (X_OFFSET * SCALE) < bound) {
            X_OFFSET = 1.0f * (player.getX() - bound) / SCALE;
        } else if (player.getX() - (X_OFFSET * SCALE) > SCALE*WIDTH - bound) {
            X_OFFSET = 1.0f * (player.getX() - (SCALE*WIDTH - bound)) / SCALE;
        }
        
        if (player.getY() - (Y_OFFSET * SCALE) < bound) {
            Y_OFFSET = 1.0f * (player.getY() - bound) / SCALE;
        } else if (player.getY() - (Y_OFFSET * SCALE) > SCALE*HEIGHT - bound) {
            Y_OFFSET = 1.0f * (player.getY() - (SCALE*HEIGHT - bound)) / SCALE;
        }
    }

    public void render(List<RenderObject> renderQueue) {
        foreach (Tile tile in field) {
            renderQueue.Add(tile.getRenderObject());
        }
    }
    
    private void createTile(int type, int x, int y, int w, int h) {
        switch (type) {
            case 0:
                field.Add(new Grass(x*SCALE, y*SCALE, SCALE, SCALE));
                break;
            case 1:
                field.Add(new Sand(x*SCALE, y*SCALE, SCALE, SCALE));
                break;
            case 2:
                field.Add(new Water(x*SCALE, y*SCALE, SCALE, SCALE));
                break;
        }
    }
    
    private int typeToInt(string type) {
        string[] types = {"grass", "sand", "water"};
        return Array.FindIndex(types, t => t == type);
    }
    
    public float getXOff() {
        return X_OFFSET * SCALE;
    }
    
    public float getYOff() {
        return Y_OFFSET * SCALE;
    }
}
