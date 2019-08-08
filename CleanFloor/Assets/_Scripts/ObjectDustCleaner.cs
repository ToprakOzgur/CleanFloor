using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDustCleaner : MonoBehaviour
{
    private Vacuum vacuum;

    private void Awake()
    {
        vacuum = GameObject.FindObjectOfType<Vacuum>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dust"))
        {
            DustPool.Instance.ReturnToPool(other.gameObject);
            vacuum.underObjectsDustCount++;
        }
    }
}
