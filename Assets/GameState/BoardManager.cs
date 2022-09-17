using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    const int MAP_SIZE = 16;
    const int OBSTACLE_AMOUNT = 1;

    Obstacle[] obstacles = new Obstacle[OBSTACLE_AMOUNT];	

    public Tile[,] map = new Tile[MAP_SIZE, MAP_SIZE];
    bool[,] occupied = new bool[MAP_SIZE, MAP_SIZE];

    public BoardManager()
    {
        obstacles[0] = new Obstacle(new Tile[,] {{null, null, null, null}, 
                                                  {null, null, null, null},
                                                  {null, null, null, null},
                                                  {null, null, null, null}});

        for (int i = 0; i < MAP_SIZE; i++)
        {
            for (int j = 0; j < MAP_SIZE; j++) 
            {
                map[i,j] = null;
                occupied[i,j] = false;
            }
        }
    }

    public Tile[,] getTileMap()
    {
        return map;
    }

    public void turn(int unforcedSpawn, int forcedSafeSpawn, int forcedUnsafeSpawn)
    {
        for (int spawns = 0; spawns < unforcedSpawn; spawns++)
        {
            Obstacle ob = obstacles[Random.Range(0, OBSTACLE_AMOUNT)];

            ob.setRelPos(Random.Range(0, MAP_SIZE), Random.Range(0, MAP_SIZE));

            if (ob.isValid(occupied))
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        int x = ob.getRelX() + i;
                        int y = ob.getRelY() + i;
                        occupied[i,j] = true;
                        map[i,j] = ob.get(i, j);
                    }
                }
            }
        }

        for (int spawns = 0; spawns < forcedSafeSpawn; spawns++)
        {
            Obstacle ob = obstacles[Random.Range(0, OBSTACLE_AMOUNT)];

            ob.setRelPos(Random.Range(0, MAP_SIZE), Random.Range(0, MAP_SIZE));

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int x = ob.getRelX() + i;
                    int y = ob.getRelY() + i;
                    occupied[i,j] = true;

                    if (map[i,j] == null)
                    {
                        map[i,j] = ob.get(i, j);
                    }
                }
            }
        }

        for (int spawns = 0; spawns < forcedUnsafeSpawn; spawns++)
        {
            Obstacle ob = obstacles[Random.Range(0, OBSTACLE_AMOUNT)];

            ob.setRelPos(Random.Range(0, MAP_SIZE), Random.Range(0, MAP_SIZE));

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int x = ob.getRelX() + i;
                    int y = ob.getRelY() + i;
                    occupied[i,j] = true;

                    if (map[i,j] == null)
                    {
                        map[i,j] = ob.get(i, j);
                    }
                }
            }
        }
    }

}
