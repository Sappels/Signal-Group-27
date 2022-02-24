using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticle : MonoBehaviour
{
    
    [SerializeField] float speed;
    [SerializeField] float despawnTimer = 0.5f;

    // Update is called once per frame
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
                GameObject.Find("SFXCrumble").GetComponent<AudioSource>().pitch = Random.Range(0.7f, 2f);
                GameObject.Find("SFXCrumble").GetComponent<AudioSource>().Play();
            }
        }
        else if (other.gameObject.tag == "Tree")
        {
            other.gameObject.tag = "ObstacleMAFF";
            other.gameObject.name = "0";
        }
    }
}
