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

    public Vacuum vacuum;
    public Movement movement;
    public Rotator rotator;
    private Vector2 lastPosition = Vector2.zero;

    [HideInInspector] public BotDirection currentBotDirection = BotDirection.Stop;
    private bool isStarted = false;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isStarted)
        {
            isStarted = true;
            vacuum.PowerOn = true;
        }
        lastPosition = eventData.position;


    }

    public void OnEndDrag(PointerEventData eventData)
    {


    }

    public void OnDrag(PointerEventData eventData)
    {



        Vector2 direction = eventData.position - lastPosition;
        lastPosition = eventData.position;


        if (direction.magnitude < 10)
            return;



        if (Mathf.Abs(direction.x) >= Mathf.Abs(direction.y))
        {
            if (direction.x < 0)
            {
                currentBotDirection = BotDirection.Left;
            }
            else if (direction.x > 0)
            {
                currentBotDirection = BotDirection.Right;
            }
        }
        else
        {
            if (direction.y < 0)
            {
                currentBotDirection = BotDirection.Down;
            }
            else if (direction.y > 0)
            {
                currentBotDirection = BotDirection.Up;
            }
        }

        movement.ChangeDirection(currentBotDirection);

        rotator.ChangeDirection(currentBotDirection);
    }
}

