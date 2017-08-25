using System;
using System.IO;
using System.Collections.Generic;

public class Map {
    // WIDTH AND HEIGHT OF EACH TILE
    public const int WIDTH = 30;
    public const int HEIGHT = 30;
    public const int SCALE = 700/(HEIGHT+1);
    
    private float X_OFFSET = 0;
    private float Y_OFFSET = 0;

    private List<Tile> field = new List<Tile>();

    public Map() {
        foreach (string line in File.ReadLines("maptest.txt")) {
            string[] args = line.Split('|');
            createTile(typeToInt(args[2]), Int32.Parse(args[0]), Int32.Parse(args[1]), SCALE, SCALE);
        }
    }
    
    public void update(Player player) {
        int bound = 200;
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
        
        if (X_OFFSET < 0) X_OFFSET = 0;
        else if (X_OFFSET > bound - WIDTH) X_OFFSET = bound - WIDTH;
        if (Y_OFFSET < 0) Y_OFFSET = 0;
        else if (Y_OFFSET > bound - HEIGHT) Y_OFFSET = bound - HEIGHT;
    }

    public void render(List<RenderObject> renderQueue) {
        foreach (Tile tile in field) {
            if (tile.getX() + SCALE - X_OFFSET * SCALE > 0
                && tile.getX() - X_OFFSET * SCALE < SCALE * WIDTH
                && tile.getY() + SCALE - Y_OFFSET * SCALE > 0
                && tile.getY() - SCALE - Y_OFFSET * SCALE < SCALE * HEIGHT)
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
    
    public List<Tile> tileAtPos(Player player) {
        List<Tile> ret = new List<Tile>();
        foreach (Tile tile in field) {
            if (tile.getX() < player.getX() + player.getW()/2
                && tile.getX() + tile.getW() > player.getX() + player.getW()/2
                && tile.getY() < player.getY() + player.getH()/2
                && tile.getY() + tile.getH() > player.getY() + player.getH()/2) {
                    ret.Add(tile);
                }
        }
        
        return ret;
    }
}
