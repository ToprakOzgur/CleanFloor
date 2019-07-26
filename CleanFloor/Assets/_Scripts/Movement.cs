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

    public GameManager gameManager;
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
    public void ChangeDirection(Vector2 botDirection)
    {
        var normalizedVector = botDirection.normalized;
        forwardVector = new Vector3(normalizedVector.x, 0, normalizedVector.y);

    }

    private void OnCollisionStay(Collision other)
    {


        if (other.gameObject.CompareTag("WallLeft") || other.gameObject.CompareTag("WallUp"))
        {

            // Debug.Log(transform.forward);
            // Speed = 3 * firstSpeed / 4;
            // rotator.rotationSpeed = 3 * rotator.firstRotationSpeed / 4;
            return;
        }
        gameManager.game.level.TouchTime += Time.deltaTime;
        Speed = firstSpeed / 4;
        rotator.rotationSpeed = rotator.firstRotationSpeed / 4;
    }
    private void OnCollisionExit(Collision other)
    {
        rotator.rotationSpeed = rotator.firstRotationSpeed;
        Speed = firstSpeed;
    }

}