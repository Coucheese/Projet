using UnityEngine;
using Photon.Pun;
using TMPro;
using System;

public class Target : MonoBehaviour
{
    public GameObject FloatingTextPrefab;

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
        /*if (FloatingTextPrefab != null)
        {
            ShowFloatingText();
        }*/
        

       //phothonView.RPC("TakeDamage", RpcTarget.All, health);
    }

 
    void ShowFloatingText(Transform shooter, float damageTaken)
    {
        Debug.Log("Je viens de instantier un gars qui s'apelle floating text");
        GameObject Text = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        Text.GetComponent<TextMesh>().text = "-" + damageTaken;
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
        phothonView.RPC("RPC_TakeDamage", RpcTarget.AllBuffered, damage);
        PV.text = health + " / 50";
    }

    [PunRPC]
    void RPC_TakeDamage(float damage)
    {
        if (!phothonView.IsMine)
        {
            PV.text = health + " / 50";
            return;
        }

        
        health -= damage;
        if (health <= 0f)
        {
            Die();
        }
        PV.text = health + " / 50";
        
        Debug.Log("Took damage: " + damage + ". I have now: " + health);
    }
}
