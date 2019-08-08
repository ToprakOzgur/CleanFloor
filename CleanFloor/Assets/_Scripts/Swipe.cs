using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public enum BotDirection
{
    Stop = 0,
    Left = 1,
    Right = 2,
    Up = 3,
    Down = 4

}
public class Swipe : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Movement movement;
    public Rotator rotator;
    private Vector2 lastPosition = Vector2.zero;

    public static event Action OnLevelStarted = delegate { };

    [HideInInspector] public BotDirection newBotDirection = BotDirection.Stop;
    private BotDirection lastBotDirection = BotDirection.Stop;
    private bool isStarted = false;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isStarted)
        {
            isStarted = true;
            OnLevelStarted();
        }
        lastPosition = eventData.position;


    }

    private void Start()
    {

    }
    public void OnEndDrag(PointerEventData eventData)
    {


    }

    public void OnDrag(PointerEventData eventData)
    {
        if (movement.isDead)
            return;


        Vector2 direction = eventData.position - lastPosition;
        lastPosition = eventData.position;


        if (direction.magnitude < 10)
            return;



        if (Mathf.Abs(direction.x) >= Mathf.Abs(direction.y))
        {
            if (direction.x < 0)
            {
                newBotDirection = BotDirection.Left;
            }
            else if (direction.x > 0)
            {
                newBotDirection = BotDirection.Right;
            }
        }
        else
        {
            if (direction.y < 0)
            {
                newBotDirection = BotDirection.Down;
            }
            else if (direction.y > 0)
            {
                newBotDirection = BotDirection.Up;
            }
        }

        // if (CheckIfReverseMove(newBotDirection))
        // {

        //     return;
        // }
        lastBotDirection = newBotDirection;
        movement.ChangeDirection(newBotDirection);

        rotator.ChangeDirection(newBotDirection);
    }

    private bool CheckIfReverseMove(BotDirection newBotDirection)
    {
        bool isReverse = false;
        switch (lastBotDirection)
        {
            case BotDirection.Left:
                if (newBotDirection == BotDirection.Right)
                    isReverse = true;
                break;
            case BotDirection.Right:
                if (newBotDirection == BotDirection.Left)
                    isReverse = true;
                break;
            case BotDirection.Up:
                if (newBotDirection == BotDirection.Down)
                    isReverse = true;
                break;
            case BotDirection.Down:
                if (newBotDirection == BotDirection.Up)
                    isReverse = true;
                break;
            default:
                break;

        }
        return isReverse;
    }
}

