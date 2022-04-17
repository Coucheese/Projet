using UnityEngine;
using TMPro;
using System.Collections;

public class Loading : MonoBehaviour
{

    public TextMeshProUGUI loading;

    private void Start() => StartCoroutine(Wait());

    IEnumerator Wait()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            loading.text = "Loading.";
            Debug.Log("Loading.");

            yield return new WaitForSeconds(0.5f);
            loading.text = "Loading..";
            Debug.Log("Loading..");

            yield return new WaitForSeconds(0.5f);
            loading.text = "Loading...";
            Debug.Log("Loading...");
        }

        }


}
