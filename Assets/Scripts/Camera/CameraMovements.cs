using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    [SerializeField] private float yOffset = 2.0f;
    
    private GameObject player = null;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player != null)
        {
            float x = player.transform.position.x;
            float y = player.transform.position.y + yOffset;
            float z = transform.position.z;
            transform.position = new Vector3(x, y, z);
        }
    }
}
