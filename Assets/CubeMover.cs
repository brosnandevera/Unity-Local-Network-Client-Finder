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

    public void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    {
        Debug.Log("steaming!");
        if (stream.isWriting)
        {
           //float val =  testVal;
           stream.Serialize(ref testVal);
           
        }
        else
        {
            //reading
            //float val2 = 0;
            stream.Serialize(ref testVal);
            Debug.Log("Lol " + testVal);
        }
    }


}
