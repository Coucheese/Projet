using UnityEngine;
using Photon.Pun;

public class Target : MonoBehaviour
{

    public PhotonView phothonView;
    

    public float health = 50f;

    public void TakeDammage(float amount)
    {
        health -= amount;
        Debug.Log(health);
        if(health <= 0f)
        {
            Die();
        }

       // phothonView.RPC("SyncValues", RpcTarget.AllBuffered, health);
    }

    void Die()
    {
        Debug.Log("Je me détruis");
        PhotonNetwork.Destroy(gameObject);
    }

    /*public void TakeDamage(float damage)
    {
        phothonView.RPC("RPC_TakeDamage", RpcTarget.AllBuffered, damage);
    }

    [PunRPC]
    void RPC_TakeDamage(float damage)
    {
        if (!phothonView.IsMine)
            return;

        Debug.Log("took damage: " + health);
    }*/
}
