using UnityEngine;
using System.Collections;

public class ObjectPlacement : MonoBehaviour {
    public MapMaker mapmaker;
    ObjectMovement unitmovement;
    public AttackScript attackScript;


    Transform currentBuilding;
    private Node currentBuildingNode;
    Camera camera;
    GameObject building;

    

    bool placeOn = false;
    bool moveOn = false;
    bool selectOn = false;
	// Use this for initialization
	void Start () {
        camera = this.GetComponent<Camera>();
        
	}
	
	// Update is called once per frame
	void Update () {
 

        if (currentBuilding != null)
        {
            Vector3 m = Input.mousePosition;
            Vector3 p = camera.ScreenToWorldPoint(m);
            currentBuilding.position = new Vector3(p.x, 0, p.z);


        }
        if (Input.GetKeyDown(KeyCode.E))
        {            
            placeOn ^=true;//Switches from true to false.
            print("PLACE IS ON" + placeOn);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {            
            moveOn ^= true;
            print("MOVE IS ON" + moveOn);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            selectOn ^= true;
            print("SELECT IS ON" + selectOn);
        }
        if (Input.GetButtonDown("Fire1" ) && placeOn == true)
        {
            
            currentBuildingNode = mapmaker.NodefromWorldPosition(currentBuilding.position);
            currentBuildingNode.walkable = false;
            Instantiate(building, currentBuildingNode.nodeVector, Quaternion.identity);


        }
        else if (Input.GetButtonDown("Fire1") && moveOn == true)
        {
           
            currentBuildingNode = mapmaker.NodefromWorldPosition(currentBuilding.position);
            mapmaker.targetNode = currentBuildingNode;

            unitmovement.MoveTo();
        }
        else if (Input.GetButtonDown("Fire1") && selectOn == true)
        {
            Vector3 m = Input.mousePosition;
            Vector3 p = camera.ScreenToWorldPoint(m);
            currentBuilding.position = new Vector3(p.x, 0, p.z);
            currentBuildingNode = mapmaker.NodefromWorldPosition(currentBuilding.position);
            unitmovement = currentBuildingNode.currentObj.GetComponent<ObjectMovement>();
            //currentBuildingNode.currentObj = ;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(attackScript!= null)
            {
                attackScript.Attack();
            }
            
        }     
    }
    public void SetBuilding(GameObject obj)
    {
        building = obj;
        currentBuilding = ((GameObject)Instantiate(building)).transform;        
    }
   
}
