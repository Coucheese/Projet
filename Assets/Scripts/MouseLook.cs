using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;       // Sensibilit� de la cam�ra par rapport � la souris

    public Transform playerBody;

    float xRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  // Le curseur est lock
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;  // mouseX = position de la souris sur l'axe x * la sensibilit� de la cam
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);                                // On limite la rotation � -90� 

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);      //Quaternion concerne la rotation dans Unity
        playerBody.Rotate(Vector3.up * mouseX);                             //Le corps du perso tourne horizontalement (sur l'axe vertical, up) par rapport � la position de la souris

    }
}
