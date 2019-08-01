using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PoweUpType poweUpType;
    public static int SpeedPoweredUp = 25;
    public static int PowerUpTime = 10;
    public static event Action<PoweUpType> OnPowerUpCollected = delegate { };

    private void OnEnable()
    {
        OnPowerUpCollected += PowerUpCollected;
    }
    private void OnDisable()
    {
        OnPowerUpCollected -= PowerUpCollected;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Robot"))
        {
            OnPowerUpCollected(poweUpType);
            this.gameObject.SetActive(false);
        }
    }

    public void PowerUpCollected(PoweUpType powerUpType)
    {
        Destroy(gameObject);
    }


}


public enum PoweUpType
{
    speed,
    power,
    demage
}
