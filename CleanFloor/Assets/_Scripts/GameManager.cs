using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Home currentHome;
    public int currentHomeNumber = 0;
    public static int currentRoomNumber = 1;
    private int homeRoomCount = 3;
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
        //PlayerPrefs.SetInt("LastHome", 17);
        // PlayerPrefs.DeleteAll();
    }

    public void CreateLevel()
    {
        currentHomeNumber = GetLastSavedHome();
        RandomNumberGenerator.seed = currentHomeNumber;
        GenerateHome(currentHomeNumber);
    }
    private void GenerateHome(int _homeNumber)
    {
        if (currentHome == null || currentHome?.homeNumber != _homeNumber)
        {
            Debug.LogError("NEW HOME");
            currentHome = new Home(_homeNumber, homeRoomCount);
            currentHome.SetupHome();
        }

        foreach (var room in currentHome.rooms)
        {
            Debug.Log("ROOM " + room.roomtype + " prefab= " + room.prefabNumber + " " + room.roomdifficulty + " ObsCount= " + room.obstacleCount + " Health= " + room.robotHealth);
        }

        Robot.RobotHealth = currentHome.rooms[currentRoomNumber - 1].robotHealth;
        GameObject.FindObjectOfType<RoomGenerator>().CreateRoom(currentHome.rooms[currentRoomNumber - 1]);


        GameObject.FindObjectOfType<ObstacleManager>().CreateObstacles(currentHome.rooms[currentRoomNumber - 1].roomtype, currentHome.rooms[currentRoomNumber - 1].obstacleCount);

        GameObject.FindObjectOfType<UIManager>().SetLevelName(currentHome, currentRoomNumber);
        //TODO: delete

        GameObject.FindObjectOfType<UIManager>().SetTestUI(currentHome.rooms[currentRoomNumber - 1].prefabNumber.ToString(),
                                                            currentHome.rooms[currentRoomNumber - 1].robotHealth.ToString(),
                                                            currentHome.rooms[currentRoomNumber - 1].roomdifficulty.ToString(),
                                                             currentHome.rooms[currentRoomNumber - 1].roomtype,
                                                             currentHome.rooms[currentRoomNumber - 1].obstacleCount.ToString()
                                                            );
    }

    private int GetLastSavedHome()
    {
        var currentHome = PlayerPrefs.GetInt("LastHome", 1);

        return currentHome;

    }
    public void RoomCleaned()
    {
        currentRoomNumber++;
        if (currentRoomNumber > homeRoomCount)
        {
            foreach (var room in currentHome.rooms)
            {
                PlayerPrefs.SetInt(room.roomtype.ToString(), room.prefabNumber);

            }

            currentRoomNumber = 1;
            currentHomeNumber++;
            RandomNumberGenerator.seed = currentHomeNumber;
            PlayerPrefs.SetInt("LastHome", currentHomeNumber);
            PlayerPrefs.Save();
        }

    }

}
