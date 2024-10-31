using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject boss;

    public GameObject Screen;

    public GameManager gameManager;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (boss == null)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Screen.SetActive(true);
            FirstPersonController.instance.enabled = false;
            gameManager.enabled = false;
        }
    }
}
