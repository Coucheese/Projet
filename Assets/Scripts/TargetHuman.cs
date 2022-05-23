using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;
using System;

public class TargetHuman : MonoBehaviour
{
    public GameObject FloatingTextPrefab;

    public float health = 50f;
    public TextMeshProUGUI PV;

    public PhotonView photonView;


    void ShowFloatingText(Transform shooter, float damageTaken)
    {
        Debug.Log("Je viens de instantier un gars qui s'apelle floating text");
        GameObject Text = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        Text.GetComponent<TextMesh>().text = "-" + damageTaken;
        Text.transform.LookAt(shooter);
        Text.transform.Rotate(Vector3.up, 180);
    }

    public void TakeDammage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Die();
        }
        PV.text = health + " / 50";

        Debug.Log("Took Damage: " + damage);
    }

    public void TakeDamage(float damage, Transform shooter)
    {
        if (FloatingTextPrefab != null)
        {
            ShowFloatingText(shooter, damage);
        }
        photonView.RPC("RPC_SyncDamage", RpcTarget.All, damage);
        if (health == 0) { Die(); }
        PV.text = health + " / 50";
    }

    [PunRPC]
    void RPC_SyncDamage(float damage)
    {
        if (!photonView.IsMine)
        {
            //TakeDammage(damage);
            return;
        }

        health -= damage;
        if(health<= 0f)
        {
            Die();
        }
        PV.text = health + " / 50";
        Debug.Log("La vie d'oim jcrois ca marche tema : " + damage);
    }

    void Die()
    {
        Debug.Log(this.name + " est mort");
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("Loading");
    }

}
