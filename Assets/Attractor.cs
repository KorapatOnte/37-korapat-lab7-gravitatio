using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    private float myG = 6.67f;

    public static List<Attractor> planetAttractors;

    void FixedUpdate()
    {
        foreach (var pAttractor in planetAttractors)
        {
            if( pAttractor != this)
            {
                Attract(pAttractor);
            }
        }
    }

    void Attract(Attractor other )
    {
        Rigidbody rb0ther= other.rb;

        Vector3 direction = rb.position - rb0ther.position;

        float distance = direction.magnitude;

        float forceMagnitude = myG * (rb.mass * rb0ther.mass) / Mathf.Pow(distance, 2);

        Vector3 force = direction.normalized * forceMagnitude;

        rb0ther.AddForce(force);
    }

    private void OnEnable()
    {
        if (planetAttractors == null)  
        {
            planetAttractors = new List<Attractor>();
        }

        planetAttractors.Add(this);
    }
}
