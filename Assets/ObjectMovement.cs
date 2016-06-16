using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class ObjectMovement : MonoBehaviour    {
    PathFinding pathfinder;
    MapMaker mapmaker;
    public List<Node> pathNodes = null;
    Node CurrentNode;
    Vector3 final;
    public Text texty;
    void Awake()
    {
        pathfinder = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PathFinding>();
        mapmaker = GameObject.FindGameObjectWithTag("GameManager").GetComponent<MapMaker>();
    }
    public void MoveTo()
    {

        if (transform.position == final)
        {

            texty.text = "Finished!";
            pathNodes = null;
        }

        if (pathNodes == null)
        {
            print("No pathnodes");
            return;
        }
        else if (pathNodes != null)

        {
            CurrentNode.walkable = true;
            transform.position = pathNodes[0].nodeVector;
        }


        /*
        int current = 0;
        while (current < pathNodes.Count - 1)
        {
            Vector3 start = pathNodes[current].nodeVector;
            Vector3 end = pathNodes[current + 1].nodeVector;
            if (current == 0)
            {
                Debug.DrawLine(transform.position, end, Color.red);
            }
            else
            {
                Debug.DrawLine(start, end, Color.red);
            }
            current++;
        }
        */
    }
    void Update()
    {
        if (mapmaker.finished)
        {
            CurrentNode = mapmaker.NodefromWorldPosition(transform.position);
            CurrentNode.walkable = false;
            CurrentNode.currentObj = this.gameObject;

            if (mapmaker.targetNode != null)
            {
                final = mapmaker.targetNode.nodeVector;
            }
        }


    }
    public void Randomize()
    {
        int x = Random.Range(0, 5);
        int y = Random.Range(0, 5);



        if (x == 4 && y == y || x == 2 && y == 4 || x == 2 && y == 3 || x == 2 && y == 2 || x == 2 && y == 1)
        {
            transform.position = mapmaker.grid[Random.Range(0, 1), Random.Range(0, 5)].nodeVector;
            texty.text = "";
        }
        else
        {
            print(x + " " + y);
            print(mapmaker.grid[x, y].nodeVector);
            transform.position = mapmaker.grid[x, y].nodeVector;
            texty.text = "";
        }

    }

}
