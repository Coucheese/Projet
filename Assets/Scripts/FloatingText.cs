using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float DestroyTime = 1;

    // Si c'est un headshot qui est l�ch� on devrait en faire un + gros, couleur diff�rente + animations != en mode tremblements
    public Vector3 Offset = new Vector3(0, 0.6f, 0);
    public Vector3 RandomizeIntensity = new Vector3(0.5f, 0, 0);


    void Start()
    {
        Destroy(gameObject, DestroyTime);
        
        transform.localPosition += Offset;
        transform.localPosition += new Vector3(Random.Range(-RandomizeIntensity.x, RandomizeIntensity.x),
            Random.Range(-RandomizeIntensity.y, RandomizeIntensity.y),
            Random.Range(-RandomizeIntensity.z, RandomizeIntensity.z));
    }

}
