using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Tile
{
    public Wall(int x, int y) : base(x, y)
    {
        base.tag = "wall";
    }	

    public override void onCollision(BoardManager bm) {}

    public override bool passable() { return false; }
}