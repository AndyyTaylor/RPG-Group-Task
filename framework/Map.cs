using System;
using System.Collections.Generic;

public class Map {
    // WIDTH AND HEIGHT OF EACH TILE
    private const int WIDTH = 20;
    private const int HEIGHT = 20;
    public const int SCALE = 700/(HEIGHT+1);

    private List<Tile> field = new List<Tile>();

    public Map() {
        for (int x = 0; x < WIDTH; x++) {
            for (int y = 0; y < HEIGHT; y++) {
                if (Math.Abs(x - WIDTH/2) < 2) field.Add(new Water(x*SCALE, y*SCALE, SCALE, SCALE));
                else if (Math.Abs(x - WIDTH/2) < 5) field.Add(new Sand(x*SCALE, y*SCALE, SCALE, SCALE));
                else field.Add(new Grass(x*SCALE, y*SCALE, SCALE, SCALE));
            }
        }
    }

    public void render(List<RenderObject> renderQueue) {
        foreach (Tile tile in field) {
            renderQueue.Add(tile.getRenderObject());
        }
    }
}
