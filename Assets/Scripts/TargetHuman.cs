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
        Debug.Log("Ah, I took dammage");
        health -= amount;
        if(health <= 0f)
        {
            PV.text = health.ToString().Insert(1, " / 50");
            Die();
        }
    }

    void Die()
    {
        Debug.Log("                                   Je meurs");
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("Loading");
    }
}
