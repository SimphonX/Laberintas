using UnityEngine;
using System.Collections;
using System;

public class MazeGen : MonoBehaviour {
    private System.Random rnd = new System.Random();
    private int [,] maze;
    public MazeGr cellPrefab;
    private MazeGr [,] cells;
    public int sizeX, sizeY;
    public void generavimas()
    {
        maze = new int [100, 100];
        Array.Clear(maze, 0, 100);
        cells = new MazeGr[sizeX,sizeY];
        generav(1, 1);
        for(int x = 0; x < 100; x++)
        {
            for (int y = 0; y < 100; y++)
            {
                if (maze[x, y] == 1) CreateCell(x, y);
            }
        }
    }

    private void generav(int r, int c)
    {
        int k = 1;
        int sk = rnd.Next(1, 4);
        switch (sk)
        {
            case 1:
                if (k == 4) break;
                k++;
                if (r - 2 > 0 && maze[r - 2, c] == 0)
                {
                    maze[r - 2, c] = 1;
                    maze[r - 1, c] = 1;
                    generav(r - 2, c);
                }
                goto case 2;
            case 2:
                if (k == 4) break;
                k++;
                if (c + 2 < 100 && maze[r, c + 2] == 0)
                {
                    maze[r, c + 2] = 1;
                    maze[r, c + 1] = 0;
                    generav(r, c + 2);
                }
                goto case 3;
            case 3:
                if (k == 4) break;
                k++;
                if (r + 2 < 100 && maze[r + 2, c] == 0)
                {
                    maze[r + 2, c] = 1;
                    maze[r + 1, c] = 1;
                    generav(r + 2, c);
                }
                goto case 4;
            case 4:
                if (k == 4) break;
                k++;
                if (c - 2 > 0 && maze[r, c - 2] == 0)
                {
                    maze[r, c - 2] = 1;
                    maze[r, c - 1] = 1;
                    generav(r, c - 2);
                }
                goto case 1;
        }
    }
    private void CreateCell(int x, int y)
    {
        MazeGr newCell = Instantiate(cellPrefab) as MazeGr;
        cells[x, y] = newCell;
        newCell.name = "Maze Cell " + x + ", " + y;
        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3(x - sizeX * 0.5f + 0.5f, y - sizeY * 0.5f + 0.5f);
    }
}
