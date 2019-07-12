using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Vector2 moveDirection = Vector2.zero;

    public Vector2 MoveDirection { get => moveDirection; }

    private Vector3 lastMousePosition;

    private void Update()
    {
#if UNITY_EDITOR
        EditorAndStandAloneControls();
#endif

#if UNITY_IOS
    MobileControls();    
#endif

#if UNITY_ANDROID
        MobileControls();
#endif
    }



    private void EditorAndStandAloneControls()
    {
        if (Input.GetMouseButtonDown(0))
        {

            lastMousePosition = (Vector2)Input.mousePosition;

        }
        if (Input.GetMouseButton(0))
        {
            Vector3 currentPostion = Input.mousePosition;
            if (lastMousePosition != currentPostion)
            {
                moveDirection = (lastMousePosition - currentPostion);
                lastMousePosition = (Vector2)Input.mousePosition;
            }

        }
        if (Input.GetMouseButtonUp(0))
        {

        }
        Debug.Log(moveDirection);

    }
    private void MobileControls()
    {
        if (Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Moved)
            {
                moveDirection = Input.touches[0].deltaPosition;
            }

            // if (Input.touches[0].phase == TouchPhase.Began)
            // {

            // }
            // if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            // {

            // }
        }
    }
    private void Reset()
    {

    }

}