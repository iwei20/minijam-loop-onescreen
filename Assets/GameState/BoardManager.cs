using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    const int MAP_SIZE = 16;
    const int OBSTACLE_AMOUNT = 1;

    int turnnum = 0;

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

    
    public bool canFindSafePath(int x, int y, int endx, int endy) 
    {
        bool[,] visited = new bool[MAP_SIZE, MAP_SIZE];
        Stack<(int, int)> dfs = new Stack<(int, int)>();

        int[] dx = {1, 0, -1, 0};
        int[] dy = {0, 1, 0, -1};

        visited[x,y] = true;
        dfs.Push((x, y));
        while (dfs.Count > 0) 
        {
            (int, int) curr = dfs.Pop();
            if (curr.Item1 == endx && curr.Item2 == endy) 
            {
                return true;
            }

            for (int i = 0; i < 4; ++i) 
            {   
                int newX = (curr.Item1 + dx[i]) % MAP_SIZE;
                int newY = (curr.Item2 + dy[i]) % MAP_SIZE;

                if (!visited[newX,newY]) 
                {
                    dfs.Push((newX, newY));
                    visited[newX,newY] = true;
                }
            }
        }
        return false;
    }

    public void turn()
    {
        turnHelper(3 * turnnum/2, turnnum, turnnum/2);
        ++turnnum;
    }

    public void turnHelper(int unforcedSpawn, int forcedSafeSpawn, int forcedUnsafeSpawn)
    {
        (int, int) portalPosition = (Random.Range(0, MAP_SIZE), Random.Range(0, MAP_SIZE));
        map[portalPosition.Item1, portalPosition.Item2] = new Portal(portalPosition.Item1, portalPosition.Item2);
        
        /*
        for (int i = 0; i < MAP_SIZE; ++i) 
        {
            for(int j = 0; j < MAP_SIZE; ++j)
            {
                int portalX = (portalPosition.Item1 + i) % MAP_SIZE;
                int portalY = (portalPosition.Item2 + j) % MAP_SIZE;


            }
        }*/
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
                        map[x,y] = ob.get(i, j);
                        map[x,y].x = x;
                        map[x,y].x = y;
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
                        map[x,y] = ob.get(i, j);
                        map[x,y].x = x;
                        map[x,y].x = y;
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

                    map[x,y] = ob.get(i, j);
                    map[x,y].x = x;
                    map[x,y].x = y;
                }
            }
        }
    }

}
