using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSecretPassage : MonoBehaviour
{
    [SerializeField] Transform destination = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = destination.position;
        }
    }
}
