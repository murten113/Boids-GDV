using Unity.Mathematics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Boid : MonoBehaviour
{

    public Vector3 Velocity;

    public float maxVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Velocity = this.transform.forward * maxVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Velocity.magnitude > maxVelocity)
        {
            Velocity = Velocity.normalized * maxVelocity;
        }

        this.transform.position += Velocity * Time.deltaTime;
        this.transform.rotation = Quaternion.LookRotation(Velocity);
    }
}
