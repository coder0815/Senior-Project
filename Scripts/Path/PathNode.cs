using UnityEngine;
using System.Collections;

public class PathNode : MonoBehaviour {

    public Vector3 worldPosition;
    
    void Awake()
    {
        worldPosition = transform.position;
    }

    void Update()
    {
        worldPosition = transform.position;
    }
}
