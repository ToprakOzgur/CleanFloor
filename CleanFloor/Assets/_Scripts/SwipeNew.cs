using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class SwipeNew : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    public Vacuum vacuum;
    public Movement movement;
    public Rotator rotator;
    private Vector2 lastPosition = Vector2.zero;

    [HideInInspector] public BotDirection newBotDirection = BotDirection.Stop;
    private BotDirection lastBotDirection = BotDirection.Stop;
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
    private void Start()
    {

    }
    public void OnEndDrag(PointerEventData eventData)
    {


    }

    public void OnDrag(PointerEventData eventData)
    {



        Vector2 direction = eventData.position - lastPosition;
        lastPosition = eventData.position;
        Debug.Log(direction.normalized);

        if (direction.magnitude < 10)
            return;



        movement.ChangeDirection(direction);

        rotator.ChangeDirection(direction);
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

