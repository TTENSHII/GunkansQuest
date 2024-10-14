using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] private int spawnX = 81;
    [SerializeField] private int minX = -46;
    [SerializeField] private float minSpeed = 0.5f;
    [SerializeField] private float maxSpeed = 2.0f;
    [SerializeField] private float speed = 0.0f;

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
