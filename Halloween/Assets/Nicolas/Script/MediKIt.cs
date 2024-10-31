using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediKIt : MonoBehaviour
{
    public int HealthAmount = 25;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LiveSystem.instance.AddHealth(HealthAmount);

            AudioController.instance.PlayHealthPickUp();

            Destroy(gameObject);
        }
    }
}
