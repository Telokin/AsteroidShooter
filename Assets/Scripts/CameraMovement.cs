using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private ShipMovement _shipMovement;
    [SerializeField] private Canvas _canvas;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(_shipMovement.transform.position.x, _shipMovement.transform.position.y, -10);
    }
}
