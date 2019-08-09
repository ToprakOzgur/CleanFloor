using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Home currentHome;
    private static GameManager _instance;

    public static GameManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);

        var last = GetLastSavedHome();
        RandomNumberGenerator.seed = last;
        GenerateHome(last);
    }

    private void GenerateHome(int homeNumber)
    {
        currentHome = new Home(homeNumber, 3);
        currentHome.SetupHome();

    }

    private int GetLastSavedHome()
    {
        var currentHome = PlayerPrefs.GetInt("LastHome", 1);

        //return currentHome;
        return 3;
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
