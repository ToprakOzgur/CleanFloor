using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] private GameObject explodePrefab;
    private Movement movement;
    private Vacuum vacuum;
    [SerializeField] private GameObject VFXSpeed;
    [SerializeField] private GameObject VFXPower;
    [SerializeField] private GameObject VFXDemage;

    public static event Action<float> OnDemagedEvent = delegate { };
    public static event Action OnLevelFailed = delegate { };

    public static int RobotHealth = 1;
    private bool isDead = false;
    private float touchTime = 0;
    public float TouchTime
    {
        get
        {
            return touchTime;
        }
        set
        {
            touchTime = value;
            OnDemagedEvent(touchTime);

            if (!isDead && touchTime / (float)RobotHealth >= 1)
            {

                OnLevelFailed();
                SpawnExplodeVFX();
                isDead = true;
            }


        }
    }

    private void SpawnExplodeVFX()
    {

        GameObject.Instantiate(explodePrefab, transform.position, Quaternion.identity, this.transform);
    }

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
                movement.isSpeedPowerUpActive = true;
                movement.Speed = PowerUp.SpeedPoweredUp;
                VFXSpeed.SetActive(true);
                resetAction = resetPowerUpSpeed;
                break;
            case PoweUpType.power:
                vacuum.vacuumArea.SetActive(false);
                vacuum.vacuumAreaPoweredUp.SetActive(true);
                VFXPower.SetActive(true);
                resetAction = resetPowerUpPower;
                break;
            case PoweUpType.demage:
                movement.isDemagePowerUpActive = true;
                VFXDemage.SetActive(true);
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

        movement.isSpeedPowerUpActive = false;
        VFXSpeed.SetActive(false);
        movement.Speed = movement.firstSpeed;
    }
    private void resetPowerUpDemage()
    {

        movement.isDemagePowerUpActive = false;
        VFXDemage.SetActive(false);
    }
    private void resetPowerUpPower()
    {

        vacuum.vacuumArea.SetActive(true);
        vacuum.vacuumAreaPoweredUp.SetActive(false);
        VFXPower.SetActive(false);
    }



}
