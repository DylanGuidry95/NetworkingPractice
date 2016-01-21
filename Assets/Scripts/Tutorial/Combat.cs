using UnityEngine;
using System.Collections;


public class Combat : MonoBehaviour
{
    public const int maxHP = 100;
    public bool destroyOnDeathl;

    public int HP = maxHP;

    /// <summary>
    /// Called in when a bullet comes into collision with an object with this script attached 
    /// and reduces its health based on the value of the argument passed into the function.
    /// </summary>
    /// <param name="dmg"></param>
    public void TakeDmg(int dmg)
    {
        if(GetComponent<NetworkView>().isMine == true)
        {
            HP -= dmg;
            if (HP <= 0)
            {
                if (destroyOnDeathl)
                {
                    Destroy(gameObject);
                }
                else
                {
                    HP = maxHP;
                    Respawn();
                }
            }
        }
    }

    /// <summary>
    /// If the object is not destroyed when its health has reached zero it will respawn at designated position in the game space.
    /// </summary>
    void Respawn()
    {
            transform.position = Vector3.zero;
    }
}
