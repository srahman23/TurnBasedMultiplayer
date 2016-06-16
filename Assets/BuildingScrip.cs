using UnityEngine;
using System.Collections;

public class BuildingScrip : MonoBehaviour {
    public GameObject Unit;
    Vector3 SpawnPosition = new Vector3(22, 0, 22);
    public int wood;
	// Update is called once per frame
    void Start()
    {
        wood = 0;
    }
	void Update () {
	    
	}
    public void SpawnUnit()
    {
        if(wood >= 100)
        {
            Instantiate(Unit, SpawnPosition, Quaternion.identity);
        }
        
    }
}
