using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] float minScale;
    [SerializeField] float maxScale;

    private float scale;

    private Rigidbody rockRB;

    void Start()
    {
        scale = Random.Range(minScale, maxScale);
        transform.localScale = new Vector3(scale, scale, scale);
        rockRB = GetComponent<Rigidbody>();  
    }

    private void FixedUpdate()
    {
        rockRB.AddRelativeForce((Vector3.forward * speed) * GameManager.Instance.gameSpeed);
    }
}
