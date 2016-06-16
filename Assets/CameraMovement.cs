using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    public float speed = 500.0F;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(-Input.GetAxis("Horizontal") * speed, -Input.GetAxis("Vertical") *speed, 0));

        if (Input.GetAxis("Mouse ScrollWheel") > 0) 
        {
            Camera.main.orthographicSize = Mathf.Min(Camera.main.orthographicSize - 1, 20);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0) 
        {
            Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize - 1, 20);
        }

    }
}
