using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    public float rotationX = 0;
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    private void Update()
    {
        transform.position = player.transform.position + offset;
        
        
        transform.Rotate (0, Input.GetAxis ("Mouse X") * 10, 0);               
        
        rotationX -= Input.GetAxis("Mouse Y") * 10.0f;
        
        rotationX = Mathf.Clamp(rotationX, -45.0f, 45);
        
        float rotationY = transform.localEulerAngles.y;
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
    }
}
// player// transform.rotation = Quaternion.Euler(0.0f, camera.transform.rotation.eulerAngles.y, 0.0f);
