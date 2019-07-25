using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour
{

    public Transform vacuumPoint;
    public RoomGenerator roomGenerator;
    public GameManager gameManager;

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
        //  PowerOn = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (PowerOn)
        {
            if (other.gameObject.tag == "Dust")
            {
                other.gameObject.GetComponent<Dust>().MoveToVacuum(vacuumPoint);
                gameManager.game.level.CleanedDustCount++;
            }
        }
    }

}
