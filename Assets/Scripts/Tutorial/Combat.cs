using UnityEngine;
using System.Collections;


public class Combat : MonoBehaviour
{
    public const int maxHP = 100;
    public bool destroyOnDeathl;

    public int HP = maxHP;

    public void TakeDmg(int dmg)
    {


        HP -= dmg;
        if(HP <= 0)
        {
            if(destroyOnDeathl)
            {
                Destroy(gameObject);
            }
            else
            {
                HP = maxHP;
                //RpcRespawn();
            }

        }
    }


    //void RpcRespawn()
    //{
    //    if(isLocalPlayer)
    //    {
    //        transform.position = Vector3.zero;
    //    }
    //}
}
