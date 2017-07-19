using System;
using System.Collections.Generic;

public class Map {
    private const int WIDTH = 20;
    private const int HEIGHT = 20;
    private const int SCALE = 700/(HEIGHT+1);
    
    private List<Tile> field = new List<Tile>();
    
    public Map() {
        for (int x = 0; x < WIDTH; x++) {
            for (int y = 0; y < HEIGHT; y++) {
                field.Add(new Grass(x*SCALE+5, y*SCALE+5, SCALE-10, SCALE-10));
            }
        }
    }
    
    public void render(List<RenderObject> renderQueue) {
        for (int i = 0; i < field.Count; i++) {
            renderQueue.Add(field[i].getRenderObject());
        }
    }
}