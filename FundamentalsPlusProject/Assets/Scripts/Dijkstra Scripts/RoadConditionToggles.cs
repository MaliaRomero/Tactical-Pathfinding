using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RoadConditionToggles : MonoBehaviour
{
    public Toggle mudToggle;
    public Toggle constructionToggle;
    public Toggle accidentToggle;

    public Node[] roadNodes; // Assign all nodes that represent roads
    public Graph myGraph; // Add this reference

    public Pathfinder pathfinder; // Reference to the Pathfinder script

    public void UpdateMudCondition(bool isOn)
    {
        if (pathfinder != null && pathfinder.myGraph != null)
        {
            // Modify the graph based on the toggle state
            foreach (Node node in pathfinder.myGraph.GetNodes())
            {
                node.hasMud = isOn; // Update condition on nodes
            }
            pathfinder.myGraph.Rebuild(); // Rebuild the graph after changes
        }
        else
        {
            Debug.LogError("Pathfinder or Graph is not assigned!");
        }
    }
    public void UpdateConstructionCondition(bool isOn)
    {
        if (pathfinder != null && pathfinder.myGraph != null)
        {
            // Modify the graph based on the toggle state
            foreach (Node node in pathfinder.myGraph.GetNodes())
            {
                node.hasConstruction = isOn; // Update condition on nodes
            }
            pathfinder.myGraph.Rebuild(); // Rebuild the graph after changes
        }
        else
        {
            Debug.LogError("Pathfinder or Graph is not assigned!");
        }
    }

    public void UpdateAccidentondition(bool isOn)
    {
        if (pathfinder != null && pathfinder.myGraph != null)
        {
            // Modify the graph based on the toggle state
            foreach (Node node in pathfinder.myGraph.GetNodes())
            {
                node.hasAccident = isOn; // Update condition on nodes
            }
            pathfinder.myGraph.Rebuild(); // Rebuild the graph after changes
        }
        else
        {
            Debug.LogError("Pathfinder or Graph is not assigned!");
        }
    }
}