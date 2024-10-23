using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenDead : MonoBehaviour
{

    private void Update()
    {
        DeadPlayer();
    }

    public void DeadPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
