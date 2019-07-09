using UnityEngine;


public class Rotator : MonoBehaviour
{
    public Swipe swipeController;

    void Update()
    {
        transform.RotateAround(Vector3.up, 3 * Time.deltaTime);
    }
}