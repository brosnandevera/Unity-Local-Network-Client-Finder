using UnityEngine;
using System.Collections;

public class CubeMover : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Move Left");
            transform.position = new Vector3(transform.position.x - 0.05f, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Move Left");
            transform.position = new Vector3(transform.position.x + 0.05f, transform.position.y, transform.position.z);
        }
       
	}
}
