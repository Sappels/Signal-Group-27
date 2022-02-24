using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    [SerializeField] GameObject ffx;
    [SerializeField] GameObject fartSFX;
    [SerializeField] GameObject particles;
    [SerializeField] GameObject flameThrower;
    [SerializeField] GameObject animationObject;
    [SerializeField] GameObject bonBonObject;
    [SerializeField] GameObject timerObject;

    bool startFlameTimer = false;
    bool fireSound = false;
    bool fart = false;

    [SerializeField] float flameTimer = 2.5f;

    float timer;
    //I literally basically copied the timer script so that there wasn't a chance of conflicting files

    void Start()
    {
        timer = timerObject.GetComponent<Timer>().startTimer;
    }

    void Update()
    {

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (!GameManager.Instance.outOfFuel)
            {

                animationObject.GetComponent<Animator>().SetBool("SupremeVictory", true);
                bonBonObject.GetComponent<Animator>().SetBool("SupremeVictory", true);

                startFlameTimer = true;
            }
            else
            {

                animationObject.GetComponent<Animator>().SetBool("SupremeVictory", true);
                bonBonObject.GetComponent<Animator>().SetBool("SupremeVictory", true);

                fart = true;
            }
        }

        if(startFlameTimer)
        {
            flameTimer -= Time.deltaTime;
            if(flameTimer <= 0 && flameTimer >= -1f)
            {
                particles.active = true;
                flameThrower.GetComponent<ParticleSystem>().Play();
                if(fireSound == false)
                {
                    fireSound = true;
                    ffx.GetComponent<AudioSource>().Play();
                }
            }
            else if(flameTimer < -1f)
            {
                if(fireSound)
                {
                    fireSound = false;
                    GameObject.Find("SFXFireLoop").GetComponent<AudioSource>().Stop();
                    GameObject.Find("SFXFireEnd").GetComponent<AudioSource>().Play();
                }
            }
        }
        else if (fart)
        {
            flameTimer -= Time.deltaTime;
            if (flameTimer <= 0 && flameTimer >= -1f)
            {
                
                if (fireSound == false)
                {
                    flameThrower.GetComponent<ParticleSystem>().Play();
                    fireSound = true;
                    fartSFX.GetComponent<AudioSource>().Play();
                }
            }
            else if (flameTimer < -1f)
            {
                if (fireSound)
                {
                    fireSound = false;
                }
            }
        }
    }
}
