using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    public ChadScript cs;
    private float chadSpeed;

    // Start is called before the first frame update
    void Start()
    {
        chadSpeed = cs.chadSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Move Script
        cs.move(transform);
    }
}
