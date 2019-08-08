using System;
using UnityEngine;
public class Rotator : MonoBehaviour
{
    public static event Action OnChangeRotation = delegate { };
    private BotDirection currentDirection = BotDirection.Stop;
    public int rotationSpeed = 13;
    [HideInInspector] public int firstRotationSpeed = 13;

    private Vector3 targetDir = Vector3.zero;

    private void Start()
    {
        firstRotationSpeed = rotationSpeed;
    }
    private void FixedUpdate()
    {

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, Time.deltaTime * rotationSpeed, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDir);

    }


    public void ChangeDirection(BotDirection botDirection)
    {
        if (currentDirection == botDirection)
            return;
        currentDirection = botDirection;

        targetDir = Helper.BotDirectionToforwardVector(botDirection);
        OnChangeRotation();
    }
    public void ChangeDirection(Vector2 botDirection)
    {
        var normalizedDirection = botDirection.normalized;
        targetDir = new Vector3(normalizedDirection.x, 0, normalizedDirection.y);

    }

}