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
        // Set the offset of the camera based on the player 
        offset = transform.position - player.transform.position; 
    }

    void LateUpdate()
    {
        //Get the cameras transform position to be that of the players transform position
        transform.position = player.transform.position + offset;
        
    }
}
