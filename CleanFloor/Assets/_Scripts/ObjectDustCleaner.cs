using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDustCleaner : MonoBehaviour
{
    public RoomGenerator roomGenerator;

    private void Awake()
    {
        roomGenerator = GameObject.FindGameObjectWithTag("RoomGenerator").GetComponent<RoomGenerator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dust"))
        {
            Destroy(other.gameObject);
            roomGenerator.dustCount--;
        }
    }
}
