using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance;

    [Header("Referencias")]

    [Tooltip("Fisica do Player")]
    public Rigidbody2D rb;

    [Tooltip("Transforme da Camera")]
    public Camera viewCam;

    [Tooltip("Efeito do tiro")]
    public GameObject bulletcImpact;

    [Tooltip("Animator para a arma")]
    public Animator gunAnim;

    [Tooltip("Tela de Morte")]
    public GameObject deadScreen;

    [Tooltip("Texto da vida do player e das balas")]
    public TextMeshProUGUI textHealth, textAmmo;

    [Header("Configurações")]

    [Tooltip("Velocidade da Movimentação do Player")]
    public float speedMove;

    [Tooltip("Inputs dos comandos do Player")]
    Vector2 moveInput;

    Vector2 mouseInput;

    [Tooltip("Sentibilidade do Cursor")]
    public float mouseSensitivity;

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

        gunAnim = GameObject.Find("Shoot").GetComponent<Animator>();

        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();

        viewCam = GameObject.Find("Main Camera").GetComponent<Camera>();

        
    }

    void Start()
    {
        currentHealth = maxHealth;

        textHealth.text = currentHealth.ToString() + "%";

        textAmmo.text = currentAmmo.ToString();
    }

    
    void Update()
    {
        if(!hasDied)
        { 
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 moveHozizontal = transform.up * -moveInput.x;

        Vector3 moveVertical = transform.right * moveInput.y;

        rb.velocity = (moveHozizontal + moveVertical) * speedMove;



        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);


        viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0f,mouseInput.y,0f));

        ShootGun();

        }
    }

    private void ShootGun()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (currentAmmo > 0)
            {
                Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Instantiate(bulletcImpact, hit.point, transform.rotation);

                    if (hit.transform.CompareTag("Enemy"))
                    {
                        hit.transform.parent.GetComponent<EnemyController>().TakeDamege();
                    }

                    AudioController.instance.PlayGunShootPickUp();
                }
                else
                {

                }
                currentAmmo--;
                gunAnim.SetTrigger("Shoot");
                UpdateAmmoUI();
            }
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            deadScreen.SetActive(true);
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

    public void UpdateAmmoUI()
    {
        textAmmo.text = currentAmmo.ToString();
    }

}
