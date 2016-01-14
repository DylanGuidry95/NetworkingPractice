using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CharacterMovement : NetworkBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!isLocalPlayer)
            return;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.Translate(x / 5,0,z / 5);
	}
}
