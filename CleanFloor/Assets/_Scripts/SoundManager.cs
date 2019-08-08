using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] turnSFX;
    [SerializeField] private AudioClip powerupSFX;
    [SerializeField] private AudioClip explodeSFX;
    [SerializeField] private AudioClip obstacleSFX;
    [SerializeField] private AudioClip winSFX;
    [SerializeField] private AudioClip failSFX;
    public AudioSource audioSourceTurnEffects;
    public AudioSource audioSourceObstacles;
    public AudioSource audioSourcePowerUp;
    public AudioSource audioSourceExplode;
    public AudioSource audioSourceGeneral;




    private void OnEnable()
    {
        PowerUp.OnPowerUpCollected += PowerUpCollected;
        Rotator.OnChangeRotation += RobotChangedDirection;
        Robot.OnLevelFailed += LevelFailed;
        Movement.OnTouchObstacleAction += OnTouchObstacleAction;
        Vacuum.OnLevelComplated += LevelComplated;
    }
    private void OnDisable()
    {
        PowerUp.OnPowerUpCollected -= PowerUpCollected;
        Rotator.OnChangeRotation -= RobotChangedDirection;
        Robot.OnLevelFailed -= LevelFailed;
        Movement.OnTouchObstacleAction -= OnTouchObstacleAction;
        Vacuum.OnLevelComplated -= LevelComplated;
    }

    private void LevelComplated()
    {
        Invoke("PlayLevelComplated", 1);
    }
    private void PlayLevelComplated()
    {
        PlayClip(winSFX, audioSourceGeneral);
    }

    private void OnTouchObstacleAction(bool usTouching)
    {

        if (usTouching)
        {
            StopAllCoroutines();
            StartCoroutine(ObstacleEffectFadeIn());

            return;
        }
        StopAllCoroutines();
        StartCoroutine(ObstacleEffectFadeOut());

    }

    private void LevelFailed()
    {
        PlayClip(explodeSFX, audioSourceExplode);
        Invoke("PlayLevelFailed", 2);
    }

    void PlayLevelFailed()
    {
        PlayClip(failSFX, audioSourceGeneral, false);
    }

    private void PowerUpCollected(PoweUpType obj)
    {
        PlayClip(powerupSFX, audioSourcePowerUp);
    }

    public void RobotChangedDirection()
    {
        PlayClip(turnSFX[UnityEngine.Random.Range(0, turnSFX.Length)], audioSourceTurnEffects);

    }

    private void PlayClip(AudioClip clip, AudioSource source, bool isLooping = false)
    {
        source.clip = clip;
        source.loop = isLooping;
        source.Play();
    }



    private IEnumerator ObstacleEffectFadeIn()
    {


        audioSourceObstacles.volume = 0;
        audioSourceObstacles.loop = true;


        float time = 0.5f;
        float rate = 1 / time;
        float t = 0;

        audioSourceObstacles.Play();
        while (t < 1)
        {

            t += Time.deltaTime * rate;

            audioSourceObstacles.volume = Mathf.Lerp(0, 0.15f, t);
            yield return null;
        }

    }
    private IEnumerator ObstacleEffectFadeOut()
    {
        var startVolume = audioSourceObstacles.volume;

        float time = 0.5f;
        float rate = 1 / time;
        float t = 0;

        audioSourceObstacles.Play();
        while (t < 1)
        {

            t += Time.deltaTime * rate;
            audioSourceObstacles.volume = Mathf.Lerp(startVolume, 0, t);
            yield return null;
        }
        audioSourceObstacles.Stop();

    }
}
