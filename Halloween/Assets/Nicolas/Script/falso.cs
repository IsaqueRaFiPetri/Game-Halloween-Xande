using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falso : MonoBehaviour
{
    public GameObject falsoPrefab;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            RenderSettings.fog = false;
            falsoPrefab.SetActive(false);
        }
    }
}
