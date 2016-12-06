using UnityEngine;
using System.Collections;

public class BuildGrid{

    public static BuildGrid buildGrid;

    public BuildSquare[,] buildGridSquares = new BuildSquare[8,8];

    void Awake()
    {
        buildGrid = this;
        
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Initiallize the Build grid
    // TODO: remove hardcode
    public void InitializeBuildGridSquares()
    {
        // Row 1
        buildGridSquares[0, 0].isEmpty = true;
        buildGridSquares[0, 0].isTower = false;
        buildGridSquares[0, 1].isEmpty = true;
        buildGridSquares[0, 1].isTower = false;
        buildGridSquares[0, 2].isEmpty = true;
        buildGridSquares[0, 2].isTower = false;
        buildGridSquares[0, 3].isEmpty = true;
        buildGridSquares[0, 3].isTower = false;
        buildGridSquares[0, 4].isEmpty = true;
        buildGridSquares[0, 4].isTower = false;
        buildGridSquares[0, 5].isEmpty = true;
        buildGridSquares[0, 5].isTower = false;
        buildGridSquares[0, 6].isEmpty = true;
        buildGridSquares[0, 6].isTower = false;
        buildGridSquares[0, 7].isEmpty = true;
        buildGridSquares[0, 7].isTower = false;
        // Row 2
        buildGridSquares[1, 0].isEmpty = false;
        buildGridSquares[1, 0].isTower = true;
        buildGridSquares[1, 1].isEmpty = false;
        buildGridSquares[1, 1].isTower = true;
        buildGridSquares[1, 2].isEmpty = false;
        buildGridSquares[1, 2].isTower = true;
        buildGridSquares[1, 3].isEmpty = false;
        buildGridSquares[1, 3].isTower = true;
        buildGridSquares[1, 4].isEmpty = false;
        buildGridSquares[1, 4].isTower = true;
        buildGridSquares[1, 5].isEmpty = false;
        buildGridSquares[1, 5].isTower = true;
        buildGridSquares[1, 6].isEmpty = false;
        buildGridSquares[1, 6].isTower = true;
        buildGridSquares[1, 7].isEmpty = false;
        buildGridSquares[1, 7].isTower = true;
    }

    public struct BuildSquare
    {
        public bool isEmpty;
        public bool isTower;
    }
}
