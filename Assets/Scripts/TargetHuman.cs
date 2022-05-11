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


    public void TakeHumanDammage(float amount)
    {
        if(health > 0)
        { 
            health -= amount;
            Debug.Log(this.name + "  : " + health + " / 50");
            PV.text = health + " / 50";

        }else{
            
            Die();
        }

    }

    void Die()
    {
        Debug.Log(this.name + " est mort");
        //PhotonNetwork.Disconnect();
        //SceneManager.LoadScene("Loading");
    }
}
