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
        PhotonNetwork.Destroy(gameObject);
    }
}
