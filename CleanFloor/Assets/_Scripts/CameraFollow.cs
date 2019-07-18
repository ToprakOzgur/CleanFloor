using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public LevelGenerator levelelGenerator;
    private float roomWidth = 10;
    private float roomLength = 10;
    public float smoothSpeed = 0.125f;
    private Vector3 offset;

    private void Awake()
    {
        //offset = transform.position;
        offset = transform.position - target.position;
    }

    private void Start()
    {
        roomWidth = levelelGenerator.room.width;
        roomLength = levelelGenerator.room.length;
    }
    void FixedUpdate()
    {

        Vector3 desiredPosition = target.position + offset;
        float clambepDesiredPosX = Mathf.Clamp(desiredPosition.x, -(5 * roomWidth - 15), 5 * roomWidth - 15.2f);
        float clambepDesiredPosZ = Mathf.Clamp(desiredPosition.z, -(5 * roomLength + 9.5f), (5 * roomLength - 55));
        var clambepDesiredPos = new Vector3(clambepDesiredPosX, transform.position.y, clambepDesiredPosZ);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, clambepDesiredPos, smoothSpeed);
        transform.position = smoothedPosition;

        // transform.LookAt(target);
    }
}

