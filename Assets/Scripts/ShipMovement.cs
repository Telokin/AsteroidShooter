using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{

    private Rigidbody2D rb2D;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    public Vector2 _movement;

    [SerializeField] private GameObject _projectile;
    private GameObject clone;


    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        InvokeRepeating("Shoot", 3f, 0.5f);
    }

    void FixedUpdate()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) AddForce(movementSpeed);
        Rotate(transform, _movement.x * -rotationSpeed);
    }

    private void AddForce(float amount)
    {
        Vector2 force = transform.up * amount;
        rb2D.AddForce(force);
    }

    private void Rotate(Transform transform, float amount)
    {
        transform.Rotate(0, 0, amount);
    }


    private void Shoot()
    {
        _projectile.transform.position = new Vector2(transform.position.x, transform.position.y);
        clone = Instantiate(_projectile, _projectile.transform.position, transform.rotation);       
    }
}
