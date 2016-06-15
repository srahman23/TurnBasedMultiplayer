using UnityEngine;
using System.Collections;

public class ObjectPlacement : MonoBehaviour {
    public MapMaker mapmaker;
    public int buildingNum;

    Transform currentBuilding;
    private Node currentBuildingNode;
    Camera camera;
    GameObject building;

    

    bool placeOn;
	// Use this for initialization
	void Start () {
        camera = this.GetComponent<Camera>();
        placeOn = false;
	}
	
	// Update is called once per frame
	void Update () {
 

        if (currentBuilding != null)
        {
            Vector3 m = Input.mousePosition;
            Vector3 p = camera.ScreenToWorldPoint(m);
            currentBuilding.position = new Vector3(p.x, 0, p.z);
            currentBuildingNode = mapmaker.NodefromWorldPosition(currentBuilding.position);
            currentBuildingNode.walkable = false;

            switch (buildingNum)
            {
                case 0:
                    break;
                case 1:
                    mapmaker.target = currentBuilding.gameObject;
                    
                    break;
                default:
                    break;

            }

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            placeOn ^=true;//Switches from true to false. 
        }

        if (Input.GetButtonDown("Fire1" ) && placeOn == true)
        {
            
            Instantiate(building, currentBuildingNode.nodeVector, Quaternion.identity);
            mapmaker.targetPlaced = true; 
            

        }
    }
    public void SetBuilding(GameObject obj)
    {
        building = obj;
        currentBuilding = ((GameObject)Instantiate(building)).transform;        
    }
   
}
