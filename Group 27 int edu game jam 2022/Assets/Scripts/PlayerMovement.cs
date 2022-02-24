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

    void FixedUpdate()
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

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, (0.3f * Time.deltaTime * 10) * GameManager.Instance.gameSpeed);

        gameObject.GetComponent<Rigidbody>().AddForce((movementDirection.normalized * Time.deltaTime * speed) * GameManager.Instance.gameSpeed);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Tree"))
        {
            GameManager.Instance.gameOver = true;
            Debug.Log("You died!");
            //Switch to game over screen, count out points.
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pleasedie"))
        {
            GameManager.Instance.gameOver = true;
            Debug.Log("You died!");
        }
    }
}
