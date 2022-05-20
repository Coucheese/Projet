using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovementNew : MonoBehaviourPunCallbacks
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
        string id = "Player n�" + PhotonNetwork.LocalPlayer.ActorNumber + PhotonNetwork.LocalPlayer.UserId;
        this.name = id;

        InitialSpeed = Speed;
        
        if (!photonView.IsMine && GetComponent<PlayerMovementNew>() != null)
        {
            Destroy(GetComponent<PlayerMovementNew>());
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
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


        // GetKetDown = V   seulement � la frame o� ca commence
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log(Physics.CheckSphere(GroundCheck.position, 0.4f, GroundMask));
            if(Physics.CheckSphere(GroundCheck.position, 0.4f, GroundMask))
            {
                PlayerBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            }
        }


        // GetKey = V/F   toute la dur�e de l'appui
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Speed = InitialSpeed / 2;
        }
        else
        {
            Speed = InitialSpeed;
        }




        if (Input.GetKeyDown(KeyCode.Q))
        {
            this.transform.GetComponent<TargetHuman>().TakeDamage(10, transform);
        }

    }


    private void MoverPlayerCamera()
    {
        xRot -= PlayerMouseInput.y * Sensitivity;
        xRot = Mathf.Clamp(xRot, -90, 90);

        transform.Rotate(0f, PlayerMouseInput.x * Sensitivity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }

    /*public void TakeDamage(float damage)
    {
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
    }*/
}
