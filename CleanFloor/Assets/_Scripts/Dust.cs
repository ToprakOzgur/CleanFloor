using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dust : MonoBehaviour
{
    Action complete;

    private float moveTime = 0.7f;
    private IEnumerator MoveToBot;

    private Transform botTransform;


    private Collider col;

    private void Awake()
    {

        col = GetComponent<Collider>();
    }
    public void MoveToVacuum(Transform bot)
    {
        col.enabled = false;
        botTransform = bot;
        MoveToBot = Move();
        StartCoroutine(MoveToBot);
        // complete = deactiveGO;
        //LeanTween.move(gameObject, transform.position, 0.5f).setEase(LeanTweenType.easeInExpo).setOnComplete(complete);


    }
    private IEnumerator Move()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(0, 0.3f));
        float time = moveTime;
        float rate = 1 / time;
        float t = 0;

        while (t < 1)
        {

            t += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(transform.position, botTransform.position, EaseInQuad(0, 1, t));
            yield return null;
        }
        deactiveGO();
    }

    private void deactiveGO()
    {

        StopCoroutine(MoveToBot);
        this.gameObject.SetActive(false);

    }


    public float EaseInQuad(float start, float end, float value)
    {
        end -= start;
        return end * value * value + start;
    }
    public float EaseInCubic(float start, float end, float value)
    {
        end -= start;
        return end * value * value * value + start;
    }

}


