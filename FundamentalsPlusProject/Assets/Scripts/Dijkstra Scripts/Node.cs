using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Node : MonoBehaviour
{
    public Node[] ConnectsTo;

    // Add these flags for road conditions
    public bool hasMud;
    public bool hasConstruction;
    public bool hasAccident;

    private void OnDrawGizmos()
    {
        foreach (Node n in ConnectsTo)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, (n.transform.position - transform.position).normalized * 2);
        }
    }
}