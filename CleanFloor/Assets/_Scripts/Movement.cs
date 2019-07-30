using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    private Rigidbody myRigidbody;
    private int speed = 18;
    [HideInInspector] public int firstSpeed = 0;

    private Vector3 forwardVector = Vector3.zero;

    public Rotator rotator;

    public GameManager gameManager;
    private bool isTouching = false;

    public int Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;

            myRigidbody.velocity = Vector3.zero;
            myRigidbody.velocity = forwardVector * Speed;



        }
    }

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        firstSpeed = Speed;
    }
    public float EaseInQuad(float start, float end, float value)
    {
        end -= start;
        return end * value * value + start;
    }

    public void ChangeDirection(BotDirection botDirection)
    {
        forwardVector = Helper.BotDirectionToforwardVector(botDirection);
        myRigidbody.velocity = forwardVector * Speed;
    }
    public void ChangeDirection(Vector2 botDirection)
    {
        var normalizedVector = botDirection.normalized;
        forwardVector = new Vector3(normalizedVector.x, 0, normalizedVector.y);

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("WallLeft") || other.gameObject.CompareTag("WallUp") || other.gameObject.CompareTag("Door") || other.gameObject.CompareTag("Floor"))
        {
            return;
        }
        isTouching = true;
        Speed = firstSpeed / 2;
        rotator.rotationSpeed = rotator.firstRotationSpeed / 2;
    }
    private void OnCollisionStay(Collision other)
    {

        if (isTouching)
            gameManager.game.level.TouchTime += Time.deltaTime;
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("WallLeft") || other.gameObject.CompareTag("WallUp") || other.gameObject.CompareTag("Door") || other.gameObject.CompareTag("Floor"))
        {
            return;
        }

        isTouching = false;
        rotator.rotationSpeed = rotator.firstRotationSpeed;
        Speed = firstSpeed;
    }

}