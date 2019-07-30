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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Robot"))
        {
            OnPowerUpCollected(poweUpType);
            this.gameObject.SetActive(false);
        }
    }
}

public enum PoweUpType
{
    speed,
    power,
    demage
}
