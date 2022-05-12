using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;

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


    public void TakeDamage(float damage)
    {
        if(health > 0)
        {
            health -= damage;
            Debug.Log(this.name + "  : " + health + " / 50");
            PV.text = health + " / 50";

        }
        else { Die(); }
        Debug.Log("Took Damage: " + damage);
        photonView.RPC("RPC_TakeDamage", RpcTarget.AllBuffered, damage);
    }

    [PunRPC]
    void RPC_TakeDamage(float damage)
    {
        if (!photonView.IsMine)
        {
            return;
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
