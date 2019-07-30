using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    private Movement movement;
    private Vacuum vacuum;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        vacuum = GetComponent<Vacuum>();
    }
    private void OnEnable()
    {
        PowerUp.OnPowerUpCollected += PowerUpCollected;
    }
    private void OnDisable()
    {
        PowerUp.OnPowerUpCollected -= PowerUpCollected;
    }
    public void PowerUpCollected(PoweUpType powerUpType)
    {


        Action resetAction = delegate { };
        switch (powerUpType)
        {
            case PoweUpType.speed:
                Debug.Log("GELDI");
                movement.isSpeedPowerUpActive = true;
                movement.Speed = PowerUp.SpeedPoweredUp;
                resetAction = resetPowerUpSpeed;
                break;
            case PoweUpType.power:
                vacuum.vacuumArea.SetActive(false);
                vacuum.vacuumAreaPoweredUp.SetActive(true);
                resetAction = resetPowerUpPower;
                break;
            case PoweUpType.demage:
                movement.isDemagePowerUpActive = true;
                resetAction = resetPowerUpDemage;
                break;
        }
        StartCoroutine("poerUpTimer", resetAction);
    }
    private IEnumerator poerUpTimer(Action reset)
    {
        yield return new WaitForSeconds(PowerUp.PowerUpTime);
        reset();

    }
    private void resetPowerUpSpeed()
    {
        Debug.Log("speed ended");
        movement.isSpeedPowerUpActive = false;
        movement.Speed = movement.firstSpeed;
    }
    private void resetPowerUpDemage()
    {
        Debug.Log("demage ended");
        movement.isDemagePowerUpActive = false;
    }
    private void resetPowerUpPower()
    {
        Debug.Log("power ended");
        vacuum.vacuumArea.SetActive(true);
        vacuum.vacuumAreaPoweredUp.SetActive(false);
    }
}
