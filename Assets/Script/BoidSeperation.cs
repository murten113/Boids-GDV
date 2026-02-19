using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Boid))]
public class BoidSeperation : MonoBehaviour
{
    private Boid boid;

    public float radius;

    public float repulsionForce;

    void Start()
    {
        boid = GetComponent<Boid>();
    }

    void Update()
    {
        var boids = FindObjectsByType<Boid>(FindObjectsSortMode.None);
        var average = Vector3.zero;
        var found = 0;

        foreach (var other in boids.Where(b => b != boid))
        {
            var diff = other.transform.position - this.transform.position;
            if (diff.magnitude < radius)
            {
                average += diff;
                found++;
            }
        }

        if (found > 0)
        {
            average /= found;
            boid.Velocity -= Vector3.Lerp(Vector3.zero, average, average.magnitude / radius) * repulsionForce;
        }
    }
}