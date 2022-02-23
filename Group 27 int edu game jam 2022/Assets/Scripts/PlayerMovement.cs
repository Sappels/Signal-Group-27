using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 2;

    Quaternion rotationLeft = Quaternion.Euler(0, 0, 20);
    Quaternion rotationRight = Quaternion.Euler(0, 0, -20);
    Quaternion targetRotation = Quaternion.Euler(0, 0, 0);
    public Quaternion resetRotation;

    private void Start()
    {
        resetRotation = targetRotation;
    }

    void Update()
    {
        Vector3 movementDirection = new Vector3(0, 0, 0);

        if(Input.GetKey(KeyCode.A))
        {
            movementDirection.x -= 1;
            targetRotation = rotationLeft;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementDirection.x += 1;
            targetRotation = rotationRight;
        }

        if (!Input.anyKey)
        {
            targetRotation = resetRotation;
        }


        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, (0.3f * Time.deltaTime * Time.timeScale * 10));

        gameObject.GetComponent<Rigidbody>().AddForce(movementDirection.normalized * Time.deltaTime * Time.timeScale * speed);
    }
}
