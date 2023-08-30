using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraStyle {Fixed, Free}
public class CameraController : MonoBehaviour
{
    public GameObject player;
    public CameraStyle cameraStyle;
    public Transform pivot;
    public float rotationSpeed = 1f;


    private Vector3 offset;
    private Vector3 pivotOffset;
    
    void Start()
    {
        //The offset of the pivot from the player
        pivotOffset = pivot.position - player.transform.position;
        // Set the offset of the camera based on the player 
        offset = transform.position - player.transform.position; 
    }

    void LateUpdate()
    {
        //If we are using the fixed camera mode
        if (cameraStyle == CameraStyle.Fixed)
        {
            //Set the cameras position to be the players position plus the offset
            transform.position = player.transform.position + offset;
        }
        //IF we are using the free camera mode 
        if (cameraStyle == CameraStyle.Free)
        {
            //make the pivot position follow the player
            pivot.transform.position = player.transform.position + pivotOffset;
            //Work out the angle from the mouse input as a quaternion
            Quaternion turnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
            //Modify the offset by the run angle
            offset = turnAngle * offset;
            //Set the camera position to that of the pivot plus the offset
            transform.position = pivot.transform.position + offset;
            //make the camera look at the pivot
            transform.LookAt(pivot);
        }
        //Get the cameras transform position to be that of the players transform position
        transform.position = player.transform.position + offset;
        
    }
}
