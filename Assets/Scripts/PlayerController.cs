using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
    [Range(1f, 10f)]
    public float movementSpeed = 5f;
    [Range(1, 100)]
    public int bulletSpeed = 50;
    [Range(1, 10)]
    public int bulletStartLocationOffset = 1;

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
        if (Input.GetButtonDown("Fire1"))
        {
            // Instantiate the projectile at the position and rotation of this transform
            GameObject clone = Instantiate(projectile, transform.position + (Vector3.forward * bulletStartLocationOffset), projectile.transform.rotation);

            // Give the cloned object an initial velocity along the current
            // object's Z axis
            clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * bulletSpeed);
            clone.SetActive(true);
            
        }

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
    }
}
