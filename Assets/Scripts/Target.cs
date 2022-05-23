using UnityEngine;
using Photon.Pun;
using TMPro;
using System;

public class Target : MonoBehaviourPun
{
    public GameObject FloatingTextPrefab;

    public PhotonView phothonView;
    public TextMeshPro PV;


    public float health = 50f;

    public void TakeDammage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
        PV.text = health + " / 50";
    }


    void ShowFloatingText(Transform shooter, float damageTaken)
    {
        Debug.Log("Je viens de instantier un gars qui s'apelle floating text");
        GameObject Text = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        Text.GetComponent<TextMesh>().text ="" + damageTaken;
        Text.transform.LookAt(shooter);
        Text.transform.Rotate(Vector3.up,180);
    }

    void Die()
    {
        Debug.Log("Je me détruis");
        PhotonNetwork.Destroy(gameObject);
    }

    public void TakeDamage(float damage, Transform shooter)
    {
        if (FloatingTextPrefab != null)
        {
            ShowFloatingText(shooter, damage);
        }
        phothonView.RPC("RPC_TakeDamage", RpcTarget.All, damage);
        PV.text = health + " / 50";                                          Debug.Log("1: " + health);
    }

    [PunRPC]
    void RPC_TakeDamage(float damage)
    {
        if (!phothonView.IsMine)
        {
            TakeDammage(damage);                                        Debug.Log("2: " + health);
            Debug.Log(phothonView);
            return;
        }

        
        health -= damage;
        if (health <= 0f)
        {
            Die();
        }
        PV.text = health + " / 50";                                          Debug.Log("3: " + health);
        
        Debug.Log("Took damage: " + damage + ". I have now: " + health);
    }
}
