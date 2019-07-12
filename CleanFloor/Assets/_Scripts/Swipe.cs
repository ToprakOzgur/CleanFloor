using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Swipe : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    public Movement movement;
    private Vector2 lastPosition = Vector2.zero;


    public void OnBeginDrag(PointerEventData eventData)
    {
        lastPosition = eventData.position;


    }

    public void OnEndDrag(PointerEventData eventData)
    {


    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 direction = eventData.position - lastPosition;
        if (direction.magnitude < 2)
            return;
        lastPosition = eventData.position;

        movement.Move(direction.normalized);

    }
}

