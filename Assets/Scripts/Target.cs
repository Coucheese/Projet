using UnityEngine;
using Photon.Pun;
using TMPro;

public class Target : MonoBehaviour
{

    public PhotonView phothonView;
    public TextMeshPro PV;


    public float health = 50f;

    public void TakeDammage(float amount)
    {
        health -= amount;
        Debug.Log(health);
        PV.text = health + " / 50";
        if (health <= 0f)
        {
            Die();
        }

       //phothonView.RPC("TakeDamage", RpcTarget.All, health);
    }

    

    void Die()
    {
        Debug.Log("Je me détruis");
        PhotonNetwork.Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        phothonView.RPC("RPC_TakeDamage", RpcTarget.AllBuffered, damage);
    }

    [PunRPC]
    void RPC_TakeDamage(float damage)
    {
        if (!phothonView.IsMine)
            return;

        TakeDammage(damage);
        PV.text = health + " / 50";
        Debug.Log("took damage: " + health);
    }
    
    /*[PunRPC]    
    public void TakeDamage(int someValue) {
        health = someValue;
        Debug.Log("La vie du pacé orange: " + health);
    }*/
}
