using UnityEngine;
using System.Collections.Generic;

public class Node {
    public List<Node> graphNode;//List of surrounding nodes for each node. 
    public Node parent;
    public MapMaker mapmaker;
    public bool walkable;
    public Vector3 nodeVector;

    public int gCost;
    public int hCost;

    public int xPos;
    public int yPos;

    public Node(bool walking,Vector3 position){
        graphNode = new List<Node>();
        walkable = walking;
        nodeVector = position;
    }
    public Vector3 NodePosition()
    {
        return nodeVector;
        //For when you want to know exactly where what node is.
    }
    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }
    
}
