using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public RoomGenerator roomGenerator;
    private float roomWidth = 10;
    private float roomLength = 10;
    public float smoothSpeed = 0.25f;
    private Vector3 offset;

    private void Awake()
    {
        //offset = transform.position;
        offset = transform.position - target.position;
    }

    private void Start()
    {
        roomWidth = roomGenerator.myRoom.width;
        roomLength = roomGenerator.myRoom.length;
    }
    void FixedUpdate()
    {

        Vector3 desiredPosition = target.position + offset;
        float clambepDesiredPosX = Mathf.Clamp(desiredPosition.x, -(5 * roomWidth - 13f), 5 * roomWidth - 13f);
        float clambepDesiredPosZ = Mathf.Clamp(desiredPosition.z, -(5 * roomLength + 5.0f), (5 * roomLength - 50));
        var clambepDesiredPos = new Vector3(clambepDesiredPosX, desiredPosition.y, clambepDesiredPosZ);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, clambepDesiredPos, smoothSpeed);
        transform.position = smoothedPosition;

        // transform.LookAt(target);
    }

    public void ChangePos()
    {

        offset = transform.position - target.position;
    }
}

