using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSpeed : MonoBehaviour
{
    [SerializeField] float stepInterval = 0.4f;
    [SerializeField] float minPitch = 0.8f;
    [SerializeField] float maxPitch = 1.2f;
    float timer = 0;

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = stepInterval;
            float pitch = Random.Range(minPitch, maxPitch);
            gameObject.GetComponent<AudioSource>().pitch = pitch;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
