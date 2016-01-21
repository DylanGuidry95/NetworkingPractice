using UnityEngine;
using System.Collections;


public class Combat : MonoBehaviour
{
    public const int maxHP = 100;
    public bool destroyOnDeathl;

    public int HP = maxHP;

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


    void Respawn()
    {
            transform.position = Vector3.zero;
    }
}
