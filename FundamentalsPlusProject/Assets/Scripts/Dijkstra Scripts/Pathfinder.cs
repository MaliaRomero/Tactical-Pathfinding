using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : Kinematic
{
    public Node start;
    public Node goal;
    public Graph myGraph;

    PathFollow myMoveType;
    LookWhereGoing myRotateType;
    GameObject[] myPath;
    void Start()
    {
        Debug.Log("Initializing Pathfinder...");
        
        myRotateType = new LookWhereGoing();
        myRotateType.character = this;
        if (myTarget != null)
            myRotateType.target = myTarget;
        else
            Debug.LogError("myTarget is null");

        myMoveType = new PathFollow();
        myMoveType.character = this;
        myMoveType.pathObject = new GameObject[0];

        myGraph = new Graph();
        myGraph.Rebuild();
        
        RecalculatePath();
    }
    // Call this when you toggle conditions
    public void ToggleRoadConditions()
    {
        // Example of toggling road conditions
        start.hasMud = !start.hasMud;
        goal.hasAccident = !goal.hasAccident;

        // Rebuild the graph with updated conditions
        myGraph.Rebuild();

        // Recalculate the path after rebuilding the graph
        RecalculatePath();
    }

    // Recalculate the path after rebuilding the graph
    void RecalculatePath()
    {
        List<Connection> pathObject = Dijkstra.pathfind(myGraph, start, goal);
        myPath = new GameObject[pathObject.Count + 1];

        int i = 0;
        foreach (Connection c in pathObject)
        {
            myPath[i] = c.getFromNode().gameObject;
            i++;
        }
        myPath[i] = goal.gameObject;

        myMoveType.pathObject = myPath;
    }

    protected override void Update()
    {
        if (myMoveType == null || myRotateType == null)
        {
            return;  // Prevent updates if movement or rotation is not initialized
        }

        steeringUpdate = new SteeringOutput();
        steeringUpdate.angular = myRotateType.getSteering().angular;
        steeringUpdate.linear = myMoveType.getSteering().linear;
        base.Update();
    }
}