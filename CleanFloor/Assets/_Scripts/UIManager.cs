using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text proggressIndicator;
    public Text touchTimer;
    public Slider DemageSlider;
    private void Start()
    {
        touchTimer.text = (GameManager.MaxRobotHealth).ToString();
        Level.OnProgressChangedEvent += ProgressChangedEvent;
        Level.OnDemagedEvent += Demaged;


    }
    private void OnDisable()
    {
        Level.OnProgressChangedEvent -= ProgressChangedEvent;
        Level.OnDemagedEvent -= Demaged;
    }


    public void ProgressChangedEvent(int progress)
    {
        proggressIndicator.text = proggressIndicator.text = $"%{progress}";
    }

    public void Demaged(float time)
    {
        touchTimer.text = (GameManager.MaxRobotHealth - time).ToString("F2");
        DemageSlider.value = (time / (float)GameManager.MaxRobotHealth);

    }
}
