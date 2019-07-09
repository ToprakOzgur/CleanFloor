using UnityEngine;
public class Rotator : MonoBehaviour
{

    [SerializeField] private int rotateSpeed = 200;
    public Swipe swipeController;

    void Update()
    {

        transform.Rotate(Vector3.up, swipeController.RotateDirection * rotateSpeed * Time.deltaTime, Space.World);

    }
}