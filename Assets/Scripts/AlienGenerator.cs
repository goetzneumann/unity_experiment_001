using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienGenerator : MonoBehaviour
{

    public float interval = 20f;
    float nextTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
       
    }
    private const int INITIAL_START_LOCATION_OFFSET = 1;
    private int alienStartLocationOffset = INITIAL_START_LOCATION_OFFSET;

    private const int INITIAL_ALIEN_SPEED = 10;
    private int alienSpeed = INITIAL_ALIEN_SPEED;


    private const int INITIAL_MAX_COUNT = 3;
    private int maxAlientCount = INITIAL_MAX_COUNT;

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
        if (Random.Range(0, 5) < 1)
        {
            alienSpeed += 1;
            maxAlientCount += 1;
        }
        for (int i = 0; i < alienCount; i++ )
        {
            SpawnOneAlien();
        }
    }

    private void Reset()
    {
        alienStartLocationOffset = INITIAL_START_LOCATION_OFFSET;
        alienSpeed = INITIAL_ALIEN_SPEED;
        maxAlientCount = INITIAL_MAX_COUNT;
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
