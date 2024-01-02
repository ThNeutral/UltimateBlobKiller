using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnerScript : MonoBehaviour
{
    public float fireSpeed;
    public GameObject bullet;
    private float fireTimer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetButton("Fire1"))
        {
            return;
        }

        if (fireTimer > fireSpeed)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            fireTimer = 0f;
        }
        else
        {
            fireTimer += Time.deltaTime;
        }
    }
}
