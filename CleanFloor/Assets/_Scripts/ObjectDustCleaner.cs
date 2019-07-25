using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDustCleaner : MonoBehaviour
{
    [HideInInspector] public RoomGenerator roomGenerator;
    public GameManager gameManager;
    private void Awake()
    {
        roomGenerator = GameObject.FindGameObjectWithTag("RoomGenerator").GetComponent<RoomGenerator>();
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dust"))
        {
            // Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            gameManager.game.level.underObjectsDustCount++;
        }
    }
}
