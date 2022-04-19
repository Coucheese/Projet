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

    

    void Start()
    {
        if (!photonView.IsMine && GetComponent<NewNewNew>() != null)
        {
            Destroy(GetComponent<NewNewNew>());
        }
    }

    void Update()
    {
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(Physics.CheckSphere(GroundCheck.position, 0.4f, GroundMask));
            if(Physics.CheckSphere(GroundCheck.position, 0.4f, GroundMask))
            {
                PlayerBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
                Debug.Log("Ca marche oas");
            }
        }
    }


    private void MoverPlayerCamera()
    {
        xRot -= PlayerMouseInput.y * Sensitivity;

        transform.Rotate(0f, PlayerMouseInput.x * Sensitivity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }

    
}
