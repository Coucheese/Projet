using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
using Photon.Pun;


/*
               N'EST PLUS UTILISE

*/

public class MouseLook : MonoBehaviourPunCallbacks
{
    public float mouseSensitivity = 100f;       // Sensibilité de la caméra par rapport à la souris

    public Transform playerBody;

    float xRotation = 0f;

    //PhotonView view;

    void Start()
    {
        //view = GetComponent<PhotonView>();
        Cursor.lockState = CursorLockMode.Locked;  // Le curseur est lock
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;  // mouseX = position de la souris sur l'axe x * la sensibilité de la cam
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90, 90);                                // On limite la rotation à -90° 

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);      //Quaternion concerne la rotation dans Unity
            playerBody.Rotate(Vector3.up * mouseX);                             //Le corps du perso tourne horizontalement (sur l'axe vertical, up) par rapport à la position de la souris

        }
    }
}
