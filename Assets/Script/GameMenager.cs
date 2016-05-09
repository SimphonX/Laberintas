using UnityEngine;
using System.Collections;
using System;

public class GameMenager : MonoBehaviour {
    public Maze mazePref;
    private Maze mazeint;
	// Use this for initialization
	void Start () {
        BeginGame();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
            RestartGame();
	}

    private void RestartGame()
    {
        Destroy(mazeint.gameObject);
        BeginGame();
    }

    private void BeginGame()
    {
        mazeint = Instantiate(mazePref) as Maze;
        mazeint.Generate();
    }
}
