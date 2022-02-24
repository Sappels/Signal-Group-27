using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FiringMaLazah : MonoBehaviour
{
    float maxWidth = 18;

    [SerializeField] GameObject fireParticle;
    [SerializeField] ParticleSystem fireFX;
    [SerializeField] GameObject fuelBar;

    private AudioSource SFXFireLoopAS;
    private AudioSource SFXFireEndAS;

    public float fuelCapacity = 3;

    float realFuel;

    bool started = false;

    float cooldownTimer = 0;
    float cooldown2;

    private void Start()
    {
        fuelBar = GameObject.Find("FuelBar");
        SFXFireLoopAS = GameObject.Find("SFXFireLoop").GetComponent<AudioSource>();
        SFXFireEndAS = GameObject.Find("SFXFireEnd").GetComponent<AudioSource>();

        maxWidth = GameObject.Find("FuelBar").transform.localScale.x;

        realFuel = fuelCapacity;
    }

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
                fuelBar.transform.localScale = new Vector3(realFuel / fuelCapacity * maxWidth, fuelBar.transform.localScale.y, fuelBar.transform.localScale.z);

                if(cooldown2 <= 0)
                {
                    cooldown2 = 0.05f;
                    Instantiate(fireParticle, transform.position, Quaternion.Euler(0,0,0));
                }
                if(started == false)
                {
                    started = true;
                    float pitch = Random.Range(0.9f, 1.1f);
                    SFXFireLoopAS.pitch = pitch;
                    SFXFireLoopAS.Play();
                }
            }
            else if(realFuel <= 0)
            {
                fuelBar.transform.localScale = new Vector3(0, fuelBar.transform.localScale.y, fuelBar.transform.localScale.z);

                SFXFireLoopAS.Stop();
                if (started)
                {
                    SFXFireEndAS.Play();
                    started = false;
                }
            }
        }
        else
        {
            SFXFireLoopAS.Stop();
            if(started)
            {
                float pitch = Random.Range(0.6f, 1.4f);
                SFXFireEndAS.pitch = pitch;
                SFXFireEndAS.Play();
                started = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "FuelTank" && cooldownTimer <= 0)
        {
            Destroy(other.gameObject);
            realFuel = Mathf.Clamp(realFuel + fuelCapacity / 2, -1, fuelCapacity);
            fuelBar.transform.localScale = new Vector3(realFuel / fuelCapacity * maxWidth, fuelBar.transform.localScale.y, fuelBar.transform.localScale.z);

            cooldownTimer = 0.1f;
        }
    }
}
