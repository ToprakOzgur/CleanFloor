using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UIManager : MonoBehaviour
{

    public Text proggressIndicator;
    public Text touchTimer;
    public Slider DemageSlider;
    public Slider progressSlider;
    public PowerUpUi[] powerUpUis;

    private void Start()
    {
        touchTimer.text = (GameManager.MaxRobotHealth).ToString();
        Level.OnProgressChangedEvent += ProgressChangedEvent;
        Level.OnDemagedEvent += Demaged;
        progressSlider.value = 0;
        DemageSlider.value = 0;
        PowerUp.OnPowerUpCollected += PowerUpCollected;


    }
    private void OnDisable()
    {
        Level.OnProgressChangedEvent -= ProgressChangedEvent;
        Level.OnDemagedEvent -= Demaged;
        PowerUp.OnPowerUpCollected -= PowerUpCollected;

    }


    public void ProgressChangedEvent(int progress)
    {
        //  proggressIndicator.text = proggressIndicator.text = $"%{progress}";
        progressSlider.value = progress;
    }

    public void Demaged(float time)
    {
        touchTimer.text = (GameManager.MaxRobotHealth - time).ToString("F2");
        DemageSlider.value = (time / (float)GameManager.MaxRobotHealth);

    }

    public void PowerUpCollected(PoweUpType _powerUpType)
    {
        var ui = powerUpUis.First(x => x.poweUpType == _powerUpType);
        ui.allUi.SetActive(true);
        StartCoroutine(powerUpUiTimer(ui, 10));
    }

    private IEnumerator powerUpUiTimer(PowerUpUi powerUpUi, int lifeTime)
    {

        float time = lifeTime;
        float rate = 1 / time;
        float t = 0;

        while (t < 1)
        {

            t += Time.deltaTime * rate;
            powerUpUi.fillImage.fillAmount = t;
            yield return null;
        }
        powerUpUi.allUi.SetActive(false);
    }
}

[System.Serializable]
public struct PowerUpUi
{
    public GameObject allUi;
    public Image fillImage;

    public PoweUpType poweUpType;
}
