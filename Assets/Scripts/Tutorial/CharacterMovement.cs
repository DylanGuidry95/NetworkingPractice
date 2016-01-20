using UnityEngine;

using System.Collections;

public class CharacterMovement : MonoBehaviour
{
    public GameObject bulletPrefab;
    

    void OnConnectedToServer()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    void OnDisconnectedFromServer()
    {
        GameObject[] g = FindObjectsOfType<GameObject>();
        for (int i = 0; i < g.Length; i++)
        {
            if (g[i].GetComponent<CharacterMovement>())
            {
                Destroy(g[i].gameObject);
            }
        }
    }

    void CmdFire()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.forward * 1.2f, Quaternion.identity) as GameObject;

        bullet.GetComponent<Rigidbody>().velocity = transform.forward * 4;

        //NetworkServer.Spawn(bullet);

        Destroy(bullet, 2.0f);
    }

    // Update is called once per frame
    void Update ()
    {
        if (GetComponent<NetworkView>().isMine == true)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            float rot = Input.GetAxis("Rotation");

            transform.Translate(x / 10, 0, z / 10);
            if (rot != 0)
                transform.Rotate(Vector3.up, rot * 2);

            if (Input.GetKeyDown(KeyCode.Joystick1Button4))
                CmdFire();
        }
	}
}
