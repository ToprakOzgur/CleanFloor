using UnityEngine;
public class Rotator : MonoBehaviour
{
    [SerializeField] private int rotateSpeed = 200;
    public Swipe swipeController;

    void FixedUpdate()
    {

        //......up/down swipe
        if (swipeController.UpAndDownSwipe != 0)
        {
            if (Mathf.Abs(transform.forward.x) < 0.05f)
                return;


            int updown = 0;
            if (transform.forward.x < 0)
            {
                updown = -swipeController.UpAndDownSwipe;
            }

            else if (transform.forward.x > 0)
            {
                updown = swipeController.UpAndDownSwipe;
            }


            transform.Rotate(Vector3.up, updown * rotateSpeed * Time.deltaTime, Space.World);
            return;
        }

        //......right/left swipe
        if (swipeController.RotateDirection == 0)
            return;


        transform.Rotate(Vector3.up, swipeController.RotateDirection * rotateSpeed * Time.deltaTime, Space.World);

    }
}