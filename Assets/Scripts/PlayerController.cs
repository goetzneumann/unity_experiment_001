using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float interval = 5f;
    float nextTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        nextTime = Time.realtimeSinceStartup + 1f;
    }
    [Range(1f, 10f)]
    public float movementSpeed = 5f;
    [Range(1, 100)]
    public int bulletSpeed = 50;
    [Range(1, 10)]
    public int bulletForwardLocationOffset = 3;

    [Range(-5f, 5f)]
    public float bulletDownLocationOffset = 0.34f;

    [Range(1, 10)]
    public float maxTop = 6;

    [Range(1, 10)]
    public float maxBottom = 4;

    [Range(1, 10)]
    public float maxLeft = 8;

    [Range(1, 10)]
    public float maxRight = 8;

    public GameObject projectile;
    // Update is called once per frame
    void Update()
    {
        //get the Input from Horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");
        //get the Input from Vertical axis
        float verticalInput = Input.GetAxis("Vertical");
        /*transform.position = new Vector3(
            transform.position.x+(horizontalInput * movementSpeed * Time.deltaTime),
            transform.position.y + (verticalInput * movementSpeed * Time.deltaTime), 0);*/


        //When movement verticalInput > 0 and maxTop is reached set verticalInput to 0;
        if(verticalInput > 0f && transform.position.y >= maxTop)
        {
            verticalInput = 0;
        }
        if (verticalInput < 0f && transform.position.y <= (maxBottom*-1))
        {
            verticalInput = 0;
        }
        if (horizontalInput < 0f && transform.position.x <= (maxLeft * -1))
        {
            horizontalInput = 0;
        }
        if (horizontalInput > 0f && transform.position.x >= maxRight)
        {
            horizontalInput = 0;
        }

        transform.transform.Translate(movementSpeed * Vector3.up * Time.deltaTime * verticalInput, Space.World);
        transform.transform.Translate(movementSpeed * Vector3.right * Time.deltaTime * horizontalInput, Space.World);

        if (nextTime<=Time.realtimeSinceStartup && !Counter.instance().IsGameOver() )
        {

            Counter.instance().AddBulletCount(1);

            nextTime += interval;

        }
    }
}
