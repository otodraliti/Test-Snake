using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;


    void Update()
    {
        this.gameObject.transform.position = player.position + offset;
        gameObject.transform.LookAt(player);
    }
}
