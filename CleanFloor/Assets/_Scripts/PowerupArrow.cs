using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupArrow : MonoBehaviour
{
    public Image arrowImage;
    public Image powerupImage;

    public Sprite powerSprite;
    public Sprite speedSprite;
    public Sprite armorSprite;
    public RectTransform rectTransform;


    public void SetUp(PoweUpType poweUpType)
    {
        switch (poweUpType)
        {
            case PoweUpType.speed:
                powerupImage.sprite = speedSprite;
                break;
            case PoweUpType.demage:
                powerupImage.sprite = armorSprite;
                break;
            case PoweUpType.power:
                powerupImage.sprite = powerSprite;
                break;


        }

    }
}
