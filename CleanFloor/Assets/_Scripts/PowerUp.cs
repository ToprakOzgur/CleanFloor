using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PoweUpType
{
    speed,
    power,
    demage
}

public class PowerUp : MonoBehaviour
{
    public PoweUpType poweUpType;
    public static int SpeedPoweredUp = 25;
    public static int PowerUpTime = 10;

    private int activeInSceneLifeTime;
    public static event Action<PoweUpType> OnPowerUpCollected = delegate { };

    public void Instantieted(int lifetime)
    {
        activeInSceneLifeTime = lifetime;
        StartCoroutine(lifeTimer());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    private IEnumerator lifeTimer()
    {
        yield return new WaitForSeconds(activeInSceneLifeTime);

        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Robot"))
        {
            OnPowerUpCollected(poweUpType);
            Destroy(gameObject);
        }
    }


}



