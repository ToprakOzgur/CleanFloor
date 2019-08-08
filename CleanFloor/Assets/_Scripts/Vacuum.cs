using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour
{

    public Transform vacuumPoint;
    public GameObject vacuumArea;
    public GameObject vacuumAreaPoweredUp;
    public int underObjectsDustCount = 0;
    public int dustCount = 0;
    private int progress = 0;
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
    public static event Action OnLevelComplated = delegate { };
    public static event Action<int> OnProgressChangedEvent = delegate { };
    private int cleanedDustCount = 0;
    public int CleanedDustCount
    {
        get
        {
            return cleanedDustCount;
        }
        set
        {
            cleanedDustCount = value;

            progress = Mathf.FloorToInt((100 - (float)(dustCount - underObjectsDustCount - cleanedDustCount) / (float)(dustCount - underObjectsDustCount) * 100));
            OnProgressChangedEvent(progress);
            if (progress == 100)
            {
                OnLevelComplated();

            }

        }
    }

    private void OnEnable()
    {
        Swipe.OnLevelStarted += LevelStarted;
    }

    private void OnDisable()
    {
        Swipe.OnLevelStarted -= LevelStarted;

    }

    private void LevelStarted()
    {
        PowerOn = true;
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
                if (UnityEngine.Random.Range(0, 99) < 10)
                    CreateVFX(other.gameObject.transform.position);
                other.gameObject.GetComponent<Dust>().MoveToVacuum(vacuumPoint);
                CleanedDustCount++;

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
