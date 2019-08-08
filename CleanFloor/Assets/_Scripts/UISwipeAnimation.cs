using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISwipeAnimation : MonoBehaviour
{
    public Sprite[] sprites;
    public Image image;

    WaitForSeconds spriteChangeTime = new WaitForSeconds(0.06f);
    void Start()
    {
        StartCoroutine(AnimationCoroutine());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    IEnumerator AnimationCoroutine()
    {
        int i = 0;
        while (true)
        {
            yield return spriteChangeTime;
            image.sprite = sprites[i];
            i++;
            if (i == sprites.Length)
                i = 0;
        }

    }
}
