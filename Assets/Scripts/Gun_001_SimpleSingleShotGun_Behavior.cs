using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_001_SimpleSingleShotGun_Behavior : MonoBehaviour
{

    [Range(1, 100)]
    public int bulletSpeed = 50;
    [Range(1, 10)]
    public int bulletForwardLocationOffset = 1;

    [Range(-5f, 5f)]
    public float bulletDownLocationOffset = 0f;


    public GameObject projectile;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && player.CanShoot())
        {
            // Instantiate the projectile at the position and rotation of this transform
            GameObject clone = Instantiate(projectile, transform.position + (Vector3.forward * bulletForwardLocationOffset) + (Vector3.down * bulletDownLocationOffset), projectile.transform.rotation);

            // Give the cloned object an initial velocity along the current
            // object's Z axis
            clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.down * bulletSpeed) * -1;
            clone.SetActive(true);
            Counter.instance().SubtractBulletCount(1);
        }
    }
}
