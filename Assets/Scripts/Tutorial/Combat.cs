using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Combat : NetworkBehaviour
{
    public const int maxHP = 100;
    public bool destroyOnDeathl;
    [SyncVar]
    public int HP = maxHP;

    public void TakeDmg(int dmg)
    {
        if (!isServer)
            return;

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
                RpcRespawn();
            }

        }
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if(isLocalPlayer)
        {
            transform.position = Vector3.zero;
        }
    }
}
