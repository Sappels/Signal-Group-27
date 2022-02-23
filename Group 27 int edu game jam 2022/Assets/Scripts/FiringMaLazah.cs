using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FiringMaLazah : MonoBehaviour
{
    float maxWidth = 18;

    [SerializeField] GameObject fireParticle;

    [SerializeField] ParticleSystem fireFX;

    public float fuelCapacity = 3;

    float realFuel;

    
    float cooldownTimer = 0;
    float cooldown2;

    private void Start()
    {
        maxWidth = GameObject.Find("FuelBar").transform.localScale.x;

        realFuel = fuelCapacity;
    }

    // Update is called once per frame
    void Update()
    {
        
        cooldownTimer -= Time.deltaTime; //(This is vile but it solves some spaghetti with collision)
        cooldown2 -= Time.deltaTime;


        if (Input.GetKey(KeyCode.Space))
        {
            if(realFuel > 0)
            {
                realFuel -= Time.deltaTime;
                fireFX.Play();
                GameObject.Find("FuelBar").transform.localScale = new Vector3(realFuel / fuelCapacity * maxWidth, GameObject.Find("FuelBar").transform.localScale.y, GameObject.Find("FuelBar").transform.localScale.z);

                if(cooldown2 <= 0)
                {
                    cooldown2 = 0.05f;
                    Instantiate(fireParticle, transform.position, Quaternion.Euler(0,0,0));
                }
            }
            else if(realFuel <= 0)
            {
                GameObject.Find("FuelBar").transform.localScale = new Vector3(0, GameObject.Find("FuelBar").transform.localScale.y, GameObject.Find("FuelBar").transform.localScale.z);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "FuelTank" && cooldownTimer <= 0)
        {
            Destroy(other.gameObject);
            realFuel = Mathf.Clamp(realFuel + fuelCapacity / 2, -1, fuelCapacity);
            GameObject.Find("FuelBar").transform.localScale = new Vector3(realFuel / fuelCapacity * maxWidth, GameObject.Find("FuelBar").transform.localScale.y, GameObject.Find("FuelBar").transform.localScale.z);

            cooldownTimer = 0.1f;
        }
    }
}
