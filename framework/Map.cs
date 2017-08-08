using System;
using System.IO;
using System.Collections.Generic;

public class Map {
    // WIDTH AND HEIGHT OF EACH TILE
    private const int WIDTH = 20;
    private const int HEIGHT = 20;
    public const int SCALE = 700/(HEIGHT+1);
    
    private int X_OFFSET = 0;
    private int Y_OFFSET = 0;

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
    
    public int getXOff() {
        return X_OFFSET * SCALE;
    }
    
    public int getYOff() {
        return Y_OFFTET * SCALE;
    }
}
