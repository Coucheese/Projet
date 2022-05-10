using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float dammage = 10f;
    public float range = 100f;

    public Camera fpsCam;

    public ParticleSystem shootEffect;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {

            Shoot();
        }
    }

    void Shoot()
    {
        shootEffect.Play();

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            TargetHuman targetHuman = hit.transform.GetComponent<TargetHuman>();

            if (target != null)
            {
                target.TakeDammage(dammage);
                Debug.Log("La cible a pris des dégats");
            }

            if (targetHuman != null)
            {
                targetHuman.TakeHumanDammage(dammage);
                Debug.Log("L'ennemi a pris des dégats");
            }
        }
    }
}
