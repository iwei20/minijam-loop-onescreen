using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Tile
{
    public int x;
    public int y;

    public string tag;

    public Wall(int x, int y)
    {
        this.x = x;
        this.y = y;

        tag = "wall";
    }	

    public override void onCollision() {}

    public override bool passable() { return false; }
}
