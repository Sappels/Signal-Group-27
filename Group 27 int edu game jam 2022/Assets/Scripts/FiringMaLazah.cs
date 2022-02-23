using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringMaLazah : MonoBehaviour
{

    [SerializeField] ParticleSystem fireFX;

    public float fuelCapacity = 3;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if(fuelCapacity > 0)
            {
                fuelCapacity -= Time.deltaTime;
                fireFX.Play();
            }
        }
    }
}
