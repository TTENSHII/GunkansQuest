using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    private GameObject player;
    private float yOffset = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
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
