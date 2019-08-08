using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{


    private void Awake()
    {

    }
    private void OnEnable()
    {
        Robot.OnLevelFailed += LevelFailed;
        Vacuum.OnLevelComplated += NextLevel;
    }
    private void OnDisable()
    {
        Robot.OnLevelFailed -= LevelFailed;
        Vacuum.OnLevelComplated -= NextLevel;
    }
    public void LevelFailed()
    {


    }




    public void NextLevel()
    {
        RandomNumberGenerator.seed++;
        if (RandomNumberGenerator.seed > 12)
        {
            RandomNumberGenerator.seed = 1;
        }
    }

}
