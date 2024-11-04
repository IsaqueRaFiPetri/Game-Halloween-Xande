using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LiveSystem : MonoBehaviour
{

    public static LiveSystem instance;

    [Header("Referencias")]

    [Tooltip("Efeito do tiro")]
    public GameObject bulletcImpact;

    /*[Tooltip("Animator para a arma")]
    public Animator gunAnim;*/

    /*[Tooltip("Tela de Morte")]
    public GameObject deadScreen;*/

    [Tooltip("Texto da vida do player e das balas")]
    public TextMeshProUGUI textHealth, textAmmo;

    [Space(10)]

    [Header("Configurações")]

    [Tooltip("Tempo de tiro")]
    public float currentAmmo;

    [Tooltip("Vida Maxima do Jogador")]
    public int maxHealth = 100;

    [Tooltip("Condição para saber se morreu")]
    public bool hasDied;

    int currentHealth;

    void Awake()
    {
        instance = this;

        //gunAnim = GameObject.Find("Shoot").GetComponent<Animator>();
    }

    void Start()
    {
        currentHealth = maxHealth;

        textHealth.text = currentHealth.ToString() + "%";

        textAmmo.text = currentAmmo.ToString();
    }


    void Update()
    {
        if (!hasDied)
        {
            //ShootGun();

        }
    }

    private void ShootGun()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (currentAmmo > 0)
            {
                Ray ray = FirstPersonController.instance.playerCamera.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Instantiate(bulletcImpact, hit.point, transform.rotation);

                    if (hit.transform.CompareTag("Enemy"))
                    {
                        hit.transform.GetComponent<EnemyController>().TakeDamege();
                    }

                    AudioController.instance.PlayGunShootPickUp();
                }
                else
                {

                }
                /*currentAmmo--;
                //gunAnim.SetTrigger("Shoot");
                UpdateAmmoUI();*/
            }
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Demo");
            hasDied = true;
            currentHealth = 0;
        }
        textHealth.text = currentHealth.ToString() + "%";

        AudioController.instance.PlayPlayerHurtPickUp();
    }

    public void AddHealth(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        textHealth.text = currentHealth.ToString() + "%";
    }

    /*public void UpdateAmmoUI()
    {
        textAmmo.text = currentAmmo.ToString();
    }*/

}