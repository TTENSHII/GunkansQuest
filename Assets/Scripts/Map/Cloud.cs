using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public int spawnX = 35;
    public int minX = -46;

    public float minSpeed = 0.5f;
    public float maxSpeed = 2.0f;

    private float speed = 0.0f;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        if (transform.position.x < minX)
        {
            transform.position = new Vector3(spawnX, transform.position.y, transform.position.z);
        }
    }

    void FixedUpdate()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
