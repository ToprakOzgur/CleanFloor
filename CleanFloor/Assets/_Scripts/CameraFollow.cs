using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    private Vector3 offset;

    private void Awake()
    {
        //offset = transform.position;
        offset = transform.position - target.position;
    }
    void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, transform.position.y, transform.position.z);
        //Vector3 desiredPosition = target.position + offset;
        float clambepDesiredPosX = Mathf.Clamp(desiredPosition.x, -30, 26);
        var clambepDesiredPos = new Vector3(clambepDesiredPosX, desiredPosition.y, desiredPosition.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, clambepDesiredPos, smoothSpeed);
        transform.position = smoothedPosition;

        // transform.LookAt(target);
    }
}

