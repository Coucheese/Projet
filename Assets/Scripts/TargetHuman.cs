using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;
using System;

public class TargetHuman : MonoBehaviour
{
    public float health = 50f;
    public TextMeshProUGUI PV;

    public PhotonView photonView;


    /*public void TakeHumanDammage(float amount)
    {
        if(health > 0)
        { 
            health -= amount;
            Debug.Log(this.name + "  : " + health + " / 50");
            PV.text = health + " / 50";

        }else{
            
            Die();
        }

    }*/


    public void TakeDammage(float damage)
    {
        if(health > 0)
        {
            health -= damage;
            Debug.Log(this.name + "  : " + health + " / 50");
            PV.text = health + " / 50";
        }

        if(health ==0){ Die(); }

        Debug.Log("Took Damage: " + damage);
        photonView.RPC("RPC_TakeDamage", RpcTarget.AllBuffered, damage);
    }

    public void TakeDamage(float damage)
    {
        photonView.RPC("RPC_SyncDamage", RpcTarget.AllBuffered, damage);
        if (health == 0) { Die(); }
        PV.text = health + " / 50";
    }

    [PunRPC]
    void RPC_SyncDamage(float damage)
    {
        if (!photonView.IsMine)
        {
            return;
        }

        health -= damage;
        if(health<= 0f)
        {
            Die();
        }
        Debug.Log("La vie d'oim jcrois ca marche tema : " + damage);
    }

    void Die()
    {
        Debug.Log(this.name + " est mort");
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("Loading");
    }

}
