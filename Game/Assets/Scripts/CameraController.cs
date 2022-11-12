using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   [SerializeField] private float speed;
   private float currentposX;
   private Vector3 velocity=Vector3.zero;

   [SerializeField] private transform player;
   [SerializeField] private float aheadDistance;
   [SerializeField] private float cameraSpeed;
   private float lookAhead;

   private void Update()
   {
    //transform.position=Vector3.SmoothDamp(transform.position, new Vector3(currentposX, transform.position.y, transform.position.z), ref velocity, speed*Time.deltaTime);
    transform.position=new Vector3(player.position.x+lookAhead, transform.position.y, transform.position.z);
    lookAhead=Mathf.Lerp(lookAhead, (aheadDistance*player.localScale.x), Time.deltaTime*cameraSpeed);
   }

   public void MoveToNewLocation(Transform _newLocation)
   {
    currentposX=_newLocation.position.x;
   }
}
