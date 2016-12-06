using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class MoveTowardsPathNode : MonoBehaviour {

    public float Speed;

    public int LastNodeVisited;
    public int NextNode;
    public int pathLength;
    public Pathing currentPath;
    public RectTransform healthBar;
    public Vector3 TargetPosition;
    public Vector3 CurrentPosition;

    private Slider healthBarSlider;

    // Use this for initialization
    void Awake() {
        LastNodeVisited = 0;
        NextNode = 0;

    }

    void Start()
    {
        //currentPath = GameObject.FindGameObjectWithTag("Path").GetComponent<Pathing>();
        pathLength = currentPath.path.Count;
        UpdateTargetPosition();
    }

    // Update is called once per frame
    void Update() {
        CurrentPosition = transform.position;
        TakeStep();
        CheckNodeHit();
    }

    void TakeStep()
    {
        CurrentPosition = Vector3.MoveTowards(CurrentPosition, TargetPosition, Speed*Time.deltaTime);
        transform.position = CurrentPosition;
        Vector3 targetDir = TargetPosition - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 1f, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir);
        
        
    }

    //Update TargetPosition
    void UpdateTargetPosition()
    {
        if (NextNode < pathLength-2)
            TargetPosition = currentPath.path[NextNode].worldPosition;
    }

    // See if we hit a node
    void CheckNodeHit()
    {
        // We're at the node, lets change to the next one
        if (CurrentPosition.Equals(TargetPosition))
        {
            LastNodeVisited = NextNode;
            if (LastNodeVisited < pathLength + 1)
            {
                NextNode++;
                UpdateTargetPosition();
                AdjustDirection();
            }
            else // we're at the end of the path
            {
                if (currentPath.hasSplit) // If the path we're on has a split in it
                {
                    if (currentPath.doorOpen) // If the split is open
                    {
                        float rng = UnityEngine.Random.Range(0, 101);
                        if (rng < currentPath.splitPercentage)
                        {
                            currentPath = currentPath.subPath1;
                            NextNode = 0;
                            pathLength = currentPath.path.Count;
                        }
                        else
                        {
                            currentPath = currentPath.subPath2;
                            NextNode = 0;
                            pathLength = currentPath.path.Count;
                        }
                    }
                    else
                    {
                        currentPath = currentPath.subPath1;
                        NextNode = 0;
                        pathLength = currentPath.path.Count;
                    }
                }
                else // we're at the castle!
                {
                    Destroy(this.gameObject);
                }
            }
        }

    }

    public void AdjustDirection()
    {

    }

    public void SetPathToFollow(Pathing path)
    {
        currentPath = path;
    }

    // Reduce enemy speed
    public void ReduceSpeed()
    {
        Speed = 0.0015f;
    }

    // Increase enemy speed
    public void IncreaseSpeed()
    {
        Speed = 0.0085f;
    }
}
