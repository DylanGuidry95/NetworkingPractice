using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CharacterMovement : NetworkBehaviour
{
    public GameObject bulletPrefab;
	// Use this for initialization
	void Start () {
	
	}

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    [Command]
    void CmdFire()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.forward * 1.2f, Quaternion.identity) as GameObject;

        bullet.GetComponent<Rigidbody>().velocity = transform.forward * 4;

        NetworkServer.Spawn(bullet);

        Destroy(bullet, 2.0f);
    }

    // Update is called once per frame
    void Update ()
    {
        if (!isLocalPlayer)
            return;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        float rot = Input.GetAxis("Rotation");

        transform.Translate(x / 10,0,z / 10);
        if(rot != 0)
            transform.Rotate(Vector3.up, rot * 2);

        if (Input.GetKeyDown(KeyCode.Joystick1Button4))
            CmdFire();
	}
}
