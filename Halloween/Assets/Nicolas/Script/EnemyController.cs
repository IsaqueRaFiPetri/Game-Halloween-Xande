using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{

    public int health = 3;

    public GameObject deadFX;

    public float playerRange = 10f;

    public Rigidbody2D rb;

    public float moveSpeed = 2f;

    public int damageAmount;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < playerRange)
        {
            Vector3 playerDistance = PlayerController.instance.transform.position - transform.position;

            rb.velocity = playerDistance.normalized * moveSpeed;

        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void TakeDamege()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);

            Instantiate(deadFX, transform.position, transform.rotation);

            AudioController.instance.PlayEnemyDeadPickUp();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController.instance.TakeDamage(damageAmount);

            //Destroy(gameObject);
        }
    }
}
