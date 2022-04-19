using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncredibleCube : MonoBehaviour
{
    //Vector3 YAxe = new Vector3(0, 1, 0);

    public float rotationSpeed;

    private void Start() => StartCoroutine(Wait());

    IEnumerator Wait()
    {
        while (true)
        {
            transform.RotateAroundLocal(Vector3.up, rotationSpeed);
            yield return new WaitForEndOfFrame();
        }

    }
}
