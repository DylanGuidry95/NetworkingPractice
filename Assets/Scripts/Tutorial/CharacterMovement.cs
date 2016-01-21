using UnityEngine;

using System.Collections;

public class CharacterMovement : MonoBehaviour
{
    public GameObject bulletPrefab;

    /// <summary>
    /// Sets the player’s color to red.
    /// </summary>
    void Start()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    /// <summary>
    /// Finds all gameobjects in the scene and deletes them when the serven disconnects.
    /// </summary>
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

    /// <summary>
    /// Shoots a bullet from the player's position.
    /// </summary>
    void Fire()
    {
            GameObject bullet = Network.Instantiate(bulletPrefab, transform.position + transform.forward * 1.2f, Quaternion.identity, 0) as GameObject;

            bullet.GetComponent<Rigidbody>().velocity = transform.forward * 4;
            
            if(bullet.GetComponent<BulletBehavior>().timer >= 2.0f)
                Network.Destroy(bullet);

    }

    // Update is called once per frame
    /// <summary>
    /// Takes user input and updates the player’s position and calls the fire function.
    /// </summary>
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
