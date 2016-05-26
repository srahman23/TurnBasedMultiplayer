using UnityEngine;
using System.Collections.Generic;
public enum TileType
{
    Ground, Water,
}
public class MapMaker : MonoBehaviour
{

    public GameObject[] floortype;
    public TileType[][] tiles;
    public GameObject player;
    public Node playerNode;
    public List<Node> path;
    public bool finished = false;
    public Node[,] grid;
    Vector3 position;

    public int mapHeight;
    public int mapLength;
    
    PathFinding pathfinding;
    Lakes[] lakes; 
    
    void Awake()
    {
        pathfinding = GetComponent<PathFinding>();

    }
    // Use this for initialization
    void Start()
    {
        AssignGrid();
        CreatePathfindingMap();
        GenerateLakes();
        CreateGrid();
        GetNeighbours();
        finished = true;
    }
    // Update is called once per frame
    void Update()
    {
        playerNode = NodefromWorldPosition(player.transform.position);
    }
    void AssignGrid()
    {
        tiles = new TileType[mapLength][];

        for (int i = 0; i < mapHeight; i++)
        {
            tiles[i] = new TileType[mapHeight];

        }
        //Assigns the tiles array to the specified length and width.
    }
    void GenerateLakes()
    {
        /*lakes = new Lakes[1];
        lakes[0] = new Lakes();
        lakes[0].SetUpLakes(1, 0, 3 , 3);

        for(int x = 0; x<lakes[0].lakeLength; x++)
        {
            int xCoord = lakes[0].xPos +x;

            for(int z = 0; z<lakes[0].lakeHeight; z++)
            {
                int zCoord = lakes[0].zPos + z;
                grid[xCoord, zCoord].walkable = false;
            }
        }
        */
        grid[2, 4].walkable = false;
        grid[2, 3].walkable = false;
        grid[2, 2].walkable = false;
        grid[2, 1].walkable = false; 
        }
    void CreatePathfindingMap()
    {
        grid = new Node[mapLength, mapHeight];
        Vector3 origin = transform.position;
        for (int x = 0; x < mapLength; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                Vector3 NodePosition = new Vector3((x * 2f), 0, (y * 2f));

                grid[x, y] = new Node(true, NodePosition);
                grid[x, y].xPos = x;
                grid[x, y].yPos = y;
                //Sets the position of each node within the grid system. MAKE SURE IT IS THE SAME AS THE TILE CREATION.
                                  
                          
            }
        }
        foreach(Node n in grid)
        {
            if(path!= null)
            {
                if (path.Contains(n))
                {
                    n.walkable = false;
                    
                }
            }
        }
    }
    //Method basically takes the current vector3 position of an object and transform that into a grid location. 
    public Node NodefromWorldPosition(Vector3 position)
    {
        int x = Mathf.RoundToInt(position.x/2);
        int y = Mathf.RoundToInt(position.z/2);
        return grid[x, y];
    }
    void CreateGrid()
    {

        for (int i = 0; i < tiles.Length; i++)
        {
            for (int j = 0; j < tiles[i].Length; j++)
            {
                /*
                  This chunk basically sets the position of the map and makes sure that no tiles overlap.
                  2f = Length of each tile. 
                  Subtracting mapLength/mapHeigh= makes sure that the center of the map coincides with unity's center of map for ease of use.                
                */
                float x = (float)i;
                float z = (float)j;
                float xOffset =  (x * 2f);
                float zOffset = (z * 2f);
                Vector3 position = new Vector3(xOffset, 0, zOffset);

                if (grid[i,j].walkable == true)
                {
                    GameObject hexTile = Instantiate(floortype[0], position, Quaternion.AngleAxis(90, Vector3.left)) as GameObject;
                    hexTile.transform.parent = this.transform;
                    hexTile.name = "Hextile" + i + j;
                }
                else if (grid[i,j].walkable == false)
                {
                    GameObject hexTile = Instantiate(floortype[1], position, Quaternion.AngleAxis(90, Vector3.left)) as GameObject;
                    hexTile.transform.parent = this.transform;
                    hexTile.name = "Hextile" + i + j;
                }
            }
        }
    }
    public List<Node> neighbours = new List<Node>();

    public void GetNeighbours()
    {    
    //Adds all the neighbours within the bounds of the grid graph.        
        for(int x=0; x<mapLength; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                if(x >0 && y > 0)
                {
                    grid[x, y].graphNode.Add(grid[x - 1, y-1]);
                }                
                if(x < mapLength - 1 && y > 0)
                {
                    grid[x, y].graphNode.Add(grid[x + 1, y - 1]);
                }
                if (x < mapLength - 1 && y < mapLength - 1)
                {
                    grid[x, y].graphNode.Add(grid[x + 1, y + 1]);
                }
                if (x > 0 && y < mapLength - 1)
                {
                    grid[x, y].graphNode.Add(grid[x - 1, y + 1]);
                }
                    if (x > 0)
                    {
                        grid[x, y].graphNode.Add(grid[x - 1, y]);
                    }
                    if (x < mapLength - 1)
                    {
                        grid[x, y].graphNode.Add(grid[x + 1, y]);

                    }
                    if (y > 0)
                    {
                        grid[x, y].graphNode.Add(grid[x, y - 1]);
                    }
                    if (y < mapHeight - 1)
                    {
                        grid[x, y].graphNode.Add(grid[x, y + 1]);
                    }
              
            }
        }
    }
    
}
