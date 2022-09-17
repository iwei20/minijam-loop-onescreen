using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : Tile
{
    public Portal(int x, int y) : base(x, y)
    {
        base.tag = "portal";
    }

    public override void onCollision(BoardManager bm) {
        bm.turn();
    }

    public override bool passable() {
        return true;
    }
}

