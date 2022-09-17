using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : Tile
{
    public override void onCollision(BoardManager bm) {
        BoardManager.turn();
    }

    public override bool passable() {
        return true;
    }
}

