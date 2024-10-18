using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed = 2.0f;

    private Vector3 target = Vector3.zero;
    private Vector3 targetA = Vector3.zero;
    private Vector3 targetB = Vector3.zero;

    private void Start()
    {
        target = pointA.position;
        targetA = pointA.position;
        targetB = pointB.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, target);

        if (distance <= 0.1f)
        {
            if (target == targetA)
            {
                target = targetB;
            }
            else
            {
                target = targetA;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
