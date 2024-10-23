using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmonPickUp : MonoBehaviour
{
    public int ammoAmount = 25;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController.instance.currentAmmo += ammoAmount;

            PlayerController.instance.UpdateAmmoUI();


            AudioController.instance.PlayAmmoPickUp();

            Destroy(gameObject);
        }
    }
}
