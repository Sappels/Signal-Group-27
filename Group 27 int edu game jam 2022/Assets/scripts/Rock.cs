using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] float speed;

    private Rigidbody rockRB;

    void Start()
    {
        rockRB = GetComponent<Rigidbody>();  
    }

    private void FixedUpdate()
    {
        rockRB.AddRelativeForce(Vector3.forward * speed);
    }
}
