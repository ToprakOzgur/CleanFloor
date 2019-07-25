using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoomSize : MonoBehaviour
{
    public Transform wallLeft;
    public Transform wallRight;
    public Transform wallUp;
    public Transform wallDown;
    public Transform floor;
    public int width;
    public int lenght;
    public void ChangeSize()
    {
        wallUp.localScale = new Vector3(width, 1, wallUp.localScale.z);
        wallDown.localScale = new Vector3(width, 1, wallDown.localScale.z);

        wallRight.localScale = new Vector3(lenght, 1, wallUp.localScale.z);
        wallLeft.localScale = new Vector3(lenght, 1, wallDown.localScale.z);

        wallUp.position = new Vector3(0, 20, 5 * lenght);
        wallDown.position = new Vector3(0, 20, -5 * lenght);

        wallRight.position = new Vector3(5 * width, 20, 0);
        wallLeft.position = new Vector3(-5 * width, 20, 0);


        floor.localScale = new Vector3(width, 1, lenght);
    }
}