using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour
{
    public float timer = 0;
   
	void OnCollisionEnter(Collision a)
    {
            GameObject hit = a.gameObject;
            Combat hitCombat = hit.GetComponent<Combat>();

        if(GetComponent<NetworkView>().isMine == true)
            if (hitCombat != null)
            {
                hitCombat.TakeDmg(10);
                Network.Destroy(this.gameObject);
            }
    }

    void Update()
    {
        timer += Time.deltaTime;
    }
}
