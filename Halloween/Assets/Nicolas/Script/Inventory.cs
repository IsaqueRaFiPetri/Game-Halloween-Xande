using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    
    public GameObject[] arms = new GameObject[4];

    public bool slotLock, slotLock1;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            for (int i = 0; arms.Length > i; i++)
            {
                arms[i].SetActive(false);
            }
            arms[0].SetActive(true);

        }

        if (slotLock)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                for (int i = 0; arms.Length > i; i++)
                {
                    arms[i].SetActive(false);
                }
                arms[1].SetActive(true);
            }
        }

        if (slotLock1)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                for (int i = 0; arms.Length > i; i++)
                {
                    arms[i].SetActive(false);
                }
                arms[2].SetActive(true);
            }
        }
        
    }
}
