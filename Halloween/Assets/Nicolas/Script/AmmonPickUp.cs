using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmonPickUp : MonoBehaviour
{
    public int ammoAmount = 25;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            ArmsSystem.instance.currentAmmo += ammoAmount;

            ArmsSystem.instance.UpdateAmmoUI();

            AudioController.instance.PlayAmmoPickUp();

            Destroy(gameObject);
        }
    }
}
