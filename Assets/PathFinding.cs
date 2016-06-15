using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class PathFinding : MonoBehaviour {
    public ObjectMovement unit;
    

    MapMaker mapmaker;    
    void Awake()
    {
        mapmaker = GetComponent<MapMaker>();
        
    }
    void Update()
    {
        if(mapmaker != null)
        {

        }
        if (mapmaker.finished  &&  mapmaker.targetPlaced == true)
        {
            Vector3 targetPos = mapmaker.grid[20,20].nodeVector;

            StartCoroutine(FindPath(mapmaker.playerNode.nodeVector, targetPos));
        }
    }
    public void StartFindPath(Vector3 startpos, Vector3 endpos)
    {
        StartCoroutine(FindPath(startpos, endpos));
    }
    /*
        gCost = how far the node is from the start node
        hCost = how far the node is from the end node.
        fCost = gCost + hCost. Algorithm checks for the lowest fCost based on neighbours.

        Values to use: 10 for linear, 14 for diagonals.

    */

    IEnumerator FindPath(Vector3 startPosition, Vector3 targetPostion)
    {
        Node startNode = mapmaker.NodefromWorldPosition(startPosition);
        Node targetNode = mapmaker.NodefromWorldPosition(targetPostion);

        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();//Hashset is just a fast way to check whether a node is within the list or not.
        openSet.Add(startNode);
        
        while (openSet.Count > 0)
        {
            Node currentNode = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if(openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost)
                {
                    currentNode = openSet[i];
                    /*
                        If the fCost of a neighbouring node is lower than current node, or if it equals the current node while the hCost is lower,
                        then the neighbouring node is closer to target and therefore should be the new node. 
                    */
                    

                }
            }
            openSet.Remove(currentNode);
            closedSet.Add(currentNode);
            //Dumps the checked nodes into the closedset so it wont be evaluated again.
            if(currentNode == targetNode)
            {
                
                RetracePath(startNode, targetNode);
                break;//Ends the loop
            }
            foreach (Node neigbhor in currentNode.graphNode) //Looks up and checks the neighbours for each node
            {
                if (!neigbhor.walkable || closedSet.Contains(neigbhor))
                {
                    continue;//If the node cant even be walked upon, just get on with it.
                }
                int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neigbhor);
                if (newMovementCostToNeighbour < neigbhor.gCost || !openSet.Contains(neigbhor)) {
                    neigbhor.gCost = newMovementCostToNeighbour;
                    neigbhor.hCost = GetDistance(neigbhor, targetNode);
                    neigbhor.parent = currentNode;

                    if (!openSet.Contains(neigbhor))
                    {
                        openSet.Add(neigbhor);
                        
                    }
                }
            }
        }
        yield return null;
    }
    void RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;//Starting from the end
        while (currentNode != startNode)
        {            
            path.Add(currentNode);
            currentNode = currentNode.parent;           
        }

        path.Reverse();
        unit.pathNodes = path; 

          
    }
    public int GetDistance(Node A, Node B)
    {
        int distX = Mathf.Abs(A.xPos - B.xPos);
        int distY = Mathf.Abs(A.yPos - B.yPos);

        if (distX > distY)
        {
            return 14 * distY + 10 * (distX - distY);
        }
        else
        {
            return 14 * distX + 10 * (distY - distX);
        }
    } 
}
