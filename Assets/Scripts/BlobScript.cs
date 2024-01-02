using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlobScript : MonoBehaviour
{
    public float blobSpeed;
    public int scoreForKill;
    public int hp;
    public LogicScript ls;
    public Rigidbody2D chadRB;
    public Rigidbody2D selfRB;

    // Start is called before the first frame update
    void Start()
    {
        ls = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        chadRB = GameObject.FindGameObjectWithTag("Chad").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookDir = chadRB.position - selfRB.position;
        selfRB.velocity = lookDir.normalized * blobSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hp -= 1;
            Destroy(collision.gameObject);
            if (hp > 0) return; 
            ls.addScore(scoreForKill);
            Destroy(gameObject);
        }
    }
}
