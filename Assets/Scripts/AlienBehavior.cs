using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBehavior : MonoBehaviour
{
    public bool wasHit = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet"
            || other.gameObject.tag == "Player"
            )
        {
            //GetComponent<ParticleSystem>().Play();
            //GetComponent<Renderer>().enabled = false;
            //Destroy(other.gameObject);
            if (!wasHit)
            {
                Counter.instance().addCount();
                wasHit = true;

                ParticleSystem exp = GetComponent<ParticleSystem>();
                GetComponent<Renderer>().enabled = false;
                exp.Play();
                Destroy(gameObject, exp.main.duration);
            }
        }
    }
}
