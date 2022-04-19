using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class PlayerMovement : MonoBehaviourPunCallbacks
{

    public CharacterController controller;


    //Mouvements
    public float speed = 13f;
    public float gravityForce = -9.81f;
    public float jumpHeight = 3f;
    Vector3 velocity;



    // Couche du sol + hauteur min
    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    // Ballon
    public GameObject ball;
    public float ballDistance;
    public LayerMask ballMask;


    void Update()
    {
        if (photonView.IsMine)
        {
            moves();       
        }
        
        
    }


    public void moves()
    {
        float x = Input.GetAxis("Horizontal");      // x=1 si on appuie sur d et x=-1 si on appuie sur q
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; //On crée un vecteur 3D. .right c la ligne rouge et forward la bleue    
        transform.Translate(move * speed * Time.deltaTime);
        // ProcessInput();
        Debug.Log("aaaaaaaaaaaaaaa");
    }


    public void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            PhotonNetwork.Disconnect();
            SceneManager.LoadScene("Loading");
        }

        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");      // x=1 si on appuie sur d et x=-1 si on appuie sur q
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; //On crée un vecteur 3D. .right c la ligne rouge et forward la bleue    

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 7f;
        }
        else { speed = 13f; }


        //controller.Move(move * speed * Time.deltaTime);
        transform.Translate(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityForce);
        }

        velocity.y += gravityForce * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        //transform.Translate(velocity * Time.deltaTime);

    }
}


