using UnityEngine;
using System.Collections;
using System;

public class Maze : MonoBehaviour {
    public int sizeX, sizeY;
    private System.Random rnd = new System.Random();
    private int[,] maze;
    public MazeGr cellPrefab1;
    //private MazeGr[,] cells1;
    public MazeCell cellPrefab;
    //private MazeCell[,] cells;
    private void generav(int r, int c)
    {
        int k = 0;
        int sk = rnd.Next(1, 4);
        switch (sk)
        {
            case 1:
                if (k == 4) break;
                k++;
                if (r - 2> 0 && maze[r - 2, c] == 0 && maze[r - 1, c] == 0)
                {
                    maze[r - 2, c] = 1;
                    maze[r - 1, c] = 1;
                    generav(r - 2, c);
                }
                goto case 2;
            case 2:
                if (k == 4) break;
                k++;
                if (c + 2 < sizeY && maze[r, c + 2] == 0 && maze[r, c + 1] == 0)
                {
                    maze[r, c + 2] = 1;
                    maze[r, c + 1] = 1;
                    generav(r, c + 2);
                }
                goto case 3;
            case 3:
                if (k == 4) break;
                k++;
                if (r + 2 < sizeX && maze[r + 2, c] == 0 && maze[r + 1, c] == 0)
                {
                    maze[r + 2, c] = 1;
                    maze[r + 1, c] = 1;
                    generav(r + 2, c);
                }
                goto case 4;
            case 4:
                if (k == 4) break;
                k++;
                if (c - 2 > 0 && maze[r, c - 2] == 0 && maze[r, c - 1] == 0)
                {
                    maze[r, c - 2] = 1;
                    maze[r, c - 1] = 1;
                    generav(r, c - 2);
                }
                goto case 1;
        }
    }
    public void Generate()
    {
        //cells = new MazeCell[sizeX+50, sizeY+50];
        maze = new int[sizeX+50, sizeY+50];
        Array.Clear(maze, 0, 125);
        //cells1 = new MazeGr[sizeX+50, sizeY+50];
        maze[1, 1] = 1;
        generav(1, 1);
        
        for (int x = 0; x <= sizeX; x++)
            for (int y = 0; y <= sizeY; y++)
            {
                if (maze[x, y] == 1) CreateCell1(x, y);
                else CreateCell(x, y);
            }
    }
    private void CreateCell(int x, int y)
    {
        print(x + y);
        MazeCell newCell = Instantiate(cellPrefab);
        newCell.name = "Maze Cell " + x + ", " + y;

        newCell.transform.localPosition = new Vector3(x, y, 0);
    }
    private void CreateCell1(int x, int y)
    {
        MazeGr newCell = Instantiate(cellPrefab1);
        newCell.name = "Maze Cell " + x + ", " + y;

        newCell.transform.localPosition = new Vector3(x, y, 1);
    }
}
