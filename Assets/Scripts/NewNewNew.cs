using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NewNewNew : MonoBehaviourPunCallbacks
{

    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;


    public Transform PlayerCamera;
    public Rigidbody PlayerBody;

    public LayerMask GroundMask;
    public Transform GroundCheck;

    public float Speed;
    public float Sensitivity;
    public float JumpForce;
    private float xRot;

    private float InitialSpeed;



    void Start()
    {

        InitialSpeed = Speed;
        
        if (!photonView.IsMine && GetComponent<NewNewNew>() != null)
        {
            Destroy(GetComponent<NewNewNew>());
        }

        Cursor.visible = false;
    }

    void Update()
    {
        // Horizontal --> -1 ou 1   si t'appuies sur 'q' ou 'd'
        // Vertical   --> -1 ou 1   si t'appuies sur 'z' ou 's'
        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));


        if (photonView.IsMine)
        {
            MovePlayer();
            MoverPlayerCamera();
        }
        
    }


    private void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * Speed;
        PlayerBody.velocity = new Vector3(MoveVector.x, PlayerBody.velocity.y, MoveVector.z);


        // GetKetDown = V   seulement à la frame où ca commence
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log(Physics.CheckSphere(GroundCheck.position, 0.4f, GroundMask));
            if(Physics.CheckSphere(GroundCheck.position, 0.4f, GroundMask))
            {
                PlayerBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            }
        }


        // GetKey = V/F   toute la durée de l'appui
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Ok");
            Speed = InitialSpeed / 2;
        }
        else
        {
            Speed = InitialSpeed;
        }

    }


    private void MoverPlayerCamera()
    {
        xRot -= PlayerMouseInput.y * Sensitivity;

        transform.Rotate(0f, PlayerMouseInput.x * Sensitivity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }

    
}
