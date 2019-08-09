using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text currenlevel;
    public Canvas canvas;
    public GameObject startPanel;
    public GameObject winPanel;
    public GameObject failPanel;
    public GameObject powerUpArrowGO;
    public Text progressText;

    public Text failScreenproggressText;
    public Slider DemageSlider;
    public Slider progressSlider;
    public PowerUpUi[] powerUpUis;

    private Robot robot;

    private void Awake()
    {
        robot = GameObject.FindObjectOfType<Robot>();
    }

    private void OnEnable()
    {
        Vacuum.OnProgressChangedEvent += ProgressChangedEvent;
        Robot.OnDemagedEvent += Demaged;
        PowerUp.OnPowerUpCollected += PowerUpCollected;
        Swipe.OnLevelStarted += LevelStarted;
        Vacuum.OnLevelComplated += LevelComplated;
        Robot.OnLevelFailed += LevelFailed;
    }
    private void Start()
    {
        startPanel.SetActive(true);

        progressSlider.value = 0;
        progressText.text = "%0";
        DemageSlider.value = 0;

    }
    private void OnDisable()
    {
        Vacuum.OnProgressChangedEvent -= ProgressChangedEvent;
        Robot.OnDemagedEvent -= Demaged;
        PowerUp.OnPowerUpCollected -= PowerUpCollected;

        Swipe.OnLevelStarted -= LevelStarted;
        Vacuum.OnLevelComplated -= LevelComplated;
        Robot.OnLevelFailed -= LevelFailed;
    }

    private void LevelFailed()
    {
        failScreenproggressText.text = "%" + progressSlider.value;
        StartCoroutine(FadeIn(0.5f, failPanel, 2));
    }

    private void LevelComplated()
    {

        StartCoroutine(FadeIn(0.5f, winPanel, 1));
    }
    public void NextScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    private void LevelStarted()
    {

        StartCoroutine(FadeOut(0.5f, startPanel));
    }

    public void ProgressChangedEvent(int progress)
    {
        //  proggressIndicator.text = proggressIndicator.text = $"%{progress}";
        progressSlider.value = progress;
        progressText.text = "%" + progress.ToString();
    }

    public void Demaged(float time)
    {

        DemageSlider.value = (time / (float)robot.maxRobotHealth);

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

    public void PowerupItemIsInvisible(PoweUpType poweUpType, Vector3 position)
    {
        var sign = powerUpArrowGO.GetComponent<PowerupArrow>();
        sign.SetUp(poweUpType);



        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(position);


        var canvasPos = ViewportToCanvasPos.ViewportToCanvasPosition(canvas, ViewportPosition);

        if (position.x <= Camera.main.transform.position.x)
        {
            sign.rectTransform.anchorMax = new Vector2(0, 0.5f);
            sign.rectTransform.anchorMin = new Vector2(0, 0.5f);
            //sign.rectTransform.pivot = new Vector2(0, 0.5f);
            var width = sign.rectTransform.sizeDelta.x;
            sign.rectTransform.anchoredPosition = new Vector3(width / 2, canvasPos.y, sign.rectTransform.localPosition.z);
        }
        else
        {
            sign.rectTransform.anchorMax = new Vector2(1, 0.5f);
            sign.rectTransform.anchorMin = new Vector2(1, 0.5f);
            // sign.rectTransform.pivot = new Vector2(1, 0.5f);
            sign.rectTransform.localScale = new Vector3(-1, 1, 1);
            var width = sign.rectTransform.sizeDelta.x;
            sign.rectTransform.anchoredPosition = new Vector3(-width / 2, canvasPos.y, sign.rectTransform.localPosition.z);

        }

        powerUpArrowGO.SetActive(true);
    }
    public void PowerupItemIsVisible(PoweUpType poweUpType, Vector3 position)
    {
        powerUpArrowGO.SetActive(false);
    }

    public void PowerupItemInActive()
    {
        if (powerUpArrowGO != null)
        {
            powerUpArrowGO.SetActive(false);
        }

    }

    IEnumerator FadeOut(float time, GameObject go)
    {
        var canvasg = go.GetComponent<CanvasGroup>();
        canvasg.alpha = 1;



        float rate = 1 / time;
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * rate;
            canvasg.alpha = 1 - t;
            yield return null;
        }
        go.SetActive(false);
    }

    IEnumerator FadeIn(float time, GameObject go, float delay)
    {
        yield return new WaitForSeconds(delay);
        go.SetActive(true);
        var canvasg = go.GetComponent<CanvasGroup>();
        canvasg.alpha = 0;



        float rate = 1 / time;
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * rate;
            canvasg.alpha = t;
            yield return null;
        }

    }
}

[System.Serializable]
public struct PowerUpUi
{
    public GameObject allUi;
    public Image fillImage;

    public PoweUpType poweUpType;
}
