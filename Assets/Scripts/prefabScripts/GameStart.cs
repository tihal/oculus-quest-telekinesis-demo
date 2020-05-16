using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{

    bool hasStarted = false;
    

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.name == "MenuObject" && hasStarted == false)
        {
            hasStarted = true;
            FindObjectOfType<OVRScreenFade>().FadeOut();
            StartCoroutine(waiter());
        }
    }


    IEnumerator waiter()
    {
        //Wait for 10 seconds
        yield return new WaitForSeconds(5);
        ReturnToMenu();
    }

    void ReturnToMenu()
    {
        SceneManager.LoadScene(1);
    }
}
