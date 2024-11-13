using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tp : MonoBehaviour
{
    public GameObject mainPart, credPainel;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            mainPart.SetActive(true);
            credPainel.SetActive(false);
        } 
    }

    public void Teleport(string tp)
    {
        SceneManager.LoadScene(tp);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
