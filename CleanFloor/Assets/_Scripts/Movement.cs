using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    private Rigidbody myRigidbody;
    public int Speed = 22;
    private int firstSpeed = 0;

    private Vector3 forwardVector = Vector3.zero;

    public Rotator rotator;
    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        firstSpeed = Speed;
    }
    private void FixedUpdate()
    {
        myRigidbody.velocity = Vector3.zero;
        // transform.position += forwardVector * Time.deltaTime * Speed;
        myRigidbody.MovePosition(myRigidbody.position + forwardVector * Time.deltaTime * Speed);
    }

    public void ChangeDirection(BotDirection botDirection)
    {
        forwardVector = Helper.BotDirectionToforwardVector(botDirection);

    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("WallLeft") || other.gameObject.CompareTag("WallUp"))
        {
            Speed = 3 * firstSpeed / 4;
            rotator.rotationSpeed = 3 * rotator.firstRotationSpeed / 4;
            return;
        }
        Speed = firstSpeed / 2;
        rotator.rotationSpeed = rotator.firstRotationSpeed / 2;
    }
    private void OnCollisionExit(Collision other)
    {
        rotator.rotationSpeed = rotator.firstRotationSpeed;
        Speed = firstSpeed;
    }

}