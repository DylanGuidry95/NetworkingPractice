using UnityEngine;

using System.Collections;

public class CharacterMovement : MonoBehaviour
{
    public GameObject bulletPrefab;
    

    void Start()
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

    void Fire()
    {
            GameObject bullet = Network.Instantiate(bulletPrefab, transform.position + transform.forward * 1.2f, Quaternion.identity, 0) as GameObject;

            bullet.GetComponent<Rigidbody>().velocity = transform.forward * 4;

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

            if (Input.GetKeyDown(KeyCode.Space))
                Fire();
        }
	}
}
