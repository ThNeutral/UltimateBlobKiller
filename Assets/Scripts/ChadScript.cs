using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class ChadScript : MonoBehaviour
{
    public float chadSpeed;
    public SpriteRenderer sprite;
    public bool facingRight = true;
    public int hp;
    public Text hpTextField;
    public float invulTime;
    public bool isAlive = true;
    public GameObject gameOverScreen;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        refreshHPText();
    }

    // Update is called once per frame
    void Update()
    {
        move(transform);

        // Flip Script
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.x > transform.position.x && facingRight)
        {
            facingRight = !facingRight;
            flip(transform);
        }
        else if (mousePos.x < transform.position.x && !facingRight)
        {
            facingRight = !facingRight;
            flip(transform);
        }
    }

    public void move(Transform transformObj)
    {
        if (!isAlive) return;
        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        transformObj.position += moveVector.normalized * Time.deltaTime * chadSpeed;
    }

    public void flip(Transform transformObj)
    {
        transformObj.Rotate(0f, 180f, 0f);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "BlueBlob") && (timer > invulTime))
        {
            hp -= 1;
            if (hp < 1) { kill(); }
            if (hp < 0) { return; }
            refreshHPText();

            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    private void refreshHPText()
    {
        hpTextField.text = "HP: " + hp.ToString();
    }

    public void kill()
    {
        gameOverScreen.SetActive(true);
        isAlive = false;
    }
}
