using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCollision : MonoBehaviour
{
    public GameObject youWinText;
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        youWinText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            youWinText.SetActive(true);
        }
        StartCoroutine(Countdown());
    }
        
    IEnumerator Countdown ()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(0);
    }
}
