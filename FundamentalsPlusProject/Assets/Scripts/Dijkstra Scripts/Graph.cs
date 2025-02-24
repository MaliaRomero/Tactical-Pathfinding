using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    List<Connection> mConnections;
    List<Node> nodes;

    public Graph()
    {
        mConnections = new List<Connection>();
        nodes = new List<Node>();
    }

    // Rebuild the graph, including updated road conditions
    public void Rebuild()
    {
        mConnections.Clear();

        // Find all nodes in the scene
        Node[] foundNodes = GameObject.FindObjectsOfType<Node>();
        nodes.Clear();  // Clear existing nodes
        nodes.AddRange(foundNodes);

        foreach (Node fromNode in nodes)
        {
            foreach (Node toNode in fromNode.ConnectsTo)
            {
                float mud = fromNode.hasMud ? 5f : 1f;
                float construction = fromNode.hasConstruction ? 9f : 1f;
                float accident = fromNode.hasAccident ? 50f : 1f;

                float multiplier = mud * construction * accident;

                // Calculate cost based on distance (or any other logic you want)
                float cost = (toNode.transform.position - fromNode.transform.position).magnitude;

                // Create a new connection with the adjusted cost
                Connection c = new Connection(multiplier * cost, fromNode, toNode);
                mConnections.Add(c);
            }
        }
    }

    // Now this should be used instead of getConnections
    public List<Connection> GetConnections(Node fromNode)
    {
        List<Connection> connections = new List<Connection>();
        foreach (Connection c in mConnections)
        {
            if (c.getFromNode() == fromNode)
            {
                connections.Add(c);
            }
        }
        return connections;
    }

    public List<Node> GetNodes()
    {
        return nodes;
    }
}

public class Connection // Needed for Dijkstra script as well, thats why it is here
{
    float cost;
    Node fromNode;
    Node toNode;

    public Connection(float cost, Node fromNode, Node toNode)
    {
        this.cost = cost;
        this.fromNode = fromNode;
        this.toNode = toNode;
    }
    public float getCost()
    {
        return cost;
    }

    public Node getFromNode()
    {
        return fromNode;
    }

    public Node getToNode()
    {
        return toNode;
    }
}