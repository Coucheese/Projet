using System;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class Gun : MonoBehaviour
{
    public Transform shooter;

    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    public PhotonView photonView;

    public int munition = 13;
    public int chargeur = 65;
    public TextMeshProUGUI munitionTxt;

    public ParticleSystem shootEffect;

    void Start()
    {
        munitionTxt.text = munition.ToString() + " / " + chargeur;

        if (!photonView.IsMine && GetComponent<Gun>() != null)
        {
            Destroy(GetComponent<Gun>());
        }
    }


    void Update()
    {
        if (photonView.IsMine)
        {
            GetInputs();
        }
        
    }

    void GetInputs()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (munition > 0 && chargeur > 0)
            {
                Shoot();
                munition -= 1;
                munitionTxt.text = munition.ToString() + " / " + chargeur;
            }
        }

        if (Input.GetKey(KeyCode.R) && munition != 13 && chargeur > 0)
        {
            Reload();
        }

    }


    void Reload()
    {
        if (chargeur >= 13 - munition)
        {
            chargeur -= (13 - munition);
            munition = 13;
            munitionTxt.text = munition.ToString() + " / " + chargeur;
        }
        else
        {
            munition = chargeur;
            chargeur = 0;            
            munitionTxt.text = munition.ToString() + " / " + chargeur;
        }
    }


    void Shoot()
    {
        shootEffect.Play();

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            hit.collider.gameObject.GetComponent<Target>()?.TakeDamage(damage, shooter);
            hit.collider.gameObject.GetComponent<TargetHuman>()?.TakeDamage(damage, shooter);



            Target target = hit.transform.GetComponent<Target>();
            TargetHuman targetHuman = hit.transform.GetComponent<TargetHuman>();

            /*if (target != null)
            {
                target.TakeDammage(dammage);
                Debug.Log("La cible a pris des dégats");
            }

            if (targetHuman != null)
            {
                targetHuman.TakeDamage(7);
                Debug.Log("L'ennemi a pris des dégats");
            }*/
        }
    }
}
