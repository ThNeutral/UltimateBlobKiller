using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public string side;
    public float distance;
    public GameObject newTileMap;
    // 0 - Top, 1 - Bottom
    public GameObject[] spawners;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update() 
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        float aspectCoef = (float)Math.Ceiling(Camera.main.aspect) + 0.2f;
        float xCoef, yCoef;
        switch (side)
        {
            case "top":
                {
                    xCoef = 0;
                    yCoef = 1;
                    break;
                }
            case "right":
                {
                    xCoef = aspectCoef;
                    yCoef = 0;
                    break;
                }
            case "bottom":
                {
                    xCoef = 0;
                    yCoef = -1;
                    break;
                };
            case "left":
                {
                    xCoef = -aspectCoef;
                    yCoef = 0;
                    break;
                }
            default:
                {
                    xCoef = 0;
                    yCoef = 0;
                    break;
                }
        }
        Vector3 v3 = new Vector3(transform.position.x + xCoef * distance, transform.position.y + yCoef * distance);
        GameObject[] goArray = GameObject.FindGameObjectsWithTag("Grid");
        
        for (int i = goArray.Length - 1; i >= 0; i--)
        {
            if (!isGameObjectVisible(goArray[i])) { Destroy(goArray[i]); }
        }

        if (areTaggedObjectsInPoint(goArray, v3)) return;
        
        Instantiate(newTileMap, v3, Quaternion.identity);
    }

    bool areTaggedObjectsInPoint(GameObject[] goArray, Vector3 v3)
    {
        for (int i = 0; i < goArray.Length; i++) 
        {
            if (goArray[i].transform.position.Equals(v3)) { return true; };
        }

        return false;
    }

    bool isGameObjectVisible(GameObject go)
    {
        Camera cam = Camera.main;
        Vector3 vp = cam.WorldToViewportPoint(go.transform.position);
        if ((-2 < vp.x) && (vp.x < 3) && (-2 < vp.y) && (vp.y < 3) && (vp.z >= 0)) { return true; }
        return false;
    }
}
