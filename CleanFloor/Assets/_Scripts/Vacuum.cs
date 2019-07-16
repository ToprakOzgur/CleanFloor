using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour
{
    [SerializeField] private DustGenerator dustGenerator;
    // Start is called before the first frame update
    [SerializeField] private float power = 1.0f;


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
            other.gameObject.GetComponent<Dust>().MoveToVacuum(this.transform);
    }
}
