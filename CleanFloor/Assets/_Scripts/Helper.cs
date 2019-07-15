using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    public static Vector3 BotDirectionToforwardVector(BotDirection botDirection)
    {
        Vector3 forwardVector = Vector3.zero;
        switch (botDirection)
        {
            case BotDirection.Down:

                forwardVector = -Vector3.forward;
                break;
            case BotDirection.Up:
                forwardVector = Vector3.forward;

                break;
            case BotDirection.Left:
                forwardVector = Vector3.left;

                break;
            case BotDirection.Right:
                forwardVector = Vector3.right;

                break;
            case BotDirection.Stop:
                forwardVector = Vector3.zero;
                break;
        }
        return forwardVector;
    }
}
