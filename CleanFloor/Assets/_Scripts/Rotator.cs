using UnityEngine;
public class Rotator : MonoBehaviour
{
    private BotDirection currentDirection = BotDirection.Stop;
    public int rotationSpeed = 13;

    private Vector3 targetDir = Vector3.zero;
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

    }

}