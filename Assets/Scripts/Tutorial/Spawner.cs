using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Spawner : NetworkBehaviour
{
    public GameObject enemyPrefab;
    public int numSpawns;

    public override void OnStartServer()
    {
        for(int i = 0; i < numSpawns; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-8f, 8f), .2f, Random.Range(-8f, 8f));
            Quaternion rotation = Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));

            GameObject enemy = Instantiate(enemyPrefab, pos, rotation) as GameObject;
            NetworkServer.Spawn(enemy);
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
