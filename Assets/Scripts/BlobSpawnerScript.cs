using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobSpawnerScript : MonoBehaviour
{
    public GameObject blob;
    public float spawnRate;
    public float xDistribution;
    public float yDistribution;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        createBlob();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > spawnRate) { createBlob(); timer = 0f; }
        else { timer += Time.deltaTime; }
    }

    private void createBlob()
    {
        float x = Random.Range(-xDistribution, xDistribution);
        float y = Random.Range(-yDistribution, yDistribution);
        Vector3 v3 = new Vector3(transform.position.x + x, transform.position.y + y);
        Instantiate(blob, v3, Quaternion.identity);
    }
}
