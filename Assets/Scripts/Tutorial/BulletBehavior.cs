using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour
{
    public float timer = 0;

    /// <summary>
    /// When bullet comes into collision with any object this function will be called. If the object the bullet has come into collision with 
    /// has the Combat script attached to it the TakeDmg function from the combat script is called and the bullet is destroyed.  
    /// </summary>
    /// <param name="a"></param>
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

    /// <summary>
    /// Runs the timer to check how long the bullet has been active. 
    /// </summary>
    void Update()
    {
        timer += Time.deltaTime;
    }
}
