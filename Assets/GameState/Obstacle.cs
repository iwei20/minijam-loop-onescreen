using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle
{
	int relX;
	int relY;
    Tile[,] tiles = new Tile[4, 4];

    public Obstacle(Tile[,] tiles)
    {
        this.relX = 0;
        this.relY = 0;

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                this.tiles[i,j] = tiles[i,j];
            }
        }
    }

    public bool isValid(bool[,] occupied)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (occupied[(relX + i) % occupied.GetLength(0), (relY + j) % occupied.GetLength(1)])
                {
                    return false;
                }
            }
        }

        return true;
    }

    public void setRelPos(int relX, int relY)
    {
        this.relX = relX;
        this.relY = relY;
    }

    public int getRelX()
    {
        return relX;
    }

    public int getRelY()
    {
        return relY;
    }

    public Tile get(int x, int y)
    {
        return tiles[x,y];
    }
}


