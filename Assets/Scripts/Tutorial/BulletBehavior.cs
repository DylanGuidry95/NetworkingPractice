using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour
{


	void OnCollisionEnter(Collision a)
    {
        GameObject hit = a.gameObject;
        ComboSystem hitCombat = hit.GetComponent<ComboSystem>();

        if(hitCombat != null)
        {
            hitCombat.TakeDmg(10);
            Destroy(gameObject);
        }
    }

}
