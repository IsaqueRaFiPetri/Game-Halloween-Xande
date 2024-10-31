using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tp : MonoBehaviour
{
    public void Teleport(string tp)
    {
        SceneManager.LoadScene(tp);
    }

    public void Quit()
    {
        Application.Quit();
    }
}