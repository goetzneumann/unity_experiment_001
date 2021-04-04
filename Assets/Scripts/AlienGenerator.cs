using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    [Range(1, 10)]
    public int alienStartLocationOffset = 1;

    //[Range(0, 10)]
    //public float spawnPointY = 0.0f;

    //[Range(1, 10)]
    //public float spawnPointX = 1.0f;

    [Range(1, 100)]
    public int alienSpeed = 50;

    public GameObject alien;
    // Update is called once per frame
    void Update()
    {

        if (Random.Range(0, 200) < 1)
        {
            int spawnPointY = Random.Range(-4, 6);
            int spawnPointX = Random.Range(-8, 8);
            GameObject clone = Instantiate(alien, transform.position + (Vector3.up * spawnPointY) + (Vector3.right * spawnPointX) + (Vector3.forward * alienStartLocationOffset)
            , alien.transform.rotation);
            clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * alienSpeed * -1);
            clone.SetActive(true);
        }
    }
}
