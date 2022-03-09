using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    [SerializeField] private ShipMovement shipMovement;
    private Rigidbody2D rb2D;

    public int scoreValue;
    // Update is called once per frame

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        AddForce(projectileSpeed + shipMovement.shipVelocity);
        Destroy(this.gameObject, 3);
    }

    private void AddForce(float amount)
    {
        Vector2 force = transform.up * amount;
        rb2D.AddForce(force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        scoreValue++;
    }
}
