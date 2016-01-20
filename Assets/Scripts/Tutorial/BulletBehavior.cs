using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour
{


	void OnCollisionEnter(Collision a)
    {
        if(GetComponent<NetworkView>().isMine == true)
        {
            GameObject hit = a.gameObject;
            Combat hitCombat = hit.GetComponent<Combat>();

            if (hitCombat != null)
            {
                hitCombat.TakeDmg(10);
                Destroy(gameObject);
            }
        }
    }

}
