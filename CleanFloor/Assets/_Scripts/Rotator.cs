using UnityEngine;
public class Rotator : MonoBehaviour
{
    private BotDirection currentDirection = BotDirection.Stop;
    [SerializeField] private int rotationSpeed = 5;

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

        switch (botDirection)
        {
            case BotDirection.Down:
                Debug.Log("Down");
                targetDir = -Vector3.forward;
                break;
            case BotDirection.Up:
                targetDir = Vector3.forward;
                Debug.Log("Up");
                break;
            case BotDirection.Left:
                targetDir = Vector3.left;
                Debug.Log("Lef");
                break;
            case BotDirection.Right:
                targetDir = Vector3.right;
                Debug.Log("Right");
                break;
            case BotDirection.Stop:
                Debug.Log("Stop");
                break;
        }
    }

}