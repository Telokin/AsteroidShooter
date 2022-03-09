using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    private Vector2 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.gameObject.SetActive(false);
        collision.gameObject.SetActive(false);
    }

    private void RespawnAsteroid()
    {
        if(this.gameObject.activeSelf == false)
        {
            this.gameObject.SetActive(true);
            transform.position = startPosition;
        }
    }


}
