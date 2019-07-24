using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    private Rigidbody myRigidbody;
    public int Speed = 22;

    private Vector3 forwardVector = Vector3.zero;
    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();



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


}