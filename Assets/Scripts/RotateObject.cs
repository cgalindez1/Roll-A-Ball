using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Vector2 rotationAxis;
    public float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}
