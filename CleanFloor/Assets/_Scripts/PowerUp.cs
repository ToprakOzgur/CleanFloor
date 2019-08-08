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
    private UIManager uIManager;
    RectTransform myRectTransform;
    public PoweUpType poweUpType;
    public static int SpeedPoweredUp = 25;
    public static int PowerUpTime = 10;

    private int activeInSceneLifeTime;
    public static event Action<PoweUpType> OnPowerUpCollected = delegate { };
    private void Start()
    {
        uIManager = FindObjectOfType<UIManager>();
        myRectTransform = GetComponent<RectTransform>();
    }
    public void Instantieted(int lifetime)
    {
        activeInSceneLifeTime = lifetime;
        StartCoroutine(lifeTimer());
    }
    private void OnDisable()
    {
        uIManager.PowerupItemInActive();
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

    private void Update()
    {
        bool isFullyVisible = myRectTransform.IsFullyVisibleFrom(Camera.main);
        if (isFullyVisible)
        {
            uIManager.PowerupItemIsVisible(poweUpType, transform.position);
        }
        else
        {
            uIManager.PowerupItemIsInvisible(poweUpType, transform.position);
        }
    }

}



