using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 5f;

    private Vector3 lastMoveDirection = Vector3.zero;
    private Rigidbody myRigidbody;
    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {

        myRigidbody.velocity += lastMoveDirection * moveSpeed * Time.deltaTime;
        myRigidbody.velocity = Vector3.ClampMagnitude(myRigidbody.velocity, 8);

    }

    public void Move(Vector3 direction)
    {
        Debug.Log(direction);

        lastMoveDirection = new Vector3(direction.x, 0, direction.y);




    }

}