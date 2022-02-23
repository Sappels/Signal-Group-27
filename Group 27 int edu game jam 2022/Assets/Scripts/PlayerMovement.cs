using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 2;

    void Update()
    {
        Vector3 movementDirection = new Vector3(0, 0, 0);

        if(Input.GetKey(KeyCode.A))
        {
            movementDirection.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementDirection.x += 1;
        }


        gameObject.GetComponent<Rigidbody>().AddForce(movementDirection.normalized * Time.timeScale * Time.deltaTime * speed);
    }
}
