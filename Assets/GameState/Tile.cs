using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile 
{
    public int x;
    public int y;

    public string tag;

    public Tile(int x, int y)
    {
        this.x = x;
        this.y = y;
    }	

    public abstract void onCollision(BoardManager bm);

    public abstract bool passable();
}
