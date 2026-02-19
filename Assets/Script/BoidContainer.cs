using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Boid))]
public class BoidContainer : MonoBehaviour
{
    private Boid boid;

    public float radius;
    public float boundryForce;

    void Start()
    {
        boid = GetComponent<Boid>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boid.transform.position.magnitude > radius)
        {
            boid.Velocity += this.transform.position.normalized * (radius - boid.transform.position.magnitude) * boundryForce * Time.deltaTime;
        }
    }
}
