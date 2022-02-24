using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    [SerializeField] GameObject mapWrapper;
    [SerializeField] float speed;

    private Vector3 startPos = new Vector3(-92, 349, 977);
    private Vector3 movedir;
    private Vector3 resetPos;

    private void Start()
    {
        movedir = mapWrapper.transform.position - transform.position;
        resetPos = transform.position;
    }

    void FixedUpdate()
    {
        transform.Translate(movedir * Time.deltaTime * speed * GameManager.Instance.gameSpeed, Space.World);

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = resetPos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MapWrap"))
        {
            Debug.Log("Call me!");
            transform.position = startPos;
        }
    }
}
