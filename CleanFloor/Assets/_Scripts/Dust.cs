using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dust : MonoBehaviour
{
    Action complete;
    public void MoveToVacuum(Transform botTransform)
    {
        complete = deactiveGO;
        LeanTween.move(gameObject, botTransform.position, 0.5f).setEase(LeanTweenType.easeInExpo).setOnComplete(complete);

    }

    private void deactiveGO()
    {
        this.gameObject.SetActive(false);

    }

}
