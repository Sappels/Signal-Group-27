using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float minScale;
    [SerializeField] float maxScale;
    [SerializeField] float ticker;
    
    [SerializeField] bool needsTicker;
    
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
        if (needsTicker)
        {
            ticker -= Time.deltaTime;
            if (ticker <= 0)
            {
                rockRB.AddRelativeForce((Vector3.forward * speed) * GameManager.Instance.gameSpeed);
            }
        }
        else
        {
            rockRB.AddRelativeForce((Vector3.forward * speed) * GameManager.Instance.gameSpeed);
        }
        
        rockRB.velocity = (Vector3.ClampMagnitude(rockRB.velocity, 25f) * GameManager.Instance.gameSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            //Game over screen
        }
    }
}
