using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour
{

    public Transform vacuumPoint;
    public RoomGenerator roomGenerator;
    public GameManager gameManager;
    public GameObject vacuumArea;
    public GameObject vacuumAreaPoweredUp;

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
                if (Random.Range(0, 99) < 10)
                    CreateVFX(other.gameObject.transform.position);
                other.gameObject.GetComponent<Dust>().MoveToVacuum(vacuumPoint);
                gameManager.game.level.CleanedDustCount++;

            }
        }
    }

    private void CreateVFX(Vector3 pos)
    {
        GameObject newVFX = CleanVFXPool.Instance.Get();
        newVFX.transform.position = new Vector3(pos.x, pos.y + 0.5f, pos.z);
        newVFX.SetActive(true);
    }

}
