using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject shooterPlayer;
    public float shootPower = 3f;

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {
        Vector3 shootDirection = Vector3.Normalize(shooterPlayer.transform.position - transform.position);
        Vector3 shoot = shootDirection * shootPower;
        GetComponent<Rigidbody>().AddForce(shoot, ForceMode.Impulse);
    }
}
