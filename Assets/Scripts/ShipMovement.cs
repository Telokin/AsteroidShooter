using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{

    private Rigidbody2D rb2D;
    [SerializeField] private float movementSpeed = 4f;
    [SerializeField] private float rotationSpeed = 1f;
    public Vector2 _movement;

    [SerializeField] private GameObject _projectile;
    [SerializeField] private float projectileSpeed;
    private Vector2 _projectileCords;
    private GameObject clone;


    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        InvokeRepeating("Shoot", 3f, 0.5f);
    }

    void Update()
    {
        _movement.y = Input.GetAxis("Vertical");
        _movement.x = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) AddForce(_movement.y);
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
        _projectileCords = new Vector2(transform.position.x, transform.position.y);
        clone = Instantiate(_projectile, _projectileCords, transform.rotation);       
    }
}
