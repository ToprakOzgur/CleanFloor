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
        transform.position += forwardVector * Time.deltaTime * Speed;

    }

    public void ChangeDirection(BotDirection botDirection)
    {
        switch (botDirection)
        {
            case BotDirection.Down:
                Debug.Log("Down");
                forwardVector = -Vector3.forward;
                break;
            case BotDirection.Up:
                forwardVector = Vector3.forward;
                Debug.Log("Up");
                break;
            case BotDirection.Left:
                forwardVector = Vector3.left;
                Debug.Log("Lef");
                break;
            case BotDirection.Right:
                forwardVector = Vector3.right;
                Debug.Log("Right");
                break;
            case BotDirection.Stop:
                Debug.Log("Stop");
                break;
        }

    }


}