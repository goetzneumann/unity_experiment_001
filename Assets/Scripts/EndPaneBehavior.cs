using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPaneBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet"
            || other.gameObject.tag == "Alien")
        {
            
            
            AlienBehavior alien = other.gameObject.GetComponent<AlienBehavior>();
            if(alien != null && !alien.wasHit)
            {
                Counter.instance().subtractCount();
            }
            Destroy(other.gameObject);
        }
    }
}
