using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private float swipeMovementTreshold = 10;
    private bool isDragging = false;

    private bool tap = false;

    private Vector2 startTouch, swipeDelta;

    public Vector2 StartTouch { get => startTouch; }
    public Vector2 SwipeDelta { get => swipeDelta; }
    private int rotateDirection = 0;
    public int RotateDirection { get => rotateDirection; }

    private void Update()
    {
        tap = false;

#if UNITY_EDITOR
        StandAloneInput();
#endif

#if UNITY_IOS
     MobileInput();
#endif


#if UNITY_ANDROID
        MobileInput();
#endif



        CalculateDistance();

        //Did we cross the treschold distance

        CheckMovementTouchThreshold();

    }

    private void CheckMovementTouchThreshold()
    {
        if (swipeDelta.magnitude > swipeMovementTreshold)
        {
            //what direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //left or right
                if (x < 0)
                {
                    Debug.Log("LEFT");
                    rotateDirection = -1;
                }

                else
                {
                    Debug.Log("RIGHT");
                    rotateDirection = 1;
                }
                return;
            }
            // else
            // {
            //     //up or down
            //     if (y < 0)
            //       //up
            //     else
            //    //down
            // }

            // Reset();
        }
    }

    private void CalculateDistance()
    {
        swipeDelta = Vector2.zero;
        if (isDragging)
        {
            if (Input.touchCount > 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }
    }

    private void MobileInput()
    {
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDragging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {

                isDragging = false;
                Reset();
            }
        }
    }

    private void StandAloneInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDragging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            Reset();
        }
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;
        rotateDirection = 0;
    }

}