using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {
    public AttackScript targetAttack;
    public BuildingScrip buildingscrip;
    public int treeNum;
    PathFinding pathfinder;
    MapMaker mapmaker;
    

    Vector3 mainPosition;
    Vector3 targetPosition;

    public int unitHealth;

    float xDif;
    float zDif;
	// Use this for initialization
	void Start () {
        unitHealth = 2;
        pathfinder = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PathFinding>();
        mapmaker =   GameObject.FindGameObjectWithTag("GameManager").GetComponent<MapMaker>();
    }
	
	// Update is called once per frame
	void Update () {
        mainPosition = transform.position;

        xDif = targetPosition.x - mainPosition.x;
        zDif = targetPosition.z - mainPosition.z;

        if(unitHealth == 0)
        {
            buildingscrip.wood += treeNum;
            Destroy(gameObject);
        }

        

	}
    public void Attack()        
    {
        if(xDif <= 2 && xDif >=-2 && zDif <=2 && zDif>=-2) 
        {
            targetAttack.unitHealth--;             
        }
        else
        {
            print("Too far!");
        }
    }
}
