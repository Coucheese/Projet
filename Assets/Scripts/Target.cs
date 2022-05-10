using UnityEngine;
using Photon.Pun;

public class Target : MonoBehaviour
{
    public float health = 50f;

    public void TakeDammage(float amount)
    {
        health -= amount;
        Debug.Log(health);
        if(health <= 0f)
        {
            Die();
        }
       
    }

    void Die()
    {
        Debug.Log("Je me détruis");
        PhotonNetwork.Destroy(gameObject);
    }
}
