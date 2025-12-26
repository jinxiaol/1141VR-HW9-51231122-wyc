using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 playerPos = this.player.transform.position;
            transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
        }
    }
}
