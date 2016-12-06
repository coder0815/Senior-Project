using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathing : MonoBehaviour {

    public List<PathNode> path;

    // Variables to track path changing
    public bool hasSplit = false;
    public bool doorOpen = false;

    public float splitPercentage;
    public Pathing subPath1, subPath2;

    
}
