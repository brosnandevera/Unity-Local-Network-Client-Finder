using UnityEngine;
using System.Collections;

public class CubeMover : MonoBehaviour {

	// Use this for initialization
    public int testVal = 0;
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
            Debug.Log("Move Right");
            transform.position = new Vector3(transform.position.x + 0.05f, transform.position.y, transform.position.z);
        }
       
	}

    public void OnSerializeNetworkView(NetworkMessageInfo info, BitStream stream)
    {
        if (stream.isWriting)
        {
           float val =  testVal;
           stream.Serialize(ref val);
           
        }
        else
        {
            //reading
            float val2 = 0;
            stream.Serialize(ref val2);
            Debug.Log("Lol "+ testVal);
        }
    }


}
