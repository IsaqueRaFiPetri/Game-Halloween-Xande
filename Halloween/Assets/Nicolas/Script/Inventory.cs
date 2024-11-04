using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    public GameObject[] arms = new GameObject[4];

    

    // Update is called once per frame
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
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            for (int i = 0; arms.Length > i; i++)
            {
                arms[i].SetActive(false);
            }
            arms[1].SetActive(true);
        }
        
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
