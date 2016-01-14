using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerCharacter : NetworkBehaviour
{
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!isLocalPlayer)
            return;

        float x = Input.GetAxis("Horizontal") * 0.1f;

        transform.Translate(x, 0, 0);
	}
}
