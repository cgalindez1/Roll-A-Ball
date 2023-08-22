using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    public GameObject particlePrefab; 

    public void CreateParticles()
    {
        Instantiate(particlePrefab, transform.position, transform.rotation);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
