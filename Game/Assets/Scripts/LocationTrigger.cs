using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationTrigger : MonoBehaviour
{
    [SerializeField] private Transform previousLocation;
    [SerializeField] private Transform nextLocation;
    [SerializeField] private CameraController cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            if(collision.transform.position.x<transform.position.x)
                cam.MoveToNewLocation(nextLocation);
            else
                cam.MoveToNewLocation(previousLocation);
        }
    }
}
