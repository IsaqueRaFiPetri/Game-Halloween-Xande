using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArmsSystem : MonoBehaviour
{

    public static ArmsSystem instance;

    [Header("Referencias")]

    [Tooltip("Efeito do tiro")]
    public GameObject bulletcImpact;

    [Tooltip("Animator para a arma")]
    public Animator gunAnim;

    [Tooltip("Texto da vida do player e das balas")]
    public TextMeshProUGUI textAmmo;

    [Space(10)]

    [Header("Configurações")]

    [Tooltip("Tempo de tiro")]
    public float currentAmmo;

    [Tooltip("Dano do tiro")]
    public int damageShoot;

    [Tooltip("Nome da Animação")]
    public string activeAnim;

    public string activeEnd;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        textAmmo.text = currentAmmo.ToString();
    }


    private void Update()
    {
        ShootGun();
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
                        hit.transform.GetComponent<EnemyController>().TakeDamege(damageShoot);
                    }

                    AudioController.instance.PlayGunShootPickUp();
                }
                else
                {

                }
                currentAmmo--;
                gunAnim.SetTrigger(activeAnim);
                UpdateAmmoUI();
            }
            else if (currentAmmo <= 0)
            {
                gunAnim.SetTrigger(activeEnd);
            }
        }
    }
    public void UpdateAmmoUI()
    {
        textAmmo.text = currentAmmo.ToString();
    }
}
