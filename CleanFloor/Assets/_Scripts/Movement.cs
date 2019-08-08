using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rotator))]
[RequireComponent(typeof(Robot))]
public class Movement : MonoBehaviour
{
    private Rigidbody myRigidbody;
    private int speed = 18;
    [HideInInspector] public int firstSpeed = 0;

    private Vector3 forwardVector = Vector3.zero;

    private Rotator rotator;
    private Robot robot;
    private bool isTouching = false;
    [HideInInspector] public bool isDead = false;
    [HideInInspector] public bool isDemagePowerUpActive = false;
    [HideInInspector] public bool isSpeedPowerUpActive = false;
    public static event Action<bool> OnTouchObstacleAction = delegate { };

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

    public bool IsTouching
    {
        get
        {
            return isTouching;
        }
        set
        {
            if (isTouching != value)
            {
                OnTouchObstacleAction(value);
            }
            isTouching = value;

        }
    }

    private void Awake()
    {
        rotator = gameObject.GetComponent<Rotator>();
        robot = gameObject.GetComponent<Robot>();
    }
    private void OnEnable()
    {
        Robot.OnLevelFailed += LevelFailed;
        Vacuum.OnLevelComplated += LevelCoomplated;
    }



    private void OnDisable()
    {
        Robot.OnLevelFailed -= LevelFailed;
        Vacuum.OnLevelComplated -= LevelCoomplated;
    }

    private void LevelFailed()
    {
        isDead = true;

        myRigidbody.isKinematic = true;

    }
    private void makeKinematic()
    {
        myRigidbody.isKinematic = true;
    }
    private void LevelCoomplated()
    {
        isDead = true;


        Invoke("makeKinematic", 0.5f);
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
        if (isDead)
            return;
        forwardVector = Helper.BotDirectionToforwardVector(botDirection);
        myRigidbody.velocity = forwardVector * Speed;
    }
    public void ChangeDirection(Vector2 botDirection)
    {
        if (isDead)
            return;
        var normalizedVector = botDirection.normalized;
        forwardVector = new Vector3(normalizedVector.x, 0, normalizedVector.y);

    }
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("WallLeft")
        || other.gameObject.CompareTag("WallUp")
        || other.gameObject.CompareTag("Door")
        || other.gameObject.CompareTag("Floor"))
        {
            return;
        }

        IsTouching = true;

        if (!isSpeedPowerUpActive)
            Speed = firstSpeed / 2;
        rotator.rotationSpeed = rotator.firstRotationSpeed / 2;
    }
    private void OnCollisionStay(Collision other)
    {

        if (IsTouching && !isDemagePowerUpActive && !isDead)
            robot.TouchTime += Time.deltaTime;
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("WallLeft") || other.gameObject.CompareTag("WallUp") || other.gameObject.CompareTag("Door") || other.gameObject.CompareTag("Floor"))
        {
            return;
        }

        IsTouching = false;
        rotator.rotationSpeed = rotator.firstRotationSpeed;
        if (!isSpeedPowerUpActive)
            Speed = firstSpeed;
    }

}