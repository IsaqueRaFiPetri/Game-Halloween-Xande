using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyController : MonoBehaviour
{

    public int health = 3;

    public GameObject deadFX;

    public float playerRange = 10f;

    public Rigidbody rb;

    public float moveSpeed = 2f;

    public int damageAmount;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, FirstPersonController.instance.transform.position) < playerRange)
        {
            Vector3 playerDistance = FirstPersonController.instance.transform.position - transform.position;

            

            rb.velocity = playerDistance.normalized * moveSpeed;

        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    public void TakeDamege(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);

            Instantiate(deadFX, transform.position, transform.rotation);

            AudioController.instance.PlayEnemyDeadPickUp();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LiveSystem.instance.TakeDamage(damageAmount);

            //Destroy(gameObject);
        }
    }
}
