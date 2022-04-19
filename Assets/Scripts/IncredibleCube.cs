using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IncredibleCube : MonoBehaviour
{
    //Vector3 YAxe = new Vector3(0, 1, 0);

    public float rotationSpeed;

    private void Start() => StartCoroutine(Wait());

    IEnumerator Wait()
    {
        while (true)
        {
            transform.Rotate(Vector3.up * rotationSpeed);
            yield return new WaitForEndOfFrame();
        }

    }

    private void OnTriggerEnter(Collider  other)
    {
        Debug.Log("AAAAAAAAAAAAAAAAh je suce");
        //SceneManager.LoadScene("FPS");
    }
}
