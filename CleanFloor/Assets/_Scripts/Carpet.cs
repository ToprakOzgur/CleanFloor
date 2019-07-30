using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carpet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Robot"))
        {
            other.gameObject.GetComponentInParent<Movement>().Speed = 9;

        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Robot"))
        {
            var robot = other.gameObject.GetComponentInParent<Movement>();
            robot.Speed = robot.firstSpeed;

        }
    }
}
