using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour
{
    [SerializeField] private float power = 1.0f;


    public Transform vacuumPoint;

    private bool powerOn = false;
    public bool PowerOn
    {
        get
        {
            return powerOn;
        }
        set
        {
            powerOn = value;
        }
    }
    private void Start()
    {
        PowerOn = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (PowerOn)
        {
            if (other.gameObject.tag == "Dust")
                other.gameObject.GetComponent<Dust>().MoveToVacuum(vacuumPoint);
        }
    }
}
