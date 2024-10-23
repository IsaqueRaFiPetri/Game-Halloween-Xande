using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    public AudioSource ammo, enemyDead, gunShoot, health, playerHurt;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayAmmoPickUp()
    {
        ammo.Stop();
        ammo.Play();
    }
    public void PlayEnemyDeadPickUp()
    {
        enemyDead.Stop();
        enemyDead.Play();
    }
    public void PlayGunShootPickUp()
    {
        gunShoot.Stop();
        gunShoot.Play();
    }
    public void PlayHealthPickUp()
    {
        health.Stop();
        health.Play();
    }
    public void PlayPlayerHurtPickUp()
    {
        playerHurt.Stop();
        playerHurt.Play();
    }
}
