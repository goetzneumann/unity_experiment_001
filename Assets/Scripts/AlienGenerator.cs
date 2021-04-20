using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienGenerator : MonoBehaviour
{

    public float interval = 3f;
    float nextTime = 0f;

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
    public int alienSpeed = 10;

    public int maxAlientCount = 3;

    public GameObject alien;
    // Update is called once per frame
    void Update()
    {
        if (nextTime <= Time.time && !Counter.instance().IsGameOver())
        {

            SpawnAliens();

            nextTime += interval;

        }
    }

    void SpawnAliens()
    {
        int alienCount = Random.Range(1, maxAlientCount);
        alienSpeed += 1;
        for (int i = 0; i < alienCount; i++ )
        {
            
            SpawnOneAlien();
        }
    }

    void SpawnOneAlien()
    {
        int spawnPointY = Random.Range(-4, 6);
        int spawnPointX = Random.Range(-8, 8);
        GameObject clone = Instantiate(alien, transform.position + (Vector3.up * spawnPointY) + (Vector3.right * spawnPointX) + (Vector3.forward * alienStartLocationOffset)
        , alien.transform.rotation);
        clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward *(alienSpeed + Random.Range(0,20)) * -1);
        clone.SetActive(true);
    }
}
