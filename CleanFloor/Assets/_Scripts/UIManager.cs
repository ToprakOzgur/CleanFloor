using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text proggressIndicator;
    public GameManager gameManager;

    private void Start()
    {
        gameManager.game.level.onProgressChangedEvent += ProgressChangedEvent;
    }
    private void OnDisable()
    {
        gameManager.game.level.onProgressChangedEvent -= ProgressChangedEvent;
    }


    public void ProgressChangedEvent(int progress)
    {
        proggressIndicator.text = proggressIndicator.text = $"%{progress}";
    }
}
