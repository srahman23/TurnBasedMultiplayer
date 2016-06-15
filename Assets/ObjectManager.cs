using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour {
    public GameObject[] buildings;
    private ObjectPlacement objplacement;
	// Use this for initialization
	void Start () {
        objplacement = GetComponent<ObjectPlacement>();
        objplacement.SetBuilding(buildings[0]);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.B)){
            objplacement.SetBuilding(buildings[1]);
            objplacement.buildingNum = 1; 
        }
	}
}
