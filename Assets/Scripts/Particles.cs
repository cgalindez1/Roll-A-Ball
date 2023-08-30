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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
