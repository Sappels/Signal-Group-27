using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticle : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float despawnTimer = 0.5f;

    [SerializeField] GameObject ScoreHolder;
    private Score score;

    private AudioSource sfxCrumble;

    private void Start()
    {
        sfxCrumble = GameObject.Find("SFXCrumble").GetComponent<AudioSource>();
        ScoreHolder = GameObject.Find("ScoreandTimerHolder");
        score = ScoreHolder.GetComponent<Score>();
    }

    void Update()
    {
        gameObject.transform.Translate(0, 0, Time.deltaTime * speed);

        despawnTimer -= Time.deltaTime;
        if(despawnTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "ObstacleMAFF")
        {
            other.gameObject.name = (float.Parse(other.gameObject.name) - Time.deltaTime).ToString();
            if(float.Parse(other.gameObject.name) <= 0)
            {
                Destroy(other.gameObject);
                score.treesDestroyed++;
                sfxCrumble.pitch = Random.Range(0.7f, 2f);
                sfxCrumble.Play();
            }
        }
        else if (other.gameObject.tag == "Tree")
        {
            other.gameObject.tag = "ObstacleMAFF";
            other.gameObject.name = "0";
        }
    }
}
