using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float forceMultiplier;
    public SpriteRenderer sr;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Camera camera = Camera.main;
        Vector2 direction = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = direction - rb.position;
        rb.velocity = lookDir.normalized * forceMultiplier;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    // Update is called once per frame
    void Update()
    {
        if (!sr.isVisible)
        {
            Destroy(gameObject);
        }
    }
}
